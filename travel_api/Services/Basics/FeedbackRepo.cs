using AutoMapper;
using Microsoft.EntityFrameworkCore;
using travel_api.Exceptions;
using travel_api.Repositories;
using travel_api.Repositories.Basics;
using travel_api.ViewModels.EFViewModel;

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
                              .OrderByDescending(p => p.FeedbackDate)
                              .ToListAsync();

            var feedbacksVM = _mapper.Map<IEnumerable<FeedbackVM>>(feedbacks);

            return feedbacksVM;
        }

        public async Task<IEnumerable<FeedbackVM>> GetListFeedbacksByUserId(string userId)
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

        public async Task<FeedbackVM> GetFeedbackById(int feedbackId)
        {
            // find feedback
            var feedback = await _context.Feedbacks
                                    .Include(p => p.Location)
                                    .Include(p => p.FeedbackMedias)
                                    .SingleOrDefaultAsync(p => p.FeedbackId == feedbackId);

            if (feedback == null)
            {
                throw new NotFoundException("Feedback not found");
            }

            var feedbackVM = _mapper.Map<FeedbackVM>(feedback);

            return feedbackVM;
        }
    }
}
