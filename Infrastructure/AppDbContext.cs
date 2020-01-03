﻿using DomainEntityModel;
using System.Data.Entity;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("CRUDDB")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<BankAccount> BankAccounts{ get; set; }
    }
}
