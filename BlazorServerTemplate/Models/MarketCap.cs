using System;
using System.Collections.Generic;

namespace BlazorServerTemplate.Models
{
    public partial class MarketCap
    {
        public int Id { get; set; }
        public string Ticker { get; set; } = null!;
        public decimal MarketCap1 { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
