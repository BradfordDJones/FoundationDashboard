using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
//using ExpenseReclass.Models;
//using ExpenseReclass.Models.ExpenseReclassDb;
//using ExpenseReclass.Models.MasterDataDb;
//using ExpenseReclass;
//using ExpenseReclass.Pages;
using Radzen;

namespace BlazorServerTemplate.Services
{
    public partial class GlobalsService
    {
//        protected ExpenseReclassDbService expenseReclassDb;
 //       protected MasterDataDbService masterDataDb;
        protected NotificationService notificationSvc;

        #region static properties
        public static Hashtable GlobalsInstances { get; set; } = new Hashtable();

        public static ConnectionStringSettingsCollection ConnectionStrings 
        { 
            get; 
            set; 
        }
        #endregion


        private string currentUserName = null;
        public string CurrentUserName
        {
            get
            {
                return currentUserName;
            }
            set
            {
                if (currentUserName == null)
                {
                    if (value != null && value.ToLower().StartsWith(@"usa\"))
                        currentUserName = value.Substring(4);
                    else
                        currentUserName = value;
                }
            }
        }

        private string currentUser = null;
        public string CurrentUser 
        {
            get
            {
                //                if (currentUser == null && GlobalsService.Employees != null)
                //                {
                //                    currentUser = GlobalsService.Employees.Where(x => x.UserName == currentUserName)?.Select(x => x.SpaceName).FirstOrDefault();
                //                }
                //                return currentUser;
                return CurrentUserName;
            }
        }

        private List<string> userADGroups = null;
        public List<string> UserADGroups
        {
            get
            {
                if(userADGroups == null)
                {
                    PrincipalContext principalContext = new(ContextType.Domain);
                    UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, currentUserName);
                    DirectoryEntry directoryEntry = (DirectoryEntry)userPrincipal.GetUnderlyingObject();

                    userADGroups = directoryEntry.Properties["memberof"]?.OfType<string>()?.Select(x => x.Split(',')[0].Substring(3)).ToList();
                }
                return userADGroups;
            }
        }

        // return if user is in any of 1 or more groups or usernames separated by commas (,)
/*        public bool UserIsInADList(string groupAndUserNames) 
        {
            if (string.IsNullOrWhiteSpace(groupAndUserNames)) return false;

            foreach (var groupName in groupAndUserNames.Split(',')) // these are the display names not SamAccountNames
                if (UserADGroups.Contains(groupName, StringComparer.OrdinalIgnoreCase))
                    return true;

            return groupAndUserNames.Split(',').Contains(currentUserName, StringComparer.OrdinalIgnoreCase); // UserID in MDD
        }
*/

        public GlobalsService(
            //ExpenseReclassDbService expenseReclassDb, MasterDataDbService masterDataDb,
            NotificationService notificationSvc)
        {
//            this.expenseReclassDb = expenseReclassDb;
//            this.masterDataDb = masterDataDb;
            this.notificationSvc = notificationSvc;
        }


        #region static methods
        public static void Init(
            //MasterDataDbService masterDataDbService, ExpenseReclassDbService expenseReclassDb,
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
