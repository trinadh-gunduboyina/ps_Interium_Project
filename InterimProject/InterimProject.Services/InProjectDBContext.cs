using InterimProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterimProject.Services
{
    public class InProjectDBContext : DbContext
    {
        public InProjectDBContext(DbContextOptions<InProjectDBContext> options) :
            base(options)
        { }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SiteAdmin> SiteAdmins { get; set; }
    }
}

