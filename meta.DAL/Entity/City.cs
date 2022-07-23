using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace meta.DAL.Entity
{
    [Table("City")]

    public class City
    {
        public City()
        {
            District = new HashSet<District>();
        }
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public virtual ICollection<District>? District { get; set; }


    }
}
