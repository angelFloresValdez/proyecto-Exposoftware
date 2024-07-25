using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPOO2.Entities
{
    /// <summary> Clase que representa una tarea en el sistema. </summary>
    public class Tarea
    {
        /// <summary> Id único de la tarea.</summary>
        public Guid Id { get; set; }

        /// <summary>Título de la tarea. </summary>
        public string Title { get; set; }

        /// <summary> Descripción detallada de la tarea. </summary>
        public string Description { get; set; }

        /// <summary> Estado actual de la tarea (por ejemplo, pendiente, en progreso, completada). </summary>
        public string Status { get; set; }

        /// <summary> Prioridad asignada a la tarea (por ejemplo, baja, media, alta).</summary>
        public string Priority { get; set; }

        /// <summary> Fecha límite para completar la tarea. </summary>
        public DateTime DueDate { get; set; }

        /// <summary> Fecha de creación de la tarea. </summary>
        public DateTime CreatedDate { get; set; }
    }
}