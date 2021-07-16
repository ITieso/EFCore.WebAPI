using EFCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Data
{
    public class PersonagemContext : DbContext
    {
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<Mapa> Mapas{ get; set; }
        public DbSet<Skin> Skins { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<PersonagemMapa> PersonagemMapas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Initial Catalog=WarzoneApi;Data Source=tcp:localhost");
            //optionsBuilder.UseSqlServer("User ID=igao;Password=123456abc;Data Source=tcp:localhost;Initial Catalog=WarzoneApi");
            optionsBuilder.UseSqlServer("User ID=igao;Password=123456abc;Initial Catalog=WarzoneApi;Data Source=localhost");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonagemMapa>(entity => {
                entity.HasKey(e => new { e.MapaId, e.PersonagemId });
                });
        }
    }
}
