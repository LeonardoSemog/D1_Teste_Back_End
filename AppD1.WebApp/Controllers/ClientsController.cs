using AppD1.Models;
using AppD1.WebApp.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AppD1.WebApp.Controllers
{
    public class ClientsController : Controller
    {
        AppD1Context db;

        public ClientsController()
        {
            db = new AppD1Context();
        }

        // GET: Clients
        public ActionResult Index()
        {
            var clients = db.Clients.ToList();
            return View(clients);
        }

        public ActionResult Phones(int? clId)
        {
            return RedirectToAction("Index","Phones",new { Cid = clId == 0 ? 0 : clId});
        }

        public ActionResult Create()
        {
            ViewBag.Phones = db.Phones;
            var mdl = new ClientViewModel();
            return View(mdl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = new Client();
                client.Name = model.Name;
                client.DateOfBirth = model.DateOfBirth;
                client.Rg = model.Rg;
                client.Cpf = model.Cpf;

                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Se ocorrer um erro retorna para pagina
            ViewBag.Clients = db.Clients;
            return View(model);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.Clients = db.Clients;
            return View(client);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DateOfBith,Rg,Cpf")] Client model)
        {
            if (ModelState.IsValid)
            {
                var client = db.Clients.Find(model.Id);
                if (client == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                client.Name = model.Name;
                client.DateOfBirth = model.DateOfBirth;
                client.Rg = model.Rg;
                client.Cpf = model.Cpf;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Clients = db.Clients;
            return View(model);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoria = db.Clients.Find(client.Id).Name;
            return View(client);
        }
        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.Clients = db.Clients.Find(client.Id).Name;
            return View(client);
        }
    }
}