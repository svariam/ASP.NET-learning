using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI_Project.Model
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(10,MinimumLength =3,ErrorMessage ="ISBN must be between 3 and 10 chars")]
        public string Isbn { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Title  not more than 180 chars")]
        public string Title { get; set; }

        public DateTime? DatePublished { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

        public virtual ICollection<BookCategory> BookCategorys { get; set; }

    }
}
