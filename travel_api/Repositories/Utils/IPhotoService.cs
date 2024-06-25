using travel_api.ViewModels.Requests.MediaRequest;
using travel_api.ViewModels.Responses.UtilViewModel;

namespace travel_api.Repositories.Utils
{
    public interface IPhotoService
    {
        public Task<PhotoVM> CreatePhotoAsync(FileRequest file);
        public Task<ICollection<PhotoVM>> CreatePhotosAsync(ICollection<FileRequest> files);
        public Task<PhotoVM> DeletePhotoAsync(int publicId);
        public Task<ICollection<PhotoVM>> DeletePhotosAsync(ICollection<int> publicIds);
    }
}
