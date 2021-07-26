using EFCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repository.Data
{
    public class PersonagemContext : DbContext
    {
        public PersonagemContext(DbContextOptions<PersonagemContext> options) : base(options)
        {}
            
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<Mapa> Mapas{ get; set; }
        public DbSet<Skin> Skins { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<PersonagemMapa> PersonagemMapas { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer
        //} 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<PersonagemMapa>(entity => {
                entity.HasKey(e => new { e.MapaId, e.PersonagemId });
                });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Skin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Arma>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Mapa>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
