using Microsoft.EntityFrameworkCore;
using Smart_Saver_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Saver_API.Data
{
    public class Smart_Saver_APIContext : DbContext
    {
        public DbSet<CategoriesDB> CategoriesDB { get; set; }

        public DbSet<ExpenseDB> ExpenseDB { get; set; }

        public DbSet<GoalDB> GoalDB { get; set; }

        public DbSet<IncomeDB> IncomeDB { get; set; }

        public DbSet<ReccuringIncomeDB> ReccuringIncomeDB { get; set; }
        public DbSet<UserDB> UserDB { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string pirmas = @"Data Source=MSI;";
            optionsBuilder.UseSqlServer(pirmas + "Initial Catalog=SmartSaver;Integrated Security=True;");
        }
    }
}
