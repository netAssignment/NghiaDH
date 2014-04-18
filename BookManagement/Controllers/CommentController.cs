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
    public class CommentController : Controller
    {
        private BookContext db = new BookContext();

        //
        // GET: /Comment/

        public ActionResult Index()
        {
            ViewBag.TitleAdmin = "Comments";
            var comments = db.Comments.Include(c => c.Account).Include(c => c.Book);
            return View(comments.ToList());
        }

        //
        // GET: /Comment/Details/5

        public ActionResult Details(int id = 0)
        {
            ViewBag.TitleAdmin = "Comment Detail";
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        //
        // GET: /Comment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.TitleAdmin = "Comment Edit";
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.accountID = new SelectList(db.Accounts, "accountID", "username", comment.accountID);
            ViewBag.bookID = new SelectList(db.Books, "bookID", "bookName", comment.bookID);
            return View(comment);
        }

        //
        // POST: /Comment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountID = new SelectList(db.Accounts, "accountID", "username", comment.accountID);
            ViewBag.bookID = new SelectList(db.Books, "bookID", "bookName", comment.bookID);
            return View(comment);
        }

        //
        // GET: /Comment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ViewBag.TitleAdmin = "Delete Comment";
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        //
        // POST: /Comment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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