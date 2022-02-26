using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnnakkoTehtävä2.Models
{
    public class EnergiaContext : DbContext
    {
        public EnergiaContext(DbContextOptions<EnergiaContext> options)
           : base(options)
        {
        }

        public DbSet<EnergiaContext> EnergiaDatat { get; set; }
    }
}
