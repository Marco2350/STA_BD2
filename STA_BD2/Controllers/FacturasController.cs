using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STA_BD2.Models;

namespace STA_BD2.Controllers
{
    public class FacturasController : Controller
    {
        private readonly DB20182030092Context _context;

        public FacturasController(DB20182030092Context context)
        {
            _context = context;
        }

        public ActionResult ObtenerFacturas()
        {
            var vistaFactura = _context.VwFacturas.ToList();
            return View(vistaFactura);
        }
    }
}
