using Group3_Sis.Data;
using Group3_Sis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group3_Sis.Controllers
{
    public class StudentController : Controller
    {
        private Konteksti _konteksti;
        public StudentController(Konteksti kon)
        {
            _konteksti = kon;
        }
        public IActionResult Listo()
        {
           List<Studenti> studentet= _konteksti.Studentet.ToList();
           var komunat=_konteksti.Komunat.ToList();
           var profesoret = _konteksti.Profesoret.ToList();

            return View(studentet);
        }
    }
}
