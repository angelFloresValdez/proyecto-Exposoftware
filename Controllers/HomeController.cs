using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoFinalPOO2.Entities;
using ProyectoFinalPOO2.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace ProyectoFinalPOO2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;  // Logger para registrar mensajes
        private readonly ApplicationDbContext _context;     // Contexto de la base de datos

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Acción para la vista Index
        /// <summary> Muestra la vista principal de la página web. </summary>
        /// <returns>La vista Index.</returns>
        public IActionResult Index() => View();

        // Acción para la vista Privacy
        /// <summary>Muestra la política de privacidad de la página web.</summary>
        /// <returns>La vista Privacy.</returns>
        public IActionResult Privacy() => View();

        // Acción para la vista Contacto
        /// <summary>Muestra la página de contacto para que los usuarios puedan comunicarse.</summary>
        /// <returns>La vista Contacto.</returns>
        public IActionResult Contacto() => View();

        // Acción para la vista Servicios
        /// <summary>Muestra la página de servicios ofrecidos por la organización.</summary>
        /// <returns>La vista Servicios.</returns>
        public IActionResult Servicios() => View();

        // Acción para la vista IniciarSesion (GET)
        /// <summary>Muestra el formulario de inicio de sesión para que los usuarios puedan acceder.</summary>
        /// <returns>La vista IniciarSesion.</returns>
        public IActionResult IniciarSesion() => View();

        //-----------------------------------------------------------------------------------

        // Acción para procesar el inicio de sesión (POST)
        /// <summary> Procesa la solicitud POST para iniciar sesión con las credenciales proporcionadas.</summary>
        /// <param name="correo">El correo electrónico del encargado.</param>
        /// <param name="contraseña">La contraseña del encargado.</param>
        /// <returns>Redirige al menú del encargado si las credenciales son válidas; de lo contrario,
        /// muestra un mensaje de error y vuelve a la vista de inicio de sesión.</returns>
        [HttpPost]
        public IActionResult IniciarSesionPost(string correo, string contraseña)
        {
            // Verifica si las credenciales son válidas
            if (EsValido(correo, contraseña))
            {
                // Redirecciona al menú del encargado si las credenciales son correctas
                return RedirectToAction("MenuEnc", "Encargado");
            }

            // Si las credenciales no son válidas, muestra un mensaje de error y vuelve a la vista de inicio de sesión
            ViewBag.Error = "Credenciales inválidas. Por favor, intenta de nuevo.";
            return View("IniciarSesion");
        }

        // Método para validar las credenciales del encargado
        private bool EsValido(string correoEnc, string contraseñaEnc)
        {
            // Busca en la base de datos si existe un encargado con el correo y contraseña proporcionados
            var encargado = _context.LoginEncargados
                .FirstOrDefault(e => e.CorreoEnc == correoEnc && e.ContraseñaEnc == contraseñaEnc);

            return encargado != null; // Devuelve true si encontró un encargado válido, false si no
        }

        // Acción para mostrar la vista de creación de cuenta (GET)
        /// <summary>Muestra la vista de creación de cuenta para registrar un nuevo encargado.</summary>
        /// <returns>La vista de creación de cuenta.</returns> 
        [HttpGet]
        public IActionResult CrearCuenta() => View();

        // Acción para procesar la creación de cuenta (POST)
        /// <summary>Procesa el formulario de creación de cuenta para registrar un nuevo encargado.</summary>
        /// <param name="model">El modelo que contiene los datos de la cuenta a registrar.</param>
        /// <returns> Redirige a la vista de creación de cuenta si el registro es exitoso;
        /// de lo contrario, vuelve a mostrar el formulario con errores de validación.</returns>
        [HttpPost]
        public IActionResult CrearCuenta(LoginEncargadoModel model)
        {
            if (ModelState.IsValid)
            {
                // Crea un nuevo registro de encargado con los datos del modelo y lo guarda en la base de datos
                var reg = new LoginEncargado
                {
                    Id = Guid.NewGuid(),
                    CorreoEnc = model.CorreoEnc,
                    ContraseñaEnc = model.ContraseñaEnc,
                };

                _context.LoginEncargados.Add(reg);
                _context.SaveChanges();

                // Redirecciona a la vista de creación de cuenta después de guardar exitosamente
                return RedirectToAction("CrearCuenta", "Home");
            }

            // Si el modelo no es válido, vuelve a mostrar la vista de creación de cuenta con el modelo
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
