using BlazorServerTemplate.Services;
using Microsoft.AspNetCore.Components;
using BlazorServerTemplate.Models.FoundationTS;

namespace BlazorServerTemplate.Pages
{
    public partial class SettingsTag : ComponentBase
    {
        [Inject]
        protected FoundationTSService? foundationTSService { get; set; }

        public string? PartyStatusCodeCountLimit { 
            get { return settingsRecord?.PartyStatusCodeCountLimit.ToString(); }
        }
        public string? ProcessTimeEntries {
            get { return settingsRecord?.ProcessTimeEntries.ToString(); }
        }
        public string? ProcessImages {
            get { return settingsRecord?.ProcessImages.ToString(); }
        }
        public string? RelatedPartyCountLimit {
            get { return settingsRecord?.RelatedPartyCountLimit.ToString();  }
        }
        public string? MatterDateLimit {
            get { return settingsRecord?.MatterDateLimit.ToString();  }
        }
        public string? TimeEntryBeginDate {
            get { return settingsRecord?.TimeEntryBeginDate.ToString();  }
        }

        public Settings? settingsRecord = null;

        protected override async Task OnInitializedAsync()
        {
            settingsRecord = foundationTSService?.GetSettingsRecord();
            await base.OnInitializedAsync();
        }
    }
}
