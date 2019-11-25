using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppD1.Models;
using AppD1.WebApp.Models;

namespace AppD1.WebApp.Controllers
{
    public class PhonesController : Controller
    {
        private int parId { get; set; }

        private AppD1Context db = new AppD1Context();


        // GET: Phones
        public ActionResult Index(List<PhoneViewModel> filterList,  int? cid)
        {
            if (cid == null)
            {
                if(parId != 0)
                {
                    cid = parId;
                }
            }
            var listPhone = db.Phones
                .Where(c => c.ClientId == cid)
                .ToList();

            ViewBag.Client = db.Clients.Find(cid);
            return View(listPhone);
        }



        // GET: Phones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // GET: Phones/Create
        public ActionResult Create(Int32 Cid)
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name");
            return View(ViewBag.ClientId);
        }

        // POST: Phones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PhoneTypeId,PhoneNumber,ClientId")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Phones.Add(phone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", phone.ClientId);
            return View(phone);
        }

        // GET: Phones/Edit/5
        public ActionResult Edit(int? id,int cId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", phone.ClientId);
            parId = phone.ClientId;
            return View(phone);
        }

        // POST: Phones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PhoneTypeId,PhoneNumber,ClientId")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index",new { cId = phone.ClientId });
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", phone.ClientId);
            parId = phone.ClientId;

            return View(phone);
        }

        // GET: Phones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phones.Find(id);
            parId = phone.ClientId;

            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phone phone = db.Phones.Find(id);
            parId = phone.ClientId;

            db.Phones.Remove(phone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
