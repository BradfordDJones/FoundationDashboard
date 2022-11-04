﻿using BlazorServerTemplate.Services;
using Microsoft.AspNetCore.Components;
using BlazorServerTemplate.Models.Bucket;

namespace BlazorServerTemplate.Pages
{
    public partial class ProcessCharts : ComponentBase
    {
        [Inject]
        protected BucketService? appsDbService { get; set; }

        public List<AppEventLog>? durations = null;

        protected override async Task OnInitializedAsync()
        {
            durations = appsDbService?.GetEventLogRecords(5000);
        }
    }
}
