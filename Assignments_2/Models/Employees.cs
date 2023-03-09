using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Serialization;
using System.Configuration;

namespace Assignments_2.Models
{
    public class Employees
    {        
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter a Valid Name")]
        [StringLength(30, ErrorMessage ="Name can't be more than 30 character")] 
        public string Name { get; set; }

        [Range(21, 100)]
        [Required(ErrorMessage ="Please enter a valid age between 21-100 only")]
        public int Age { get; set; }

        [Required(ErrorMessage ="Please enter a valid Department ID")]
        public int DepartmentId { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage ="Please provide a positive value")]
        public decimal Salary { get; set; }

        [ForeignKey("DepartmentId")]
        public Departments Department { get; set; }
        
    }
}
