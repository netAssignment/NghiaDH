using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Models
{
    [Table("Role")]
    public class Role
    {
        public int roleID { get; set; }
        [MinLength(3, ErrorMessage = "Role name must have minimum {0} characters")]
        [MaxLength(100, ErrorMessage = "Role name must have maximum {0} characters")]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Role name")]
        public string roleName { get; set; }

        public virtual ICollection<RoleIn> RoleIns { get; set; }
    }

    [Table("Account")]
    public class Account
    {
        public int accountID { get; set; }
        [MinLength(3, ErrorMessage = "Account name must have minimum {0} characters")]
        [MaxLength(32, ErrorMessage = "Account name must have maximum {0} characters")]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Username")]
        public string username { get; set; }
        [MinLength(3, ErrorMessage = "Password name must have minimum {0} characters")]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "{0} is invalid")]
        [Display(Name = "Email")]
        public string email { get; set; }

        public virtual ICollection<RoleIn> RoleIns { get; set; }
    }

    [Table("RoleIn")]
    public class RoleIn
    {
        [Key]
        public int rollInID { get; set; }
        public int roleID { get; set; }
        public int accountID { get; set; }

        public virtual Role Role { get; set; }
        public virtual Account Account { get; set; }
    }

    [Table("Category")]
    public class Category
    {
        public int categoryID { get; set; }
        [MinLength(3, ErrorMessage = "Category name must have minimum {0} characters")]
        [MaxLength(150, ErrorMessage="Category name must have maximum {0} characters")]
        [Required(ErrorMessage="This field is required")]
        [Display(Name = "Category name")]
        public string categoryName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }

    [Table("Author")]
    public class Author
    {
        public int authorID { get; set; }
        [MinLength(3, ErrorMessage = "Book name must have minimum {0} characters")]
        [MaxLength(150, ErrorMessage = "Book name must have maximum {0} characters")]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Author")]
        public string authorName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }

    [Table("Book")]
    public class Book
    {
        public int bookID { get; set; }
        [MinLength(3, ErrorMessage = "Book name must have minimum {0} characters")]
        [MaxLength(150, ErrorMessage = "Book name must have maximum {0} characters")]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Title")]
        public string bookName { get; set; }
        public int authorID { get; set; }
        [Display(Name = "Image")]
        public string image { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"[0-9.]+", ErrorMessage = "Please type a number!")]
        [Display(Name="Pages")]
        public int pages { get; set; }
        [Display(Name = "Short description")]
        public string description_short { get; set; }
        [Display(Name = "Full description")]
        public string description { get; set; }
        public int categoryID { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }        
        public virtual ICollection<Comment> Comments { get; set; }
    }

    [Table("Comment")]
    public class Comment
    {
        public int commentID { get; set; }
        [Display(Name = "Comment")]
        public string commentContent { get; set; }
        public int accountID { get; set; }
        public int bookID { get; set; }

        public virtual Account Account { get; set; }
        public virtual Book Book { get; set; }
    }
}
