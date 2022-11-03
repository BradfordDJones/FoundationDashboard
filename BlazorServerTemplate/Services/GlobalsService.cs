using BlazorServerTemplate.Models.AppsDb;
using Radzen;
using System.Collections;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace BlazorServerTemplate.Services
{
    public partial class GlobalsService
    {
        protected MasterDataDbService masterDataDbService;
        protected AppsDbService appsDbService;
        protected NotificationService notificationSvc;

        #region ADIdentity

        public DirectoryEntry directoryEntry { get; set; }

        private string? loggedInUserID = null;
        public string? LoggedInUserID
        {
            get
            {
                return loggedInUserID;
            }
            set
            {
                if (loggedInUserID == null)
                {
                    if (value != null && value.ToLower().StartsWith(@"usa\"))
                        loggedInUserID = value.Substring(4);
                    else
                        loggedInUserID = value;
                }
            }
        }

        private string? loggedInUserName = null;
        public string LoggedInUserName 
        {
            get
            {
                if (loggedInUserName == null)
                {
                    loggedInUserName = (string?) UserADDirectoryEntry.Properties["displayName"].Value;
                }

                return loggedInUserName;
            }
        }
        private DirectoryEntry UserADDirectoryEntry { 
            get
            {
                PrincipalContext principalContext = new(ContextType.Domain);
                UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, loggedInUserID);
                return (DirectoryEntry)userPrincipal.GetUnderlyingObject();
            }
        }

        private List<string>? userADGroups = null;
        public List<string> UserADGroups
        {
            get
            {
                if(userADGroups == null)
                {
                    userADGroups = UserADDirectoryEntry.Properties["memberof"]?.OfType<string>()?.Select(x => x.Split(',')[0].Substring(3)).ToList();
                }
                return userADGroups;
            }
        }

        public string DataImage
        {
            get
            {
                byte[] data = UserADDirectoryEntry.Properties["thumbnailPhoto"].Value as byte[];
                if (data != null)
                {
                    return String.Format("data:image/png;base64,{0}", Convert.ToBase64String(data));
                }
                return "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGQAAABkCAYAAABw4pVUAAAACXBIWXMAAAsTAAALEwEAmpwYAAAF0GlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDIgNzkuMTYwOTI0LCAyMDE3LzA3LzEzLTAxOjA2OjM5ICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdFJlZj0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlUmVmIyIgeG1sbnM6c3RFdnQ9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZUV2ZW50IyIgeG1sbnM6ZGM9Imh0dHA6Ly9wdXJsLm9yZy9kYy9lbGVtZW50cy8xLjEvIiB4bWxuczpwaG90b3Nob3A9Imh0dHA6Ly9ucy5hZG9iZS5jb20vcGhvdG9zaG9wLzEuMC8iIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIChXaW5kb3dzKSIgeG1wOkNyZWF0ZURhdGU9IjIwMTgtMDMtMDFUMTU6MzA6MzhaIiB4bXA6TW9kaWZ5RGF0ZT0iMjAxOC0wMy0wNlQxMDo0MDo0OVoiIHhtcDpNZXRhZGF0YURhdGU9IjIwMTgtMDMtMDZUMTA6NDA6NDlaIiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOmU3ZThhNzExLTZlY2ItNjQ0Mi1iNjFjLWJkNDdhMTBkYTIxNyIgeG1wTU06RG9jdW1lbnRJRD0ieG1wLmRpZDpBQjhDMjdFMzFENjYxMUU4QUJFRUYzNzBBQkJBRTY2RiIgeG1wTU06T3JpZ2luYWxEb2N1bWVudElEPSJ4bXAuZGlkOkFCOEMyN0UzMUQ2NjExRThBQkVFRjM3MEFCQkFFNjZGIiBkYzpmb3JtYXQ9ImltYWdlL3BuZyIgcGhvdG9zaG9wOkNvbG9yTW9kZT0iMyIgcGhvdG9zaG9wOklDQ1Byb2ZpbGU9InNSR0IgSUVDNjE5NjYtMi4xIj4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9InhtcC5paWQ6QUI4QzI3RTAxRDY2MTFFOEFCRUVGMzcwQUJCQUU2NkYiIHN0UmVmOmRvY3VtZW50SUQ9InhtcC5kaWQ6QUI4QzI3RTExRDY2MTFFOEFCRUVGMzcwQUJCQUU2NkYiLz4gPHhtcE1NOkhpc3Rvcnk+IDxyZGY6U2VxPiA8cmRmOmxpIHN0RXZ0OmFjdGlvbj0ic2F2ZWQiIHN0RXZ0Omluc3RhbmNlSUQ9InhtcC5paWQ6ZTdlOGE3MTEtNmVjYi02NDQyLWI2MWMtYmQ0N2ExMGRhMjE3IiBzdEV2dDp3aGVuPSIyMDE4LTAzLTA2VDEwOjQwOjQ5WiIgc3RFdnQ6c29mdHdhcmVBZ2VudD0iQWRvYmUgUGhvdG9zaG9wIENDIChXaW5kb3dzKSIgc3RFdnQ6Y2hhbmdlZD0iLyIvPiA8L3JkZjpTZXE+IDwveG1wTU06SGlzdG9yeT4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz43lx+dAAAXg0lEQVR4nO1deXBUx5n/9bvmejOSGN0CIQ5xCwkMQViAENgmJAHHNuvYca3tHGtnY5OKvVub3S3bqUpcu+vNhhw+srFTdrzO4dixyeLELiAGAxaHOYywuAUIneg+5nxn7x8zI2ZGI2lm9EYatvhVvXrHvNfdr3/v+77ur7/uIZRS3ET6gJnsAtxEJG4Skma4SUia4SYhaYabhKQZbhKSZuDCTwghk1WOZDBWYW+Y9nx41+NGkRCCsQlI5fMTBm7sWyYFI1VeIh9QeBo0xrXw62mDdCMkusKiz/Uk040mMpqgtCEmHQgZiQQdURVVvnQZsrNz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"; ;
            }
        }

        // return if user is in any of 1 or more groups or usernames separated by commas (,)
        /*
                public bool UserIsInADList(string groupAndUserNames) 
                {
                    if (string.IsNullOrWhiteSpace(groupAndUserNames)) return false;

                    foreach (var groupName in groupAndUserNames.Split(',')) // these are the display names not SamAccountNames
                        if (UserADGroups.Contains(groupName, StringComparer.OrdinalIgnoreCase))
                            return true;

                    return groupAndUserNames.Split(',').Contains(loggedInUserID, StringComparer.OrdinalIgnoreCase); // UserID in MDD
                }
        */

        #endregion


        public GlobalsService(  MasterDataDbService masterDataDbService,
                                AppsDbService appsDbService,
                                NotificationService notificationSvc)
        {
            this.masterDataDbService = masterDataDbService;
            this.appsDbService = appsDbService;
            this.notificationSvc = notificationSvc;
        }


        #region ConnectionStrings
        //        public static Hashtable GlobalsInstances { get; set; } = new Hashtable();

        public static ConnectionStringSettingsCollection ConnectionStrings 
        { 
            get; 
            set; 
        }

        public static void Init(    MasterDataDbService masterDataDbService, 
                                    IConfiguration config)
        {
            if (ConnectionStrings == null )
            {
                System.Configuration.ConfigurationManager.RefreshSection("connectionStrings");
                System.Configuration.Configuration conf = System.Configuration.ConfigurationManager.OpenMappedMachineConfiguration(new ConfigurationFileMap(config["MachineConfigPath"]));
                System.Configuration.ConfigurationSection csSection = conf.GetSection("connectionStrings");
                ConnectionStrings = csSection.CurrentConfiguration.ConnectionStrings.ConnectionStrings;
            }
        }
        #endregion
    }
}
