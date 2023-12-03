using Microsoft.AspNetCore.Mvc;
using STA_BD2.Models;

namespace STA_BD2.Controllers
{
	public class PrecioPaqueteController : Controller
	{
		private readonly DB20182030092Context _context;

        public PrecioPaqueteController(DB20182030092Context context)
        {
			_context = context;
        }

        public IActionResult ObtenerPrecioPaquete()
		{
		 var precioPaqeute = _context.VwPreciopaquetes.ToList();
		return View(precioPaqeute);
		}
	}
}
