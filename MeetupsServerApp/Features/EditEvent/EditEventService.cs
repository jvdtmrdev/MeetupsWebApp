using AutoMapper;
using MeetupsServerApp.Data;
using MeetupsServerApp.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MeetupsServerApp.Features.EditEvent
{
    public class EditEventService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMapper _mapper;

        public EditEventService(IDbContextFactory<ApplicationDbContext> dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EventViewModel> GetEventByIdAsync(int eventId)
        {
            await using var context = await _dbContext.CreateDbContextAsync();

            var eventEntity = await context.Events?.SingleOrDefaultAsync(e => e.EventId == eventId);

            return _mapper.Map<EventViewModel>(eventEntity);
        }

        public async Task UpdateEventAsync(EventViewModel eventViewModel)
        {
            await using var context = await _dbContext.CreateDbContextAsync();

            var eventEntity = await context.Events?.SingleOrDefaultAsync(e => e.EventId == eventViewModel.EventId);

            if (eventEntity != null)
            {
                _mapper.Map(eventViewModel, eventEntity);

                await context.SaveChangesAsync();
            }
        }
    }
}
