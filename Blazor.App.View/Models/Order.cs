using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.App.View.Models
{
    public class Order
    {
        public string Id { set; get; }

        public string Ref { set; get; }

        public string Customer { set; get; }

        public decimal Amount { set; get; }

        public string Status { set; get; }

        public DateTime CreatedAt { set; get; }
    }
}
