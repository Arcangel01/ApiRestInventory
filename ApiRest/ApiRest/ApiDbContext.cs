using ApiRest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest
{
    public class ApiDbContext : IdentityDbContext
    {
        public ApiDbContext(DbContextOptions opciones) : base(opciones)
        {

        }

        public DbSet<Admon> Admons { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Factura> Facturas { get; set; }

        protected override void OnModelCreating(ModelBuilder Create)
        {
            base.OnModelCreating(Create);
            new Admon.MapeoAdmin(Create.Entity<Admon>());
            new Categoria.MapeoCat(Create.Entity<Categoria>());
            new Productos.MapeoProd(Create.Entity<Productos>());
            new Factura.MapeoFact(Create.Entity<Factura>());

        }
    }
}
