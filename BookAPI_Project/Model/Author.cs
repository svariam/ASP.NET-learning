using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI_Project.Model
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage = "First Name not more than 80 chars")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "First Name not more than 180 chars")]
        public string LastName { get; set; }
        public virtual Country Country { get; set; }      
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
