using BlazorServerTemplate.Services;
using Microsoft.AspNetCore.Components;
using BlazorServerTemplate.Models.Bucket;

namespace BlazorServerTemplate.Pages
{
    public partial class ProcessCharts : ComponentBase
    {
        [Inject]
        protected BucketService? appsDbService { get; set; }

        public List<AppEventLog>? durations;

        protected override Task OnInitializedAsync()
        {
            durations = appsDbService?.GetEventLogRecords(1000);
            return Task.CompletedTask;
        }
    }
}
