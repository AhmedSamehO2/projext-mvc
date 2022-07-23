using meta.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta.BLL.Model
{
    public class DistrictDetailsVM
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }
    }
}
