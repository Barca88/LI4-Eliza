﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Eliza.Models;

namespace Eliza.Controllers
{
    public class IngredientesController : Controller
    {
        private BaseDados db = new BaseDados();

        // GET: Ingredientes
        public ActionResult Index()
        {
            return View(db.Ingrediente.ToList());
        }

        // GET: Ingredientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediente ingrediente = db.Ingrediente.Find(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        // GET: Ingredientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idIngrediente,nome,descrição,tipo")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                db.Ingrediente.Add(ingrediente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingrediente);
        }

        // GET: Ingredientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediente ingrediente = db.Ingrediente.Find(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        // POST: Ingredientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idIngrediente,nome,descrição,tipo")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingrediente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingrediente);
        }

        // GET: Ingredientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediente ingrediente = db.Ingrediente.Find(id);
            if (ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(ingrediente);
        }

        // POST: Ingredientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingrediente ingrediente = db.Ingrediente.Find(id);
            db.Ingrediente.Remove(ingrediente);
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
