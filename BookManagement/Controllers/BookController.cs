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
    public class BookController : Controller
    {
        private BookContext db = new BookContext();

        //
        // GET: /Book/

        public ActionResult Index()
        {
            ViewBag.TitleAdmin = "Books";
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            return View(books.ToList());
        }

        //
        // GET: /Book/Details/5

        public ActionResult Details(int id = 0)
        {
            ViewBag.TitleAdmin = "Book Detail";
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            ViewBag.TitleAdmin = "Insert Book";
            ViewBag.authorID = new SelectList(db.Authors, "authorID", "authorName");
            ViewBag.categoryID = new SelectList(db.Categories, "categoryID", "categoryName");
            return View();
        }

        //
        // POST: /Book/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string path = "";
                    if (file != null && file.ContentLength > 0)
                    {
                        book.image = file.FileName;
                        path = Server.MapPath("~/Images/books/" + file.FileName);
                    }
                    if (path != "") file.SaveAs(path);
                    db.Books.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.authorID = new SelectList(db.Authors, "authorID", "authorName", book.authorID);
                ViewBag.categoryID = new SelectList(db.Categories, "categoryID", "categoryName", book.categoryID);
                return View(book);
            }
            catch
            {
                object error = "Can not insert new book!";
                return View("Error", error);
            }
        }

        //
        // GET: /Book/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.TitleAdmin = "Edit Book";
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorID = new SelectList(db.Authors, "authorID", "authorName", book.authorID);
            ViewBag.categoryID = new SelectList(db.Categories, "categoryID", "categoryName", book.categoryID);
            return View(book);
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(book).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.authorID = new SelectList(db.Authors, "authorID", "authorName", book.authorID);
                ViewBag.categoryID = new SelectList(db.Categories, "categoryID", "categoryName", book.categoryID);
                return View(book);
            }
            catch
            {
                object error = "Can not Edit current book!";
                return View("Error", error);
            }
        }

        //
        // GET: /Book/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ViewBag.TitleAdmin = "Delete Book";
            Book book = db.Books.Find(id);
            if (book == null)
            {
                object error = "Book doesn't exist!";
                return View("Error", error);
            }
            return View(book);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Book book = db.Books.Find(id);
                //File file = new File();
                db.Books.Remove(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                object error = "Can not EDelete  current book!";
                return View("Error", error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}