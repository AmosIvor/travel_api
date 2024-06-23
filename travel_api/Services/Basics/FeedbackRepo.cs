using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Enums;
using travel_api.Exceptions;
using travel_api.Helpers;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.Responses.EFViewModel;

namespace travel_api.Services.Basics
{
    public class FeedbackRepo : IFeedbackRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public FeedbackRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeedbackVM>> GetAllFeedbacksAsync()
        {
            var feedbacks = await _context.Feedbacks
                              .Include(p => p.Location)
                              .Include(p => p.FeedbackMedias)
                              .Include(p => p.User)
                              .OrderByDescending(p => p.FeedbackDate)
                              .ToListAsync();

            var feedbacksVM = _mapper.Map<IEnumerable<FeedbackVM>>(feedbacks);

            return feedbacksVM;
        }

        public async Task<IEnumerable<FeedbackVM>> GetListFeedbacksByUserIdAsync(string userId)
        {
            var feedbacks = await _context.Feedbacks
                                    .Include(p => p.Location)
                                    .Include(p => p.FeedbackMedias)
                                    .Where(p => p.UserId == userId)
                                    .OrderByDescending(p => p.FeedbackDate)
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
                                    .SingleOrDefaultAsync(p => p.FeedbackId == feedbackId);

            if (feedback == null)
            {
                throw new NotFoundException("Feedback not found");
            }

            var feedbackVM = _mapper.Map<FeedbackVM>(feedback);

            return feedbackVM;
        }

        public async Task<IEnumerable<FeedbackVM>> GetFeedbacksByFilterAsync(decimal rating = 5, 
            int timeFeedbackType = 0, int tripType = 0)
        {
            EnumFilterDateFeedback timeFilter = (EnumFilterDateFeedback)timeFeedbackType;

            DateTime startFilterDate = FeedbackFilterHelper.GetStartDateTimeFeedbackFilter(timeFilter);

            var listFeedbackFilter = await _context.Feedbacks.OrderByDescending(f => f.FeedbackDate)
                                                             .Include(f => f.FeedbackMedias)
                                                             .Include(f => f.Location)
                                                             .Include(f => f.User)
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
    }
}
