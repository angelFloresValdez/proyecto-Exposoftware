using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalPOO2.Entities;

namespace ProyectoFinalPOO2
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Crear tabla de login
        /// </summary>Representa la tabla de encargados registrados para iniciar sesión.<summary>
         public DbSet<LoginEncargado> LoginEncargados { get; set;}

         //Crear Tabla de registro empleado
         /// <summary>Representa la tabla de registros de empleados.</summary>
         public DbSet<RegEmpleado> RegEmpleados { get; set;}

         //Crear Tabla de jefes
         /// </summary> Se guardan los jefes que se den de alta, en la tabla de jefes<summary>
          public DbSet<Jefe> Jefes { get; set;}

          //Crear Tabla de tareas
          /// </summary>Se guardan las tareas que se den de alta, en la tabla de tareas<summary>
          public DbSet<Tarea> Tareas { get; set;}

         
           
    }
}