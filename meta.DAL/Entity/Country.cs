using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace meta.DAL.Entity
{
    [Table("Country")]
    public class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }
     
        public int Id { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<City>? City { get; set; }

    }
}
