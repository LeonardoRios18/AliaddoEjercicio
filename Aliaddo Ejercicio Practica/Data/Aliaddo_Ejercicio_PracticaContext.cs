using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aliaddo_Ejercicio_Practica.Models;

    public class Aliaddo_Ejercicio_PracticaContext : DbContext
    {
        public Aliaddo_Ejercicio_PracticaContext (DbContextOptions<Aliaddo_Ejercicio_PracticaContext> options)
            : base(options)
        {
        }
        public DbSet<Aliaddo_Ejercicio_Practica.Models.Padre> Padre { get; set; }
        public DbSet<Aliaddo_Ejercicio_Practica.Models.Hijo> Hijo { get; set; }


    }
