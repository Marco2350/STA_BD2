using Microsoft.AspNetCore.Mvc;
using STA_BD2.Models;

namespace STA_BD2.Controllers
{
    public class AsignacionesController : Controller
    {
        private readonly DB20182030092Context _context;

        public AsignacionesController(DB20182030092Context context)
        {
                _context = context;
        }
        public IActionResult ObtenerAsignaciones()
        {
            var vistaAsignaciones = _context.VwAsigancionesTecnicos.ToList();
            return View(vistaAsignaciones);
        }
    }
}
