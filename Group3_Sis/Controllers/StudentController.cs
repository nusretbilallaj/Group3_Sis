﻿using Group3_Sis.Data;
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

        private List<SelectListItem> ListoKomunat()
        {
            List<Komuna> komunat = _konteksti.Komunat.ToList();
            List<SelectListItem> lista = new List<SelectListItem>();
            foreach (var kom in komunat)
            {
                SelectListItem obj = new SelectListItem();
                obj.Text = kom.Emri;
                obj.Value = kom.Id.ToString();
                lista.Add(obj);
            }

            return lista;
        }

        public IActionResult Krijo()
        {
            ViewBag.Komunat = ListoKomunat();
            return View();
        }

        [HttpPost]
        public IActionResult Krijo(Studenti studenti)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Studentet.Add(studenti);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
            }
            else
            {
                ViewBag.Komunat = ListoKomunat();
                return View(studenti);
            }

        }

        public IActionResult Ndrysho(int? id)
        {
            return View();
        }

    }
}


