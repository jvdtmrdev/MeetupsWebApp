using Microsoft.AspNetCore.Components;

namespace MeetupsServerApp.Shared.Services
{
    public class LayoutService
    {
        public RenderFragment? SectionContent { get; set; }

        public event Action? OnContentChanged;

        public void SetSectionContent(RenderFragment content)
        {
            SectionContent = content;
            OnContentChanged?.Invoke();
        }
    }
}
