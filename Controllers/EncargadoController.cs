using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoFinalPOO2.Entities;
using ProyectoFinalPOO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinalPOO2.Controllers
{
    public class EncargadoController : Controller
    {
        private readonly ILogger<EncargadoController> _logger; // Logger para registrar mensajes
        private readonly ApplicationDbContext _context; // Contexto de la base de datos

        public EncargadoController(ILogger<EncargadoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Mostrar formulario de registro de empleado
        /// <summary> Muestra el formulario de registro de empleado. Recupera una lista de todos 
        /// los jefes de la base de datos y la asigna a `ViewBag.Jefes` para llenar un dropdown en la vista.</summary>
        /// <returns>La vista del formulario de registro de empleado.</returns>
        [HttpGet]
        public IActionResult RegEmpleado()
        {
            ViewBag.Jefes = _context.Jefes.ToList(); // Para llenar el dropdown de jefes
            return View();
        }

        // POST: Procesar el formulario de registro de empleado
        /// <summary> Procesa el formulario de registro de empleado.</summary>
        /// <param name="model">El modelo que contiene los datos del empleado a registrar.</param>
        /// <returns>Una acción que redirige al menú del encargado si el modelo es válido; 
        /// de lo contrario, retorna la vista de registro con los errores correspondientes.</returns>
        [HttpPost]
        public IActionResult RegEmpleado(RegEmpleadoModel model)
        {
            // Verifica si el modelo recibido es válido según las reglas de validación especificadas en el modelo.
            if (ModelState.IsValid)
            {
                // Crea una nueva instancia de RegEmpleado con los datos del modelo recibido.
                RegEmpleado empleado = new RegEmpleado
                {
                    Id = Guid.NewGuid(), // Genera un nuevo Guid para el Id del empleado.
                    NombreCompleto = model.NombreCompleto,
                    FechaEntrada = model.FechaEntrada,
                    FechaNac = model.FechaNac,
                    Nacionalidad = model.Nacionalidad,
                    EstadoCivil = model.EstadoCivil,
                    Curp = model.Curp,
                    Rfc = model.Rfc,
                    Domicilio = model.Domicilio,
                    Turno = model.Turno,
                    Jefe = model.Jefe,
                    Departamento = model.Departamento,
                };
                // Agrega el nuevo empleado a la base de datos utilizando el contexto actual
                _context.RegEmpleados.Add(empleado);
                // Guarda los cambios en la base de datos.
                _context.SaveChanges();
                // Redirige al usuario a la acción "MenuEnc" si el registro se realiza correctamente.
                return RedirectToAction("MenuEnc");
            }
            // Para llenar el dropdown de jefes en caso de error
            /// <summary> Recupera la lista de jefes y la asigna a ViewBag para llenar
            ///  el dropdown de jefes en caso de error.</summary>
            /// el ViewBag una forma flexible de pasar datos desde el controlador a la vista.
            /// <returns> La vista del formulario de registro de empleado con los datos ingresados 
            /// y los errores de validación.</returns>
            ViewBag.Jefes = _context.Jefes.ToList();
            // Si el modelo no es válido, vuelve a mostrar la vista con los datos ingresados y los errores de validación
            return View(model);

        }

        // GET: Mostrar lista de empleados
        /// <summary> Muestra una lista de los empleado</summary>
        /// <returns>La vista con la lista de empleados.</returns>
        public IActionResult ListaEmpleado()
        {
            // Consulta a la base de datos para obtener todos los empleados y mapearlos a RegEmpleadoModel.
            var empleados = _context.RegEmpleados
               .Select(e => new RegEmpleadoModel
               {
                   Id = e.Id,
                   NombreCompleto = e.NombreCompleto,
                   FechaEntrada = e.FechaEntrada,
                   FechaNac = e.FechaNac,
                   Nacionalidad = e.Nacionalidad,
                   EstadoCivil = e.EstadoCivil,
                   Curp = e.Curp,
                   Rfc = e.Rfc,
                   Domicilio = e.Domicilio,
                   Turno = e.Turno,
                   Jefe = e.Jefe,
                   Departamento = e.Departamento,
               }).ToList();
            // Retorna la vista "ListaEmpleado" con la lista de empleados para mostrar en la interfaz.
            return View(empleados);

        }

        // GET: Mostrar formulario de edición de empleado
        /// <summary> Muestra el formulario de edición de un empleado específico.</summary>
        /// <param name="id"> El ID del empleado a editar.</param>
        /// <returns>La vista del formulario de edición del empleado.</returns>
        public IActionResult EmpleadoEdit(Guid id)
        { // Recupera el empleado desde la base de datos usando el ID proporcionado
            var empleado = _context.RegEmpleados.FirstOrDefault(e => e.Id == id);
            // Si no se encuentra el empleado, redirige al menú principal
            if (empleado == null)
            {
                return RedirectToAction("MenuEnc");
            }
            // Crea un modelo de vista con los datos del empleado
            var model = new RegEmpleadoModel
            {
                Id = empleado.Id,
                NombreCompleto = empleado.NombreCompleto,
                FechaEntrada = empleado.FechaEntrada,
                FechaNac = empleado.FechaNac,
                Nacionalidad = empleado.Nacionalidad,
                EstadoCivil = empleado.EstadoCivil,
                Curp = empleado.Curp,
                Rfc = empleado.Rfc,
                Domicilio = empleado.Domicilio,
                Turno = empleado.Turno,
                Jefe = empleado.Jefe,
                Departamento = empleado.Departamento,
            };
            // Para llenar el dropdown de jefes
            /// <summary> Llena el dropdown de jefes con la lista de encargados disponibles en la base de datos.</summary>
            /// <returns>La vista con el modelo de datos actualizado, incluyendo la lista de jefes.</returns>
            ViewBag.Jefes = _context.Jefes.ToList();
            return View(model);
        }

        // POST: Procesar el formulario de edición de empleado
        /// <summary> Procesa la solicitud POST para actualizar los datos de un empleado en la base de datos.</summary>
        /// <param name="model">El modelo de datos actualizado del empleado.</param>
        /// <returns>Redirige al menú principal si la operación es exitosa, o muestra el formulario de edición 
        /// nuevamente si hay errores.</returns>
        [HttpPost]
        public IActionResult EmpleadoEdit(RegEmpleadoModel model)
        {
            // Verifica si el modelo recibido cumple con las reglas de validación definidas en RegEmpleadoModel.
            if (ModelState.IsValid)
            {
                // Busca al empleado en la base de datos por su Id.
                var empleado = _context.RegEmpleados.FirstOrDefault(e => e.Id == model.Id);
                if (empleado != null)
                {
                    // Actualiza los datos del empleado con los datos del modelo recibido.
                    empleado.NombreCompleto = model.NombreCompleto;
                    empleado.FechaEntrada = model.FechaEntrada;
                    empleado.FechaNac = model.FechaNac;
                    empleado.Nacionalidad = model.Nacionalidad;
                    empleado.EstadoCivil = model.EstadoCivil;
                    empleado.Curp = model.Curp;
                    empleado.Rfc = model.Rfc;
                    empleado.Domicilio = model.Domicilio;
                    empleado.Turno = model.Turno;
                    empleado.Jefe = model.Jefe;
                    empleado.Departamento = model.Departamento;
                    // Guarda los cambios realizados en la base de datos.
                    _context.SaveChanges();
                    // Redirige al usuario al menú principal después de editar el empleado exitosamente.
                    return RedirectToAction("MenuEnc");
                }
            }
            // Para llenar el dropdown de jefes en caso de error
            /// <summary> Llena el dropdown de jefes con la lista de encargados disponibles en la base de datos </summary>
            /// <returns>La vista de formulario de edición de empleado con el modelo actualizado, incluyendo 
            /// la lista de jefes.</returns>
            ViewBag.Jefes = _context.Jefes.ToList();
            return View(model);
        }

        // GET: Mostrar detalles de empleado para eliminar
        /// <summary> Muestra los detalles de un empleado antes de proceder con su eliminación.</summary>
        /// <param name="id">El ID del empleado a mostrar.</param>
        /// <returns>La vista con los detalles del empleado especificado o redirige al menú principal si no
        ///  se encuentra.</returns>
        public IActionResult EmpleadoShowToDelete(Guid id)
        {
            // Busca al empleado en la base de datos usando su ID
            var empleado = _context.RegEmpleados.FirstOrDefault(e => e.Id == id);
            // Si el empleado no se encuentra, redirige al menú principal
            if (empleado == null)
            {
                return RedirectToAction("MenuEnc");
            }
            // Crea un modelo de vista con los detalles del empleado encontrado
            var model = new RegEmpleadoModel
            {
                Id = empleado.Id,
                NombreCompleto = empleado.NombreCompleto,
                FechaEntrada = empleado.FechaEntrada,
                FechaNac = empleado.FechaNac,
                Nacionalidad = empleado.Nacionalidad,
                EstadoCivil = empleado.EstadoCivil,
                Curp = empleado.Curp,
                Rfc = empleado.Rfc,
                Domicilio = empleado.Domicilio,
                Turno = empleado.Turno,
                Jefe = empleado.Jefe,
                Departamento = empleado.Departamento,
            };
            // Retorna la vista con los detalles del empleado
            return View(model);
        }

        // POST: Eliminar empleado
        /// <summary> Elimina un empleado específico de la base de datos.</summary>
        /// <param name="id">El ID del empleado a eliminar.</param>
        /// <returns>Redirige al menú principal después de eliminar el empleado.</returns>
        [HttpPost]
        public IActionResult RegEmpleadoDelete(Guid id)
        {
            // Busca al empleado en la base de datos usando su ID
            var empleado = _context.RegEmpleados.FirstOrDefault(e => e.Id == id);
            // Si el empleado existe, procede a eliminarlo
            if (empleado != null)
            {
                _context.RegEmpleados.Remove(empleado);
                _context.SaveChanges();// Guarda los cambios en la base de datos
            }
            // Redirige al usuario al menú principal
            return RedirectToAction("MenuEnc");
        }
        // métodos del controlador, como Menú de Encargado y Asignar Tarea
        /// <summary>Muestra el menú principal del encargado. </summary>
        /// <returns>La vista del menú principal del encargado.</returns>

        public IActionResult MenuEnc()
        {
            return View();
        }


        //Listado de Jefes
        /// <summary> Muestra un listado de todos los jefes registrados en la base de datos.</summary>
        /// <returns>La vista con el listado de jefes.</returns>
        public IActionResult JefesLis()
        {
            // Obtiene una lista de todos los jefes transformados a JefeModel
            List<JefeModel> list = _context.Jefes.Select(c => new JefeModel
            {
                Id = c.Id,
                NombreJefe = c.NombreJefe,
                Departamento = c.Departamento,
                Sueldo = c.Sueldo
            }).ToList();
            // Retorna la vista con el listado de jefes
            return View(list);
        }
        // GET: Editar jefe
        /// <summary>Muestra el formulario de edición de un jefe según su ID.</summary>
        /// <param name="id">El ID del jefe que se desea editar.</param>
        /// <returns>La vista con el formulario de edición del jefe.</returns> 
        public IActionResult JefesEdit(Guid id)
        {
            // Busca al jefe en la base de datos usando su ID
            var jefe = _context.Jefes.FirstOrDefault(p => p.Id == id);
            // Si el jefe no se encuentra, redirige al menú principal
            if (jefe == null)
            {
                return RedirectToAction("MenuEnc");
            }
            // Crea un objeto JefeModel con los datos del jefe encontrado
            var model = new JefeModel
            {
                Id = jefe.Id,
                NombreJefe = jefe.NombreJefe,
                Departamento = jefe.Departamento,
                Sueldo = jefe.Sueldo
            };
            // Retorna la vista con el formulario de edición del jefe
            return View(model);
        }

        [HttpPost]
        //Post de editar jefe
        /// <summary>Procesa la solicitud para editar los datos de un jefe.</summary>
        /// <param name="model">El modelo con los datos actualizados del jefe.</param>
        /// <returns>Redirige al menú principal si la operación fue exitosa, de lo contrario,
        ///  muestra nuevamente el formulario de edición con errores de validación.</returns>
        public IActionResult JefesEdit(JefeModel model)
        {
            // Verifica si el modelo recibido es válido según las reglas de validación definidas en JefeModel
            if (ModelState.IsValid)
            {
                // Busca al jefe en la base de datos utilizando su ID
                var jefe = _context.Jefes.FirstOrDefault(p => p.Id == model.Id);
                if (jefe != null)
                {
                    // Actualiza los datos del jefe con los valores del modelo recibido
                    jefe.NombreJefe = model.NombreJefe;
                    jefe.Departamento = model.Departamento;
                    jefe.Sueldo = model.Sueldo;
                    _context.SaveChanges();// Guarda los cambios en la base de datos
                    return RedirectToAction("MenuEnc");// Redirige al menú principal después de editar exitosamente al jefe
                }
            }
            // Si el modelo no es válido o no se encontró el jefe, vuelve a mostrar el formulario de edición con el modelo y los errores de validación
            return View(model);
        }

        //Agregar un jefe nuevo
        /// <summary>Muestra el formulario para agregar un nuevo jefe. </summary>
        /// <returns>La vista con el formulario de registro de nuevo jefe.</returns> 
        public IActionResult JefesAdd()
        {
            return View();
        }

        [HttpPost]
        //post para añadir jefe 
        /// <summary>Procesa la solicitud para añadir un nuevo jefe a la base de datos.</summary>
        /// <param name="model">El modelo con los datos del nuevo jefe a añadir.</param>
        /// <returns>Redirige al menú principal si la operación fue exitosa, de lo contrario,
        ///  muestra nuevamente el formulario de registro con errores de validación.</returns>
        public IActionResult JefesAdd(JefeModel model)
        {
            // Verifica si el modelo recibido es válido según las reglas de validación definidas en JefeModel
            if (ModelState.IsValid)
            {
                // Crea una nueva instancia de Jefe con los datos del modelo recibido
                Jefe jefe = new Jefe
                {
                    Id = Guid.NewGuid(),
                    NombreJefe = model.NombreJefe,
                    Departamento = model.Departamento,
                    Sueldo = model.Sueldo
                };
                // Añade el nuevo jefe a la base de datos y guarda los cambios
                _context.Jefes.Add(jefe);
                _context.SaveChanges();
                // Redirige al menú principal después de añadir exitosamente al jefe
                return RedirectToAction("MenuEnc");
            }
            // Si el modelo no es válido, vuelve a mostrar el formulario de registro con el modelo
            // y los errores de validación
            return View(model);
        }

        // GET: Mostrar detalles de jefe para eliminar
        /// <summary>Muestra los detalles de un jefe específico para preparar su eliminación.</summary>
        /// <param name="id">El identificador único del jefe que se desea eliminar.</param>
        /// <returns>Vista con los detalles del jefe si se encuentra, o redirige al menú principal 
        /// si no se encuentra el jefe.</returns>
        public IActionResult JefeShowToDelete(Guid id)
        {
            // Busca el jefe en la base de datos por su Id
            var jefe = _context.Jefes.FirstOrDefault(p => p.Id == id);
            // Si no se encuentra el jefe, redirige al menú principal
            if (jefe == null)
            {
                return RedirectToAction("MenuEnc");
            }
            // Crea un modelo con los datos del jefe encontrado
            var model = new JefeModel
            {
                Id = jefe.Id,
                NombreJefe = jefe.NombreJefe,
                Departamento = jefe.Departamento,
                Sueldo = jefe.Sueldo
            };
            // Retorna la vista con los detalles del jefe encontrado
            return View(model);
        }
        // POST: Eliminar jefe
        /// <summary> Elimina un jefe específico de la base de datos.</summary>
        /// <param name="id">El identificador único del jefe que se desea eliminar.</param>
        /// <returns>Redirige al menú principal después de eliminar el jefe, si existe.</returns>
        [HttpPost]
        public IActionResult JefeDelete(Guid id)
        {
            // Busca el jefe en la base de datos por su Id
            var jefe = _context.Jefes.FirstOrDefault(p => p.Id == id);
            // Si se encuentra el jefe, procede a eliminarlo
            if (jefe != null)
            {

                _context.Jefes.Remove(jefe);// Elimina el jefe de la base de datos
                _context.SaveChanges();  // Guarda los cambios en la base de datos
            }
            // Redirige al menú principal después de eliminar el jefe
            return RedirectToAction("MenuEnc");
        }

        //---------------------------------------------------------------------------\\

        // GET: Mostrar formulario de nueva tarea
        /// <summary>Muestra el formulario para crear una nueva tarea.</summary>
        /// <returns>La vista del formulario de nueva tarea.</returns>
        public IActionResult NuevaTarea()
        {
            return View();
        }

        // POST: Crear nueva tarea
        /// <summary>Crea una nueva tarea basada en los datos proporcionados en el modelo.</summary>
        /// <param name="model">El modelo que contiene los datos de la tarea a crear.</param>
        /// <returns>Redirige a la acción "MenuEnc" si la tarea se crea correctamente; de lo contrario,
        ///  vuelve a mostrar el formulario de nueva tarea con errores de validación.</returns>
        [HttpPost]
        public IActionResult CrearTarea(TareaModel model)
        {
            // Verifica si el modelo recibido cumple con las reglas de validación definidas en TareaModel.
            if (ModelState.IsValid)
            {
                // Crea una nueva instancia de Tarea con los datos del modelo.
                var tarea = new Tarea
                {
                    Id = Guid.NewGuid(),
                    Title = model.Title,
                    Description = model.Description,
                    Status = model.Status,
                    Priority = model.Priority,
                    DueDate = model.DueDate,
                    CreatedDate = DateTime.Now
                };
                // Agrega la nueva tarea a DbSet<Tarea> en el contexto de la base de datos.
                _context.Tareas.Add(tarea);
                // Guarda los cambios realizados en la base de datos.
                _context.SaveChanges();
                // Redirige al usuario a la acción "MenuEnc" después de crear la tarea exitosamente.
                return RedirectToAction("MenuEnc");
            }
            // Si hay errores de validación, vuelve a mostrar el formulario de nueva tarea con 
            //el modelo actual para corregirlos.
            return View("NuevaTarea", model);
        }

        // GET: Mostrar lista de tareas en AsignarTarea
        /// <summary>Muestra la lista de tareas disponibles para asignar.</summary>
        /// <returns>Vista que muestra la lista de tareas disponibles para asignar.</returns>
        public IActionResult AsignarTarea()
        {
            // Consulta las tareas disponibles en la base de datos y las mapea al modelo TareaModel
            var tareas = _context.Tareas.Select(t => new TareaModel
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Status = t.Status,
                Priority = t.Priority,
                DueDate = t.DueDate,
                CreatedDate = t.CreatedDate
            }).ToList();
            // Retorna la vista con la lista de tareas
            return View(tareas);
        }

        // GET: Mostrar formulario de edición de tarea
        /// <summary>Muestra el formulario de edición de una tarea específica.</summary>
        /// <param name="id">Identificador único de la tarea a editar.</param>
        /// <returns>Vista que muestra el formulario de edición de la tarea.</returns>
        public IActionResult TareaEdit(Guid id)
        {
            // Busca la tarea en la base de datos por su Id
            var tarea = _context.Tareas.FirstOrDefault(t => t.Id == id);
            if (tarea == null)
            {
                // Si no se encuentra la tarea, redirecciona al menú del encargado
                return RedirectToAction("MenuEnc");
            }
            // Crea un modelo de tarea para pasar a la vista de edición
            var model = new TareaModel
            {
                Id = tarea.Id,
                Title = tarea.Title,
                Description = tarea.Description,
                Status = tarea.Status,
                Priority = tarea.Priority,
                DueDate = tarea.DueDate,
                CreatedDate = tarea.CreatedDate
            };
            // Retorna la vista con el modelo de tarea para edición
            return View(model);
        }

        // POST: Procesar el formulario de edición de tarea
        /// <summary>Procesa la solicitud de edición de una tarea.</summary>
        /// <param name="model">Datos de la tarea a editar.</param>
        /// <returns>Redirige al menú del encargado si la edición es exitosa;
        ///  de lo contrario, muestra el formulario de edición nuevamente.</returns>
        [HttpPost]
        public IActionResult TareaEdit(TareaModel model)
        {
            if (ModelState.IsValid)
            {
                // Busca la tarea en la base de datos por su Id
                var tarea = _context.Tareas.FirstOrDefault(t => t.Id == model.Id);
                if (tarea != null)
                {
                    // Actualiza los datos de la tarea con los nuevos valores del modelo
                    tarea.Title = model.Title;
                    tarea.Description = model.Description;
                    tarea.Status = model.Status;
                    tarea.Priority = model.Priority;
                    tarea.DueDate = model.DueDate;
                    // Guarda los cambios en la base de datos
                    _context.SaveChanges();
                    // Redirige al menú del encargado después de la edición exitosa
                    return RedirectToAction("MenuEnc");
                }
            }
            // Si hay errores de validación o la tarea no se encontró, muestra el formulario 
            //de edición nuevamente con el modelo actual.
            return View(model);
        }

        // GET: Mostrar detalles de tarea para eliminar
        /// <summary> Muestra los detalles de una tarea para confirmar su eliminación.</summary>
        /// <param name="id">Id de la tarea a mostrar.</param>
        /// <returns>Vista con los detalles de la tarea.</returns>
        public IActionResult TareaShowToDelete(Guid id)
        {
            // busca la tarea en la base de datos utilizando su Id.
            var tarea = _context.Tareas.FirstOrDefault(t => t.Id == id);
            //Si no existe, redirige al usuario de vuelta a la vista AsignarTarea.
            if (tarea == null)
            {
                return RedirectToAction("AsignarTarea");
            }

            //Si la tarea existe, crea un objeto TareaModel con los detalles de la tarea encontrada 
            var model = new TareaModel
            {
                Id = tarea.Id,
                Title = tarea.Title,
                Description = tarea.Description,
                Status = tarea.Status,
                Priority = tarea.Priority,
                DueDate = tarea.DueDate,
                CreatedDate = tarea.CreatedDate
            };
            //Devuelve una vista que muestra los detalles de la tarea utilizando el modelo creado.
            return View(model);
        }

        // POST: Eliminar tarea
        /// <summary>Elimina una tarea específica de la base de datos. </summary>
        /// <param name="id">Id de la tarea a eliminar.</param>
        /// <returns>Redirección a la acción MenuEnc.</returns>
        [HttpPost]
        public IActionResult TareaDelete(Guid id)
        {
            // Busca la tarea en la base de datos utilizando el Id proporcionado.
            var tarea = _context.Tareas.FirstOrDefault(t => t.Id == id);
            // Verifica si se encontró la tarea en la base de datos.
            if (tarea != null)
            {
                // Elimina la tarea de la base de datos.
                _context.Tareas.Remove(tarea);
                // Guarda los cambios en la base de datos.
                _context.SaveChanges();
            }
            // Redirige al usuario de vuelta a la página principal o a la vista deseada.
            return RedirectToAction("MenuEnc");
        }
    }
}