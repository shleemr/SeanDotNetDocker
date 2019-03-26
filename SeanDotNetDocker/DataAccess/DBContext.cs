using Microsoft.EntityFrameworkCore;
using SeanDotNetDocker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeanDotNetDocker.DataAccess
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        // Db
        public virtual DbSet<WebSettingModel> WebSettings { get; set; }
    }
}
