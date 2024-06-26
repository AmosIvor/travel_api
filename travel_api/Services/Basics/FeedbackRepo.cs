﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Enums;
using travel_api.Exceptions;
using travel_api.Helpers;
using travel_api.Models.EF;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.Services.Utils;
using travel_api.ViewModels.Responses.EFViewModel;
using travel_api.ViewModels.Responses.UtilViewModel;

namespace travel_api.Services.Basics
{
    public class FeedbackRepo : IFeedbackRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly Web3Service _chain;

        public FeedbackRepo(DataContext context, IMapper mapper, Web3Service chain)
        {
            _context = context;
            _mapper = mapper;
            _chain = chain;
        }

        public async Task<IEnumerable<FeedbackVM>> GetAllFeedbacksAsync()
        {
            var feedbacks = await _context.Feedbacks
                              .Include(p => p.Location)
                              .Include(p => p.FeedbackMedias)
                              .Include(p => p.User)
                              .OrderByDescending(p => p.FeedbackDate)
                              .AsNoTracking()
                              .ToListAsync();

            var feedbacksVM = _mapper.Map<IEnumerable<FeedbackVM>>(feedbacks);

            return feedbacksVM;
        }

        public async Task<IEnumerable<FeedbackVM>> GetListFeedbacksByUserIdAsync(string userId)
        {
            var feedbacks = await _context.Feedbacks
                                    .Include(p => p.Location)
                                    .Include(p => p.FeedbackMedias)
                                    .Include(p => p.User)
                                    .Where(p => p.UserId == userId)
                                    .OrderByDescending(p => p.FeedbackDate)
                                    .AsNoTracking()
                                    .ToListAsync();

            // mapper
            var feedbacksVM = _mapper.Map<IEnumerable<FeedbackVM>>(feedbacks);

            return feedbacksVM;
        }

        public async Task<FeedbackVM> GetFeedbackByIdAsync(int feedbackId)
        {
            // find feedback
            var feedback = await _context.Feedbacks
                                    .Include(p => p.Location)
                                    .Include(p => p.FeedbackMedias)
                                    .Include(p => p.User)
                                    .AsNoTracking()
                                    .SingleOrDefaultAsync(p => p.FeedbackId == feedbackId);

            if (feedback == null)
            {
                throw new NotFoundException("Feedback not found");
            }

            var feedbackVM = _mapper.Map<FeedbackVM>(feedback);

            return feedbackVM;
        }

        public async Task<IEnumerable<FeedbackVM>> GetFeedbacksByFilterAsync(int locationId, decimal rating = 5, 
            int timeFeedbackType = 0, int tripType = 0)
        {
            EnumFilterDateFeedback timeFilter = (EnumFilterDateFeedback)timeFeedbackType;

            DateTime startFilterDate = FeedbackFilterHelper.GetStartDateTimeFeedbackFilter(timeFilter);

            var listFeedbackFilter = await _context.Feedbacks.Where(x => x.LocationId == locationId)
                                                             .OrderByDescending(f => f.FeedbackDate)
                                                             .Include(f => f.FeedbackMedias)
                                                             .Include(f => f.User)
                                                             .AsNoTracking()
                                                             .ToListAsync();

            // fitler
            listFeedbackFilter = listFeedbackFilter.Where(f => f.FeedbackRate >= rating).ToList();
            listFeedbackFilter = listFeedbackFilter.Where(f => f.FeedbackDate >= startFilterDate).ToList();
            
            if (tripType != 0)
            {
                // filter by trip type
                listFeedbackFilter = listFeedbackFilter.Where(f => f.TripType == tripType).ToList();
            }

            // mapping
            var listFeedbackMapping = _mapper.Map<IEnumerable<FeedbackVM>>(listFeedbackFilter);

            return listFeedbackMapping;
        }

        public async Task<Feedback> AddFeedback(FeedbackBCVM vm)
        {
            await _chain.NewFeedback(vm);

            var newFB = new Feedback
            {
                FeedbackDate = DateTime.Now,
                FeedbackContent = vm.Comment,
                FeedbackRate = vm.Score,
                TripType = vm.TripType,
                UserId = vm.UserId,
                LocationId = vm.LocationId
            };

            _context.Feedbacks.Add(newFB);
            await _context.SaveChangesAsync();

            var medias = vm.Medias.Split('_');

            int order = 1;
            foreach (var media in medias)
            {
                _context.FeedbackMedias.Add(new FeedbackMedia
                {
                    FeedbackId = newFB.FeedbackId,
                    FeedbackMediaOrder = order,
                    FeedbackMediaUrl = media
                });

                await _context.SaveChangesAsync();
            }

            return newFB;
        }

        public async Task<IEnumerable<FeedbackVM>> GetFeedbacksByUserIdAndCityIdAsync(string userId, int cityId)
        {
            var listFeedback = await _context.Feedbacks.Where(x => x.UserId == userId && x.Location.CityId == cityId)
                                                       .OrderByDescending(f => f.FeedbackDate)
                                                       .Include(x => x.User)
                                                       .Include(x => x.FeedbackMedias)
                                                       .Include(x => x.Location)
                                                       .AsNoTracking()
                                                       .ToListAsync();

            var listFeedbackMapping = _mapper.Map<IEnumerable<FeedbackVM>>(listFeedback);

            return listFeedbackMapping;
        }

        public async Task<object> GetBlockDetail(int feedbackId)
        {
            var feedback = await _chain.GetBlockData(feedbackId);

            if (feedback == null)
            {
                throw new Exception("Feedback not found!");
            }

            return feedback;
        }

        public async Task<IEnumerable<FeedbackBC>> GetChainData()
        {
            var feedbacks = await _chain.GetChainData();
            return feedbacks;
        }
    }
}
