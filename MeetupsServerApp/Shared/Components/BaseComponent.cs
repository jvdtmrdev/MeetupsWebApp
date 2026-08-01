using MeetupsServerApp.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace MeetupsServerApp.Shared.Components
{
    public class BaseComponent : ComponentBase
    {
        [Inject]
        protected LayoutService LayoutService { get; set; } = default!;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            LayoutService.SetSectionContent(null);
        }
    }
}
