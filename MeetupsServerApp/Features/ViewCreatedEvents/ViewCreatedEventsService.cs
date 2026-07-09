using AutoMapper;
using MeetupsServerApp.Data;
using MeetupsServerApp.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MeetupsServerApp.Features.ViewCreatedEvents
{
    public class ViewCreatedEventsService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMapper _mapper;

        public ViewCreatedEventsService(IDbContextFactory<ApplicationDbContext> dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<EventViewModel>> GetEventsAsync()
        {
            using var context = await _dbContext.CreateDbContextAsync();

            var events = await context.Events
                .Select(e => _mapper.Map<EventViewModel>(e))
                .ToListAsync() ?? new List<EventViewModel>();

            return events;
        }
    }
}
