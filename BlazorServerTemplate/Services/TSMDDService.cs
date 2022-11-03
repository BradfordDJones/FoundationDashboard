using System;
using System.Web;
using System.Threading.Tasks;
using System.Text;
using System.Text.Encodings.Web;
using System.Net.Http;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using Radzen;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using BlazorServerTemplate.Data;
using BlazorServerTemplate.Models.TSMDD;

namespace BlazorServerTemplate.Services
{
    public partial class TSMDDService
    {
        private readonly TSMDDDbContext context;
        private readonly IConfiguration config;

        TSMDDDbContext Context
        {
            get { return this.context; }
        }

        public TSMDDService(TSMDDDbContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
            Context.Database.SetCommandTimeout(int.Parse(this.config["CommandTimeout"]));
        }
    }
}
