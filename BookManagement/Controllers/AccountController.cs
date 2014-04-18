using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookManagement.Models;

namespace BookManagement.Controllers
{
    public class AccountController : Controller
    {
        private BookContext db = new BookContext();

        //
        // GET: /Account/

        public ActionResult Index()
        {
            ViewBag.TitleAdmin = "Accounts";
            return View(db.Accounts.ToList());
        }

        //
        // GET: /Account/Details/5

        public ActionResult Details(int id = 0)
        {
            ViewBag.TitleAdmin = "Account Detail";
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        //
        // GET: /Account/Create

        public ActionResult Create()
        {
            ViewBag.TitleAdmin = "Create Account";
            return View();
        }

        //
        // POST: /Account/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account);
        }

        //
        // GET: /Account/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.TitleAdmin = "Edit Account";
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        //
        // POST: /Account/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        //
        // GET: /Account/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ViewBag.TitleAdmin = "Delete Account";
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        //
        // POST: /Account/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}