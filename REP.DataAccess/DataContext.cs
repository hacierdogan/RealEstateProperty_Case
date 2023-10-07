using Microsoft.EntityFrameworkCore;
using REP.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REP.DataAccess
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-JPVN7MA; Database=REP_DB;uid=sa;pwd=123;integrated security=true;");
        }
        public DbSet<Advert> Adverts { get; set; }
    }
}
