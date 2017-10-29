using DTR.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTR.Data
{
    public class ReclaimContext : IdentityDbContext<Account>
    {
        public ReclaimContext(DbContextOptions<ReclaimContext>  options) : base(options)
        {

        }
        public DbSet<Reclaim> Reclaims { get; set; }

       // public DbSet<Account> Accounts { get; set; }

        public DbSet<ReclaimState> ReclaimStates { get; set; }
    }
}
