using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using STA_BD2.Models;
using System.Data;
using System.Diagnostics;

namespace STA_BD2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Clientes()
        {
            return View();
        }

        public ActionResult InsertarCliente()
        {
            string connectionString = "TuConnectionString"; // Reemplaza con tu cadena de conexión

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_InsertarCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@primerNombre", "PrimerNombre");
                    command.Parameters.AddWithValue("@segundoNombre", "SegundoNombre");
                    command.Parameters.AddWithValue("@primerApellido", "PrimerApellido");
                    command.Parameters.AddWithValue("@segundoApellido", "SegundoApellido");
                    command.Parameters.AddWithValue("@numero", "Numero");
                    command.Parameters.AddWithValue("@correo", "Correo");
                    command.Parameters.AddWithValue("@direccion", "Direccion");
                    command.Parameters.AddWithValue("@tipoClienteID", 1); 
                    command.Parameters.AddWithValue("@estadoCliente", 1);
                    command.Parameters.AddWithValue("@servicioID", 1); 
                    command.Parameters.AddWithValue("@tecnicoID", 1);
                    command.Parameters.AddWithValue("@cuentaBancariaID", 1); 

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}