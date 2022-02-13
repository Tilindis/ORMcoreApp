using Microsoft.EntityFrameworkCore;
using ORMcoreApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMcoreApp.DataAcces
{
    public class PoliceManContent : DbContext
    {

        public DbSet<Automobilis> automobiliai { get; set; }
        public DbSet<DienosAutomobilis> skirtinguDienuAutomobiliai { get; set; }
        public DbSet<Ginklas> ginklai { get; set; }
        public DbSet<Pareigunas> pareigunai { get; set; }
        public DbSet<UzduociuListas> uzduociuListai { get; set; }
        public DbSet<Uzduotis> Uzduotys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=office;Integrated Security=True;");
        }
 
    }
}
