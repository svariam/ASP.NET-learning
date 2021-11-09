using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI_Project.Model
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200,MinimumLength =10,ErrorMessage ="Headline too long")]
        public string HeadLine { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2000, ErrorMessage = "Review too long")]
        public string ReviewText { get; set; }
        public int Rating { get; set; }

        public virtual Reviewer Reviewer { get; set; }
        public virtual Book Book { get; set; }
    }
}
