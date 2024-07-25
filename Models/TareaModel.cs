using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPOO2.Models
{
    /// <summary>
    /// Modelo que representa una tarea para la vista.
    /// </summary>
    public class TareaModel
    {
        /// <summary> Constructor por defecto de la clase TareaModel.</summary>
        public TareaModel()
        {
        }

        /// <summary>Id único de la tarea. </summary>
        public Guid Id { get; set; }

        /// <summary>Título de la tarea.</summary>
        public string Title { get; set; }

        /// <summary>Descripción de la tarea.</summary>
        public string Description { get; set; }

        /// <summary>Estado actual de la tarea.</summary>
        public string Status { get; set; }

        /// <summary>Prioridad de la tarea.</summary>
        public string Priority { get; set; }

        /// <summary>Fecha de vencimiento de la tarea.</summary>
        public DateTime DueDate { get; set; }

        /// <summary>Fecha de creación de la tarea.</summary>
        public DateTime CreatedDate { get; set; }
    }
}