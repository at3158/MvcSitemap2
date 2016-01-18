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
    public class SmRoleMenusController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: SmRoleMenus
        public ActionResult Index()
        {
            return View(db.SmRoleMenus.ToList());
        }

        // GET: SmRoleMenus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmRoleMenu smRoleMenu = db.SmRoleMenus.Find(id);
            if (smRoleMenu == null)
            {
                return HttpNotFound();
            }
            return View(smRoleMenu);
        }

        // GET: SmRoleMenus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SmRoleMenus/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SmRoleId,SmMenuId")] SmRoleMenu smRoleMenu)
        {
            if (ModelState.IsValid)
            {
                db.SmRoleMenus.Add(smRoleMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(smRoleMenu);
        }

        // GET: SmRoleMenus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmRoleMenu smRoleMenu = db.SmRoleMenus.Find(id);
            if (smRoleMenu == null)
            {
                return HttpNotFound();
            }
            return View(smRoleMenu);
        }

        // POST: SmRoleMenus/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SmRoleId,SmMenuId")] SmRoleMenu smRoleMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smRoleMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smRoleMenu);
        }

        // GET: SmRoleMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmRoleMenu smRoleMenu = db.SmRoleMenus.Find(id);
            if (smRoleMenu == null)
            {
                return HttpNotFound();
            }
            return View(smRoleMenu);
        }

        // POST: SmRoleMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SmRoleMenu smRoleMenu = db.SmRoleMenus.Find(id);
            db.SmRoleMenus.Remove(smRoleMenu);
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
