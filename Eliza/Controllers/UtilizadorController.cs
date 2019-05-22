using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Eliza.Models;

namespace Eliza.Controllers
{
    public class UtilizadorController : Controller
    {
        private BaseDados db = new BaseDados();


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var users = (from u in db.Utilizador
                            where u.email == email && u.password == password
                            select u);


                if (users.ToList<Utilizador>().Count() > 0)
                {
                    Utilizador user = users.ToList<Utilizador>().ElementAt<Utilizador>(0);
                    FormsAuthentication.SetAuthCookie(user.email, false);
                    return RedirectToAction("Index", "Utilizador");
                }
                else
                {
                    ModelState.AddModelError("", "Login Incorreto");
                }
            }
            return View();
        }
        // GET: Utilizador
        public ActionResult Index()
        {
            return View(db.Utilizador.ToList());

        }

        // GET: Utilizador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizador.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        // GET: Utilizador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilizador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUtilizador,email,nome,rua,cidade,porta,cod_postal,intolerancias,password")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                db.Utilizador.Add(utilizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilizador);
        }

        // GET: Utilizador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizador.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        // POST: Utilizador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUtilizador,email,nome,rua,cidade,porta,cod_postal,intolerancias,password")] Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilizador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utilizador);
        }

        // GET: Utilizador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizador.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        // POST: Utilizador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilizador utilizador = db.Utilizador.Find(id);
            db.Utilizador.Remove(utilizador);
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
