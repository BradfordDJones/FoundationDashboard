using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using BlazorServerTemplate.Services;
using System.Net.WebSockets;

namespace BlazorServerTemplate.Shared
{
    public partial class MainLayoutComponent: LayoutComponentBase
    {
        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }


        [Inject]
        protected GlobalsService Globals { get; set; }

        [Inject]
        protected MasterDataDbService MasterDataDb { get; set; }

        [Inject]
        protected IConfiguration Config { get; set; }

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


        protected async System.Threading.Tasks.Task SidebarToggle0Click(dynamic args)
        {
            await InvokeAsync(() => { sidebar0?.Toggle(); });

            await InvokeAsync(() => { body0?.Toggle(); });
        }
        
        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            AuthenticationState state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            Globals.LoggedInUserID = state.User.Identity.Name;
            GlobalsService.Init(
                MasterDataDb,
                //, ExpenseReclassDb,
                Config
                );
        }
    }
}
