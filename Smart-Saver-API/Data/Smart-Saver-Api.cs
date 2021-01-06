using Microsoft.EntityFrameworkCore;
using Smart_Saver_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_Saver_API.Data
{
    public class Smart_Saver_APIContext : DbContext //Not an api context
    {
        public DbSet<CategoriesDB> CategoriesDB { get; set; }

        public DbSet<ExpenseDB> ExpenseDB { get; set; }

        public DbSet<GoalDB> GoalDB { get; set; }

        public DbSet<IncomeDB> IncomeDB { get; set; }

        public DbSet<LoginDB> LoginDB { get; set; }

        public DbSet<ReccuringIncomeDB> ReccuringIncomeDB { get; set; }
        public DbSet<UserDB> UserDB { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //I configa connection string'us
        {
            string server = "Server=tcp:smart-saver.database.windows.net,1433;"; //Konfidenciali info keliauja i configa ir net nekeliama i githuba (cyber security)
            string initialCatalog = "Initial Catalog=SmartSaver;";
            string persistSecurityInfo = "Persist Security Info=False;";
            string userID = "User ID=smartsaver;";
            string password = $"Password={Password.Pass()};";
            string multipleActiveResultSets = "MultipleActiveResultSets=False;";
            string encrypt = "Encrypt=True;";
            string trustServerCertificate = "TrustServerCertificate=False;";
            string connectionTimeout = "Connection Timeout=30;";
            optionsBuilder.UseSqlServer(server + initialCatalog + persistSecurityInfo + userID + password + multipleActiveResultSets + encrypt + trustServerCertificate + connectionTimeout);
            //string pirmas = @"Data Source=MSI;";
            //optionsBuilder.UseSqlServer(pirmas + "Initial Catalog=SmartSaver;Integrated Security=True;");
        }
    }
}
