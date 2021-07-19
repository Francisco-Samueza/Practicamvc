using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practicamvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicamvc.Controllers
{
    public class APersonasController : Controller
    {
        // GET: APersonasController
        public ActionResult Index()
        {
            List<Datospersona> lstdatospersona = new List<Datospersona>();
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Listapersona")))
            { 
                Datospersona Dpersona = new Datospersona();
                Dpersona.Nombre = "Francisco Samueza";
                Dpersona.Cedula = "1755122858";
                Dpersona.Ciudad = "Quito";
                Dpersona.Direccion = "Calderón";
                for (int i = 0; i < 5; i++)
                {
                    lstdatospersona.Add(Dpersona);
                }
            }
            else
            {
                lstdatospersona = JsonConvert.DeserializeObject<List<Datospersona>>(HttpContext.Session.GetString("Listapersona"));
            }
            HttpContext.Session.SetString("ListaPersona", JsonConvert.SerializeObject(lstdatospersona));
            return View(lstdatospersona);
        }

        // GET: APersonasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: APersonasController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: APersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Datospersona datospersona)
        {
            try
            {
                List<Datospersona> lstdatospersona = new List<Datospersona>();
                lstdatospersona = JsonConvert.DeserializeObject<List<Datospersona>>(HttpContext.Session.GetString("Listapersona"));
                lstdatospersona.Add(datospersona);
                HttpContext.Session.SetString("ListaPersona", JsonConvert.SerializeObject(lstdatospersona));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();  
            }
            }   

        // GET: APersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: APersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: APersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: APersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
