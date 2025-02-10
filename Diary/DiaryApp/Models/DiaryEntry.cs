using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {

       
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter a Title!")]
        [StringLength(100,MinimumLength =3,
         ErrorMessage = "Title must be between 3 to 100 characters")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter a Description")]
        public string Content { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter a Date")]
        public DateTime Created { get; set; } = DateTime.Now;


    }
}
