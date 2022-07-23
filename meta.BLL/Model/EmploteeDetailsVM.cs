using meta.DAL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace meta.BLL.Model
{
    public class EmploteeDetailsVM
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Enter Message")]
        public string? Name { get; set; }
        [EmailAddress(ErrorMessage = "Enter Valid Mail")]
        public string? Email { get; set; }
        //[Required(ErrorMessage = "Enter Salary")]
        //[Range(2000, 10000, ErrorMessage = "Rang is from 2000 to 10000")]
        public double Salary { get; set; }
        [RegularExpression("[0-9]{1,6}-[a-zA-Z]{3,10}-[a-zA-Z]{3,10}", ErrorMessage = "Ex. 12-street-Haram")]
        public string? Address { get; set; }
        public DateTime Hiredate { get; set; }
        public string? PhotoUrl { get; set; }
        public string? CvUrl { get; set; }
        public string? Notes { get; set; }
        public IFormFile? Photo { get; set; }
        public IFormFile? Cv { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Chosse Your Department")]

        [ForeignKey("DistrictId")]
        public int DistrictId { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }

        public DepartmentDetailsVM? Department { get; set; }
        public DistrictDetailsVM? District { get; set; }



    }
}
