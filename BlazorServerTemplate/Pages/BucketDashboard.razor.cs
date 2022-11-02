using BlazorServerTemplate.Data;
using BlazorServerTemplate.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorServerTemplate.Pages
{
    public partial class BucketDashboard : ComponentBase
    {
        [Inject]
        protected GlobalsService? Globals { get; set; }

        private BucketDuration[]? durations;
//        private WeatherForecast[]? forecasts;

        protected override async Task OnInitializedAsync()
        {
//            await Task.Run(() => { });

            durations = await Globals.GetDurationsAsync();
//            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);

        }

    }
}
