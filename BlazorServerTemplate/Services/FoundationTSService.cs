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
using BlazorServerTemplate.Models.FoundationTS;

namespace BlazorServerTemplate.Services
{
    public partial class FoundationTSService
    {
        private readonly FoundationTSDbContext context;
        private readonly IConfiguration config;

        FoundationTSDbContext Context
        {
            get { return this.context; }
        }

        public FoundationTSService(FoundationTSDbContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
            Context.Database.SetCommandTimeout(int.Parse(this.config["CommandTimeout"]));
        }
    }
}
