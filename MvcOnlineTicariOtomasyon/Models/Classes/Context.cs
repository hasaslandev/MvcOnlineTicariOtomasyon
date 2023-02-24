using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Context:DbContext
    {
        public DbSet<Admin> admins { get; set; }
        public DbSet<BillPencil> billPencils { get; set; }
        public DbSet<Bill> bills { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Current> currents { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Expense> expenses { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<SalesMovement> salesMovements { get; set; }
        
    }
}