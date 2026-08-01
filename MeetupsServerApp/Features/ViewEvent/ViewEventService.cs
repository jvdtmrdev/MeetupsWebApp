using AutoMapper;
using MeetupsServerApp.Data;
using MeetupsServerApp.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MeetupsServerApp.Features.ViewEvent
{
    public class ViewEventService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMapper _mapper;

        public ViewEventService(IDbContextFactory<ApplicationDbContext> dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EventViewModel?> GetEventByIdAsync(int eventId)
        {
            await using var context = await _dbContext.CreateDbContextAsync();

            var eventEntity = await context.Events.AsNoTracking()
                .SingleOrDefaultAsync(e => e.EventId == eventId);

            if (eventEntity == null)
            {
                return null;
            }

            return _mapper.Map<EventViewModel>(eventEntity);
        }
    }
}
