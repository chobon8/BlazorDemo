﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Drawer;
using Skclusive.Material.Script;

namespace Blazor.App.Layout
{
    public class MainLayoutComponent : MaterialComponentBase
    {
        public MainLayoutComponent() : base("MainLayout")
        {
        }

        [Parameter]
        public RenderFragment BodyContent { get; set; }

        [Inject]
        public MediaQueryMatcher MediaQueryMatcher { get; set; }

        [Inject]
        public ILayoutConfig LayoutConfig { get; set; }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public string TopbarStyle { set; get; }

        [Parameter]
        public string TopbarClass { set; get; }

        [Parameter]
        public string SidebarStyle { set; get; }

        [Parameter]
        public string SidebarClass { set; get; }

        [Parameter]
        public string ContentStyle { set; get; }

        [Parameter]
        public string ContentClass { set; get; }

        [Parameter]
        public RenderFragment<(string, string)> ProfileContent { set; get; }

        [Parameter]
        public RenderFragment<(string, string)> NavigationContent { set; get; }

        [Parameter]
        public RenderFragment<(string, string)> FooterContent { set; get; }

        protected bool IsDesktop { set; get; } = false;

        protected bool SidebarOpen { set; get; } = false;

        protected override IEnumerable<string> Classes
        {
            get
            {
                foreach (var item in base.Classes)
                    yield return item;

                if (IsDesktop)
                    yield return "ShiftContent";
            }
        }

        protected virtual string _ContentStyle
        {
            get => CssUtil.ToStyle(ContentStyles, ContentStyle);
        }

        protected virtual IEnumerable<Tuple<string, object>> ContentStyles
        {
            get => Enumerable.Empty<Tuple<string, object>>();
        }

        protected virtual string _ContentClass
        {
            get => CssUtil.ToClass(Selector, ContentClasses, ContentClass);
        }

        protected virtual IEnumerable<string> ContentClasses
        {
            get
            {
                yield return "Content";
            }
        }

        protected DrawerVariant SidebarVariant => IsDesktop ? DrawerVariant.Persistent : DrawerVariant.Temporary;

        private IDisposable TimeoutDisposal { set; get; }

        protected void HandleSidebarClose()
        {
            SidebarOpen = false;

            StateHasChanged();
        }

        protected void HandleSidebarOpen()
        {
            SidebarOpen = true;

            StateHasChanged();
        }

        protected override Task OnInitializedAsync()
        {
            MediaQueryMatcher.OnChange += OnMediaQueryChanged;

            if (LayoutConfig.Responsive)
            {
                TimeoutDisposal = ExecutionPlan.Delay(500, () => {
                    _ = MediaQueryMatcher.RegisterAsync("(min-width:1280px)");
                });
            }

            return Task.CompletedTask;
        }

        protected void OnMediaQueryChanged(object sender, bool match)
        {
            IsDesktop = match;

            SidebarOpen = IsDesktop;

            StateHasChanged();
        }

        protected override void Dispose()
        {
            TimeoutDisposal?.Dispose();

            MediaQueryMatcher.OnChange -= OnMediaQueryChanged;

            _ = MediaQueryMatcher.UnRegisterAsync();
        }
    }
}
