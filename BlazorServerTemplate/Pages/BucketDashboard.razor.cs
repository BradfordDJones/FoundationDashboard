using BlazorServerTemplate.Models.AppsDb;
using BlazorServerTemplate.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorServerTemplate.Pages
{
    public partial class BucketDashboard : ComponentBase
    {
        [Inject]
        protected AppsDbService? appsDbService { get; set; }

        private BucketAppEventLog[]? durations;

        protected override async Task OnInitializedAsync()
        {
            durations = await appsDbService?.GetFoundationJobDurationsAsync();
        }
    }
}
