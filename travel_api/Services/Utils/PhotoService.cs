using AutoMapper;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using travel_api.Models.Utils;
using travel_api.Repositories;
using travel_api.Configuration;
using travel_api.Repositories.Utils;
using travel_api.ViewModels.Responses.UtilViewModel;
using System.Buffers.Text;
using travel_api.ViewModels.Requests.MediaRequest;

namespace travel_api.Services.Utils
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PhotoService(DataContext context, IMapper mapper, IOptions<CloudinarySetting> config)
        {
            _context = context;
            _mapper = mapper;

            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account);
        }

        public async Task<PhotoVM> CreatePhotoAsync(FileRequest file)
        {
            var uploadResult = new ImageUploadResult();

            if (string.IsNullOrEmpty(file.Base64))
            {
                throw new Exception("File is empty");
            }

            byte[] bytes = Convert.FromBase64String(file.Base64);

            using (var stream = new MemoryStream(bytes))
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    UseFilename = true,
                    UniqueFilename = false,
                    Overwrite = true
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            var newPhoto = new Photo()
            {
                PhotoPublicId = uploadResult.PublicId,
                PhotoUrl = uploadResult.Url.ToString()
            };

            _context.Photos.Add(newPhoto);

            await _context.SaveChangesAsync();

            // result
            var newPhotoVM = _mapper.Map<PhotoVM>(newPhoto);

            return newPhotoVM;
        }

        public async Task<ICollection<PhotoVM>> CreatePhotosAsync(ICollection<FileRequest> files)
        {
            var newPhotosVM = new List<PhotoVM>();

            foreach (var file in files)
            {
                var newPhotoVM = await CreatePhotoAsync(file);

                newPhotosVM.Add(newPhotoVM);
            }

            return newPhotosVM;
        }

        public async Task<PhotoVM> DeletePhotoAsync(int photoId)
        {
            var photoDelete = await _context.Photos.FindAsync(photoId);

            if (photoDelete == null)
            {
                throw new Exception("Photo not found");
            }

            // photo exists


            var deleteParams = new DeletionParams(photoDelete.PhotoPublicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            if (result.Error != null)
            {
                throw new Exception("Remove photo failed");
            }

            // success
            _context.Photos.Remove(photoDelete);

            await _context.SaveChangesAsync();

            // mapping
            var photoDeleteVM = _mapper.Map<PhotoVM>(photoDelete);

            return photoDeleteVM;
        }

        public async Task<ICollection<PhotoVM>> DeletePhotosAsync(ICollection<int> publicIds)
        {
            var photosDeleteVM = new List<PhotoVM>();

            foreach (int publicId in publicIds)
            {
                var photoDeleteVM = await DeletePhotoAsync(publicId);

                photosDeleteVM.Add(photoDeleteVM);
            }

            return photosDeleteVM;
        }
    }
}
