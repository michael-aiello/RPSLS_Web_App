using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RPSLS_Web_App.Models
{
    public class RPSLS_Web_AppContext : DbContext
    {
        public RPSLS_Web_AppContext (DbContextOptions<RPSLS_Web_AppContext> options)
            : base(options)
        {
        }

        public DbSet<RPSLS_Web_App.Models.Player> Player { get; set; }
    }
}
