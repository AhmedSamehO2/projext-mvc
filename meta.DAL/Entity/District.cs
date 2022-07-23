using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace meta.DAL.Entity
{
    [Table("District")]

    public class District
    {
        public District()
        {
            Employee = new HashSet<Employee>();

        }

        [Key]
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }
        public virtual ICollection<Employee>? Employee { get; set; }


    }
}
