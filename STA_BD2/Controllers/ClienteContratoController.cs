using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using STA_BD2.Models;

namespace STA_BD2.Controllers
{
    public class ClienteContratoController : Controller
    {
        private readonly DB20182030092Context _context;

        public ClienteContratoController(DB20182030092Context context)
        {
                _context = context;
        }

        public IActionResult ObtenerContratos()
        {
            var clienteContrato = _context.VwClientesContratos.ToList();
            return View(clienteContrato);
        }

        public IActionResult AgregarClientePaquete()
        {
            var viewModel = new ClienteContratoViewModel();
            //viewModel.ListaCuentasBancarias = _context.CuentaBancaria.ToList();
            return View(viewModel);
        }

        public IActionResult InsertarClientePaquete(ClienteContratoViewModel model)
        {

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                _context.Database.ExecuteSqlRaw("EXEC sp_InsertarClientePaquete @primerNombre, @segundoNombre, @primerApellido, @segundoApellido, @numero, @correo, @direccion, @tipoClienteID, @paqueteID, @tecnicoID, @cuentaBancariaID, @fechaInicio, @fechaFinal",
                                    new SqlParameter("@primerNombre", model.PrimerNombre),
                                    new SqlParameter("@segundoNombre", model.SegundoNombre),
                                    new SqlParameter("@primerApellido", model.PrimerApellido),
                                    new SqlParameter("@segundoApellido", model.SegundoApellido),
                                    new SqlParameter("@numero", model.Numero),
                                    new SqlParameter("@correo", model.Correo),
                                    new SqlParameter("@direccion", model.Direccion),
                                    new SqlParameter("@tipoClienteID", model.TipoClienteId),
                                    new SqlParameter("@paqueteID", model.PaqueteId),
                                    new SqlParameter("@tecnicoID", model.TecnicoId),
                                    new SqlParameter("@cuentaBancariaID", model.CuentaBancariaId),
                                    new SqlParameter("@fechaInicio", model.FechaInicio),
                                    new SqlParameter("@fechaFinal", model.FechaFinal)
                                );

                _context.SaveChanges();

                transaction.Commit();
                TempData["Mensaje"] = "Insertado correctamente";

                return RedirectToAction("ObtenerContratos");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("ObtenerContratos");
            }
        }
    }
}
