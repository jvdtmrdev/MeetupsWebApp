using AutoMapper;
using MeetupsServerApp.Data;
using MeetupsServerApp.Data.Entities;
using MeetupsServerApp.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MeetupsServerApp.Features.DiscoverEvents
{
    public class DiscoverEventsService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMapper _mapper;

        public DiscoverEventsService(IDbContextFactory<ApplicationDbContext> dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<EventViewModel>> GetEventsAsync(
            int pageNumber,
            int pageSize,
            string? searchText = null)
        {
            await using var context = await _dbContext.CreateDbContextAsync();

            searchText = searchText?.Trim();

            var events = await GetPagedEventsAsync(context, pageNumber, pageSize, searchText);

            if (!string.IsNullOrEmpty(searchText) && events.Count() == 0)
            {
                events = await GetPagedEventsAsync(context, pageNumber, pageSize, null);
            }

            return _mapper.Map<List<EventViewModel>>(events);
        }

        private async Task<List<Event>> GetPagedEventsAsync(
            ApplicationDbContext context,
            int pageNumber,
            int pageSize,
            string? searchText)
        {
            var now = DateTime.Now;

            IQueryable<Event> eventsQuery = context.Events.AsNoTracking()
                .Where(e => (string.IsNullOrEmpty(searchText)
                || e.Title.Contains(searchText)
                || e.Desription.Contains(searchText)
                || e.Location.Contains(searchText))
                && (e.BeginDate > now.Date || (e.BeginDate == now.Date || e.BeginTime >= now.TimeOfDay)))
                .OrderBy(e => e.BeginDate)
                .ThenBy(e => e.BeginTime);

            return await eventsQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
