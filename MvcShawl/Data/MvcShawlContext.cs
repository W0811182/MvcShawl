using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcShawl.Models;

namespace MvcShawl.Data
{
    public class MvcShawlContext : DbContext
    {
        public MvcShawlContext (DbContextOptions<MvcShawlContext> options)
            : base(options)
        {
        }

        public DbSet<MvcShawl.Models.Shawl> Shawl { get; set; } = default!;
    }
}
