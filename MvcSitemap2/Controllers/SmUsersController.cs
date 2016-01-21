﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcSitemap2.Models;

namespace MvcSitemap2.Controllers
{
    public class SmUsersController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: SmUsers
        public ActionResult Index()
        {
            return View(db.SmUsers.ToList());
        }

        // GET: SmUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmUser smUser = db.SmUsers.Find(id);
            if (smUser == null)
            {
                return HttpNotFound();
            }
            return View(smUser);
        }

        // GET: SmUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SmUsers/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SmUserId,Name,AdUserId,IsEnabled")] SmUser smUser)
        {
            if (ModelState.IsValid)
            {
                db.SmUsers.Add(smUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(smUser);
        }

        // GET: SmUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmUser smUser = db.SmUsers.Find(id);
            if (smUser == null)
            {
                return HttpNotFound();
            }
            return View(smUser);
        }

        // POST: SmUsers/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SmUserId,Name,AdUserId,IsEnabled")] SmUser smUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smUser);
        }

        // GET: SmUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmUser smUser = db.SmUsers.Find(id);
            if (smUser == null)
            {
                return HttpNotFound();
            }
            return View(smUser);
        }

        // POST: SmUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SmUser smUser = db.SmUsers.Find(id);
            db.SmUsers.Remove(smUser);
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
