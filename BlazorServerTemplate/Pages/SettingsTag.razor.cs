using BlazorServerTemplate.Services;
using Microsoft.AspNetCore.Components;
using BlazorServerTemplate.Models.FoundationTS;
using Microsoft.AspNetCore.Components.Web;
using System.Reflection.Metadata.Ecma335;

namespace BlazorServerTemplate.Pages
{
    public partial class SettingsTag : ComponentBase
    {
        [Inject]
        protected FoundationTSService? foundationTSService { get; set; }

        public Settings? rec = null;

        protected override async Task OnInitializedAsync()
        {
            rec = await foundationTSService!.GetSettingsRecordAsync();
        }

        protected async Task Save(MouseEventArgs args)
        {
            await foundationTSService!.SaveSettingsRecordAsync(rec);
        }

        protected async Task Cancel(MouseEventArgs args)
        {
            rec = await foundationTSService!.GetSettingsRecordAsync();
            StateHasChanged();
        }
    }
}
