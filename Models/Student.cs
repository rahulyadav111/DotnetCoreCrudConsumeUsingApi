using System.ComponentModel.DataAnnotations;

namespace CrudDotnetCoreWebApiConsume.Models
{
    public class Student
    {

       
         public int id { get; set; }
        [Required]
         public string studentName { get; set; }
        [Required]
        public string studentGender { get; set; }
        [Required]
        [Display(Name = "Age")]
        public string age { get; set; }
        [Required]
        [Display(Name = "Qualification")] 
        public string standard { get; set; }
        [Required]
        public string fatherName { get; set; }
        [Required]
        public string mobileNumber { get; set; }
        

    }
}
