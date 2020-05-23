using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreReactLab.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreReactLab.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<TypeWork> TypeWorks { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
