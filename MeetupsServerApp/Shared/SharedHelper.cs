using Microsoft.AspNetCore.Mvc.Rendering;

namespace MeetupsServerApp.Shared
{
    public static class SharedHelper
    {
        public static List<SelectListItem> GetCategories()
        {
            return Enum.GetValues(typeof(MeetupCategoriesEnum))
                       .Cast<MeetupCategoriesEnum>()
                       .Select(e => new SelectListItem
                       {
                           Value = e.ToString(),
                           Text = e.GetDisplayName()
                       })
                       .ToList();
        }

    }
}
