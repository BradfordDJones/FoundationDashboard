using BlazorServerTemplate.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using Radzen.Blazor;

namespace BlazorServerTemplate.Shared
{
    public partial class MainLayoutComponent: LayoutComponentBase
    {
        [Inject]
        protected AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        [Inject]
        protected GlobalsService? globalsService { get; set; }

        [Inject]
        protected BucketService? bucketService { get; set; }
        
        [Inject]
        protected FoundationTSService? foundationTSService { get; set; }

        [Inject]
        protected TSMDDService? tsmddService { get; set; }

        [Inject]
        protected IConfiguration? Config { get; set; }

        [Inject]
        protected NavigationManager? UriHelper { get; set; }

        [Inject]
        protected DialogService? DialogService { get; set; }

        [Inject]
        protected TooltipService? TooltipService { get; set; }

        [Inject]
        protected ContextMenuService? ContextMenuService { get; set; }

        [Inject]
        protected NotificationService? NotificationService { get; set; }
        protected RadzenBody? body0;
        protected RadzenSidebar? sidebar0;

        protected async Task SidebarToggle0Click(dynamic args)
        {
            await InvokeAsync(() => { sidebar0?.Toggle(); });
            await InvokeAsync(() => { body0?.Toggle(); });
        }
        
        protected override async Task OnInitializedAsync()
        {
            if (AuthenticationStateProvider !=  null)
            {
                AuthenticationState? state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                if (globalsService != null)
                {
                    globalsService.LoggedInUserID = state?.User?.Identity?.Name;
                }
            }

            GlobalsService.Init(Config);
        }
    }
}
