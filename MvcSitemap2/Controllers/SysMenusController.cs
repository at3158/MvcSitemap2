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
    public class SysMenusController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: SysMenus
        public ActionResult Index()
        {
            return View(db.SysMenus.ToList());
        }

        // GET: SysMenus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysMenu sysMenu = db.SysMenus.Find(id);
            if (sysMenu == null)
            {
                return HttpNotFound();
            }
            return View(sysMenu);
        }

        // GET: SysMenus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SysMenus/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SysMenuId,Name,NameCn,NameUs,Area,Controller,Action,Url,Description,ParentId,RouteValues,OrderSn,IsEnabled")] SysMenu sysMenu)
        {
            if (ModelState.IsValid)
            {
                db.SysMenus.Add(sysMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sysMenu);
        }

        // GET: SysMenus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysMenu sysMenu = db.SysMenus.Find(id);
            if (sysMenu == null)
            {
                return HttpNotFound();
            }
            return View(sysMenu);
        }

        // POST: SysMenus/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SysMenuId,Name,NameCn,NameUs,Area,Controller,Action,Url,Description,ParentId,RouteValues,OrderSn,IsEnabled")] SysMenu sysMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sysMenu);
        }

        // GET: SysMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysMenu sysMenu = db.SysMenus.Find(id);
            if (sysMenu == null)
            {
                return HttpNotFound();
            }
            return View(sysMenu);
        }

        // POST: SysMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SysMenu sysMenu = db.SysMenus.Find(id);
            db.SysMenus.Remove(sysMenu);
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
