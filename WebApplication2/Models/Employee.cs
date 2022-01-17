using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(50,ErrorMessage ="Name cannot  exceed 50 charecters")]
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage ="Invald Error Format")]
        [Display(Name="Office Email")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }
    }
}
