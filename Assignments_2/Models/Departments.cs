using System.ComponentModel.DataAnnotations;

namespace Assignments_2.Models
{
    public class Departments
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter a valid Department Name")]
        [StringLength(50)]       
        public string Name { get; set; }
    }
}