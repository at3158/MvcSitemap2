using System;
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
    public class SmUserRolesController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: SmUserRoles
        public ActionResult Index()
        {
            return View(db.SmUserRoles.ToList());
        }

        // GET: SmUserRoles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmUserRole smUserRole = db.SmUserRoles.Find(id);
            if (smUserRole == null)
            {
                return HttpNotFound();
            }
            return View(smUserRole);
        }

        // GET: SmUserRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SmUserRoles/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SmUserId,SmRoleId")] SmUserRole smUserRole)
        {
            if (ModelState.IsValid)
            {
                db.SmUserRoles.Add(smUserRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(smUserRole);
        }

        // GET: SmUserRoles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmUserRole smUserRole = db.SmUserRoles.Find(id);
            if (smUserRole == null)
            {
                return HttpNotFound();
            }
            return View(smUserRole);
        }

        // POST: SmUserRoles/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SmUserId,SmRoleId")] SmUserRole smUserRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smUserRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smUserRole);
        }

        // GET: SmUserRoles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmUserRole smUserRole = db.SmUserRoles.Find(id);
            if (smUserRole == null)
            {
                return HttpNotFound();
            }
            return View(smUserRole);
        }

        // POST: SmUserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SmUserRole smUserRole = db.SmUserRoles.Find(id);
            db.SmUserRoles.Remove(smUserRole);
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
