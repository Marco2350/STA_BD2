using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using STA_BD2.Models;

namespace STA_BD2.Controllers
{
    public class ClienteController : Controller
    {
        private readonly DB20182030092Context _context;

        public ClienteController(DB20182030092Context context)
        {
            _context = context;
        }

		public IActionResult ObtenerClientes()
		{
			var vistaClientes = _context.Clientes.ToList();
			return View(vistaClientes);
		}

		public IActionResult AgregarCliente()
        {
            var cliente = new Cliente
            {
                TipoClienteId = 1,
                EstadoCliente = 1,
            };

            return View(cliente);
        }

        public IActionResult EditarCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View("EditarCliente", cliente);
        }

		[HttpPost]
		public IActionResult ActualizarCliente(Cliente cliente)
		{


			using var transaction = _context.Database.BeginTransaction();

				try
				{
				if (cliente.TipoClienteId != null)
				{
                    new SqlParameter("@tipoClienteID", cliente.TipoClienteId);

			    }
				_context.Database.ExecuteSqlRaw("EXEC sp_ActualizarCliente @clienteID, @primerNombre, @segundoNombre, @primerApellido, @segundoApellido, @numero, @correo, @direccion, @tipoClienteID",
						new SqlParameter("@clienteID", cliente.ClienteId),
						new SqlParameter("@primerNombre", cliente.PrimerNombre),
						new SqlParameter("@segundoNombre", cliente.SegundoNombre),
						new SqlParameter("@primerApellido", cliente.PrimerApellido),
						new SqlParameter("@segundoApellido", cliente.SegundoApellido),
						new SqlParameter("@numero", cliente.Numero),
						new SqlParameter("@correo", cliente.Correo),
						new SqlParameter("@direccion", cliente.Direccion),
						new SqlParameter("@tipoClienteID", cliente.TipoClienteId)
					);

					transaction.Commit();
					TempData["Mensaje"] = "Cliente actualizado correctamente";
					return RedirectToAction("ObtenerClientes");
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					TempData["Error"] = "Error al actualizar el cliente";
					return RedirectToAction("ObtenerClientes");
				}
		}

        [HttpPost]
        public IActionResult InsertarCliente(Cliente cliente)
        {

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                _context.Database.ExecuteSqlRaw("EXEC sp_InsertarCliente @primerNombre, @segundoNombre, @primerApellido, @segundoApellido, @numero, @correo, @direccion, @tipoClienteID, @estadoCliente ",
                    new SqlParameter("@primerNombre", cliente.PrimerNombre),
                    new SqlParameter("@segundoNombre", cliente.SegundoNombre),
                    new SqlParameter("@primerApellido", cliente.PrimerApellido),
                    new SqlParameter("@segundoApellido", cliente.SegundoApellido),
                    new SqlParameter("@numero", cliente.Numero),
                    new SqlParameter("@correo", cliente.Correo),
                    new SqlParameter("@direccion", cliente.Direccion),
                    new SqlParameter("@tipoClienteID", cliente.TipoClienteId),
                    new SqlParameter("@estadoCliente", cliente.EstadoCliente)
                );

                _context.SaveChanges();

                transaction.Commit();
                TempData["Mensaje"] = "Cliente insertado correctamente";

                return RedirectToAction("ObtenerClientes");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                TempData["Error"] = "Error al insertar el cliente";
                return RedirectToAction("ObtenerClientes");
            }
        }



        [HttpPost]
        public IActionResult EliminarCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            TempData["Mensaje"] = "Cliente eliminado correctamente";

            return RedirectToAction("ObtenerClientes");
        }

    }
}
