using Group3_Sis.Data;
using Group3_Sis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult Krijo()
        {
           var komunat= _konteksti.Komunat.ToList();
           var lista = new List<SelectListItem>();
           foreach (var item in komunat)
           {
               var obj = new SelectListItem();
               obj.Text = item.Emri;
               obj.Value = item.Id.ToString();
               lista.Add(obj);
           }

           ViewBag.Komunat = lista;
            return View();
        }
    }
}
