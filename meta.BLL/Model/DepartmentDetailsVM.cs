using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta.BLL.Model
{
    public class DepartmentDetailsVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Required Data")]
        [MaxLength(50, ErrorMessage = "Max Len 50 Char")]
        [MinLength(5, ErrorMessage = "Min Len 5 Char")]
        public string? DepartmentName { get; set; }

        [Required(ErrorMessage = "Enter Required Data")]

        public string? DepartmentCode { get; set; }
    }
}
