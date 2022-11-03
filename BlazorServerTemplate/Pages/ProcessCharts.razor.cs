using BlazorServerTemplate.Models.AppsDb;
using BlazorServerTemplate.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorServerTemplate.Pages
{
    public partial class ProcessCharts : ComponentBase
    {
        [Inject]
        protected GlobalsService? Globals { get; set; }

//        private BucketAppEventLog[]? durations;
//        private WeatherForecast[]? forecasts;

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(() => { });

//            durations = await Globals.GetDurationsAsync();
//            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);

        }
    }
}
