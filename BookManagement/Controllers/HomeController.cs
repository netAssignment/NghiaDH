using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookManagement.Models;

namespace BookManagement.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        void AddInformation()
        {
            Role role1 = new Role();
            role1.roleName = "Administrator";
            Role role2 = new Role();
            role2.roleName = "User";
            Role role3 = new Role();
            role3.roleName = "Book Manager";
            Role role4 = new Role();
            role4.roleName = "Account Manager";
            db.Roles.Add(role1);
            db.Roles.Add(role2);
            db.Roles.Add(role3);
            db.Roles.Add(role4);
            db.SaveChanges();

            Account user1 = new Account();
            user1.username = "nghiadoan";
            user1.password = "12345";
            user1.email = "huunghia@gmail.com";
            Account user2 = new Account();
            user2.username = "duchue";
            user2.password = "12345";
            user2.email = "duchue@gmail.com";
            db.Accounts.Add(user1);
            db.Accounts.Add(user2);
            db.SaveChanges();

            RoleIn roleIn1 = new RoleIn();
            roleIn1.roleID = 1;
            roleIn1.accountID = 1;
            RoleIn roleIn2 = new RoleIn();
            roleIn2.roleID = 2;
            roleIn2.accountID = 2;
            db.RoleIns.Add(roleIn1);
            db.RoleIns.Add(roleIn2);
            db.SaveChanges();

            Category cat1 = new Category();
            cat1.categoryName = "Business";
            Category cat2 = new Category();
            cat2.categoryName = "Information Technology";
            Category cat3 = new Category();
            cat3.categoryName = "Children";
            db.Categories.Add(cat1);
            db.Categories.Add(cat2);
            db.Categories.Add(cat3);
            db.SaveChanges();

            Author author1 = new Author();
            author1.authorName = "Thomas J. Peters";
            Author author2 = new Author();
            author2.authorName = "Clayton M. Christensen";
            Author author3 = new Author();
            author3.authorName = "Dale Carnegie";
            Author author4 = new Author();
            author4.authorName = "Kenneth H. Blanchard";
            Author author5 = new Author();
            author5.authorName = "Stephen R. Covey";
            db.Authors.Add(author1);
            db.Authors.Add(author2);
            db.Authors.Add(author3);
            db.Authors.Add(author4);
            db.Authors.Add(author5);
            db.SaveChanges();

            Book book1 = new Book();
            book1.bookName = "In Search of Excellence: Lessons from America’s Best-Run Companies";
            book1.authorID = 1;
            book1.image = "in_search_of_excellence.png";
            book1.pages = 564;
            book1.description_short = "Highly influential when global competition...";
            book1.description = @"Highly influential when global competition, largely from Japan, had brought Western business to a low, this quintessential business book describes eight enduring management principles that made the forty-three companies surveyed “excellent.” The authors focus exclusively on big companies, namely big manufacturers, but ironically condemn the excesses of modern management practice and advocate a return to simpler virtues. They have since come to feel that their ideas are better embodied in smaller companies.
<br/>Through lively case studies, this very readable classic forces a look at the fundamentals, at “first principles” that give a company its soul: Attention to customers, an abiding concern for people (productivity through people), the celebration of trial and error. A driving force in the subsequent deluge of business books, this trailblazer established customer service as a key form of differentiation and advantage, and launched the author-as-consultant/speaker/celebrity phenomenon.";
            book1.categoryID = 1;
            Book book2 = new Book();
            book2.bookName = "The Innovator’s Dilemma: When New Technologies Cause Great Firms to Fail";
            book2.authorID = 2;
            book2.image = "innovators_dillemma.png";
            book2.pages = 619;
            book2.description_short = "Examining a variety of leading well-managed companies...";
            book2.description = @"Examining a variety of leading well-managed companies that have failed to capitalize on innovative technologies, Christensen explains, with striking clarity and style, how to manage breakthrough products successfully when customers may not be ready for them.
<br/>His argument that overdependence on customer needs, or on the most profitable products, can damage a company’s success challenges the marketing and customer service books that put customer focus at the top of the corporate agenda. Considered a paradigmatic marketing visionary, Christensen highlights the problems inherent in what appears to be sound decision making, and rigorously demonstrates that companies will fall behind if they fail to adapt or adopt new technologies that will meet customers’ unstated or future needs.
<br/>Illustrating his points with anecdotes of historical figures, business leaders, and ordinary folks, Carnegie instructs the reader in how to change people, how to win them over to your way of thinking, without causing offense or resentment, and without making them feel manipulated. He teaches these skills through the underlying principle that people want to feel important and appreciated. Carnegie was the first to create a flourishing, credible, long-term business out of his ideas.";
            book2.categoryID = 1;
            Book book3 = new Book();
            book3.bookName = "How to Win Friends & Influence People";
            book3.authorID = 3;
            book3.image = "win_friends_influence_people.png";
            book3.pages = 472;
            book3.description_short = "Having sold more than 15 million copies...";
            book3.description = @"Having sold more than 15 million copies, this seminal self-improvement book continues to guide managers in the universal challenge of face-to-face communication.
<br/>A master of human nature, Carnegie advises that “[w]hen dealing with people, remember you are not dealing with creatures of logic, but with creatures of emotion, creatures bristling with prejudice, and motivated by pride and vanity.” He argues that success is only 15% professional knowledge; the remaining 85% is “the ability to express ideas, to assume leadership, and to arouse enthusiasm among people.”";
            book3.categoryID = 1;
            Book book4 = new Book();
            book4.bookName = "The One-Minute Manager";
            book4.authorID = 4;
            book4.image = "one_minute_manager.png";
            book4.pages = 871;
            book4.description_short = "Millions of managers in Fortune 500 companies...";
            book4.description = @"Millions of managers in Fortune 500 companies and small businesses around the globe have followed the timeless principles of this first mega-bestselling business book, presented as a parable. Concisely elegant, this narrative reveals three practical management secrets: One-Minute Goals, One-Minute Praisings, and One-Minute Reprimands—a concept that has spawned numerous “One-Minute” titles, for endeavors from parenting to golfing.
<br/>Blanchard and Johnson ground their ideas in studies in medicine and the behavioral sciences to explain why the one-minute techniques work with so many people, in so many environments.";
            book4.categoryID = 1;
            Book book5 = new Book();
            book5.bookName = "The 7 Habits of Highly Effective People: Powerful Lessons in Personal Change";
            book5.authorID = 5;
            book5.image = "7-habits.png";
            book5.pages = 296;
            book5.description_short = "Having developed the concept of this groundbreaking...";
            book5.description = @"Having developed the concept of this groundbreaking, long-term bestseller by studying literature going back more than 200 years, Covey bases his approach on relatively immutable personal human values. Unlike many a self-improvement author, however, he doesn’t promise a quick fix; rather, he calls for a paradigm shift—a revolutionary change in one’s perceptions and interpretations of how the world works. And with different thinking comes different actions that will profoundly affect one’s productivity and effectiveness.
<br/>Be proactive. Begin with an end in mind. Put first things first. Think win/win. Seek first to understand. Synergize. Renewal. With penetrating insights and cogent anecdotes, Covey presents a highly structured, holistically integrated methodology for creating balance, and hence success, in one’s personal and professional lives.";
            book5.categoryID = 1;
            db.Books.Add(book1);
            db.Books.Add(book2);
            db.Books.Add(book3);
            db.Books.Add(book4);
            db.Books.Add(book5);

            db.SaveChanges();
        }

        [ChildActionOnly]
        public ActionResult _CategoryPartial()
        {
            ViewBag.Message = "Categories";
            return PartialView(db.Categories.ToList());
        }

        [ChildActionOnly]
        public ActionResult _LoginPartial()
        {
            return PartialView();
        }

        public ActionResult Index(int? id)
        {
            //AddInformation();
            ViewBag.Title = "Index";
            List<Book> books;
            if (!id.HasValue)
            {
                books = db.Books.ToList();
            }
            else
            {
                books = db.Books.Where(p => p.Category.categoryID == id).ToList();
            }
            return View(books);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Detail(int id = 0)
        {
            ViewBag.Title = "Detail";
            Book book = db.Books.Find(id);
            if (book == null)
            {
                object error = "This book doensn't exist!";
                return View("Error", error);
            }
            return View(book);
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            return View();
        }
    }
}
