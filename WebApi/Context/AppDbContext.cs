using DomainEntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("CRUDDB")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}