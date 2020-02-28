﻿using Microsoft.AspNetCore.Components;
using Skclusive.Material.Core;

namespace Blazor.App.Layout
{
    public class FooterComponent : MaterialComponent
    {
        public FooterComponent() : base("Footer")
        {
        }

        [Parameter]
        public string Component { set; get; } = "div";

        [Parameter]
        public string DomainName { set; get; }

        [Parameter]
        public string DomainUrl { set; get; }

        [Parameter]
        public string Copyright { set; get; }
    }
}
