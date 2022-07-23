using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using meta.DAL.Entity;
using Microsoft.AspNetCore.Http;

namespace meta.BLL.Model
{
    public class EmployeeVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Message")]
        public string? Name { get; set; }
        [EmailAddress(ErrorMessage = "Enter Valid Mail")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Enter Salary")]
        [Range(2000, 10000, ErrorMessage = "Rang is from 2000 to 10000")]
        public double Salary { get; set; }
        [RegularExpression("[0-9]{1,6}-[a-zA-Z]{3,10}-[a-zA-Z]{3,10}", ErrorMessage = "Ex. 12-street-Haram")]
        public string? Address { get; set; }
        public DateTime Hiredate { get; set; }
        public string? PhotoUrl { get; set; }
        public string? CvUrl { get; set; }
        public IFormFile? Photo { get; set; }
        public IFormFile? Cv { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Chosse Your Department")]

        [ForeignKey("DistrictId")]
        public int DistrictId { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }

        public  Department? Department { get; set; }
        public virtual District? District { get; set; }


    }
}
