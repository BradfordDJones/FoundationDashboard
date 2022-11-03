using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerTemplate.Data
{
    public class MasterDataDbContextOld : DbContext
    {
        public MasterDataDbContextOld(DbContextOptions<MasterDataDbContextOld> options) : base(options)
        {
        }

        public MasterDataDbContextOld()
        {
        }
    }
}
