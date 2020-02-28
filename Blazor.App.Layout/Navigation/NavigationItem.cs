using Microsoft.AspNetCore.Components;

namespace Blazor.App.Layout
{
    public class NavigationItem
    {
        public string Title { set; get; }

        public string Path { set; get; }

        public RenderFragment Icon { set; get; }

        public bool Prefix { set; get; }
    }
}
