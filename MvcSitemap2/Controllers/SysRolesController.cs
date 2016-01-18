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
    public class SysRolesController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: SysRoles
        public ActionResult Index()
        {
            return View(db.SysRoles.ToList());
        }

        // GET: SysRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysRole sysRole = db.SysRoles.Find(id);
            if (sysRole == null)
            {
                return HttpNotFound();
            }
            return View(sysRole);
        }

        // GET: SysRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SysRoles/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SysRoleId,Name,IsEnabled")] SysRole sysRole)
        {
            if (ModelState.IsValid)
            {
                db.SysRoles.Add(sysRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sysRole);
        }

        // GET: SysRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysRole sysRole = db.SysRoles.Find(id);
            if (sysRole == null)
            {
                return HttpNotFound();
            }
            return View(sysRole);
        }

        // POST: SysRoles/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SysRoleId,Name,IsEnabled")] SysRole sysRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sysRole);
        }

        // GET: SysRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysRole sysRole = db.SysRoles.Find(id);
            if (sysRole == null)
            {
                return HttpNotFound();
            }
            return View(sysRole);
        }

        // POST: SysRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SysRole sysRole = db.SysRoles.Find(id);
            db.SysRoles.Remove(sysRole);
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
