using AnaMPrimerParcial.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnaMPrimerParcial.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DATA source= DATA/Database.db");


        }
    }
}
