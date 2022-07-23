using meta.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta.BLL.Model
{
    public class CityVM
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public virtual ICollection<District>? District { get; set; }
    }
}
