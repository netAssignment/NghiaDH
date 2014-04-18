using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookManagement.Models
{
    public class BookContext : DbContext
    {
        public BookContext() : base("name=BookDBConnection") 
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BookContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<BookContext>());
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<RoleIn> RoleIns { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}