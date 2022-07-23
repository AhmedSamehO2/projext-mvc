using meta.BLL.Interface;
using meta.DAL.database;
using meta.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta.BLL.Reposetry
{
    public class CityRep:ICityRep
    {
        private readonly metaContext db;

        public CityRep(metaContext db)
        {
            this.db = db;
        }
        public IEnumerable<City> Get()
        {
            var data = db.City.Select(a => a);
            return data;
        }

        public City GetById(int id)
        {
            var data = db.City.Where(x => x.Id == id)
                .Select(x => x).FirstOrDefault();
            return data;
        }
    }
}
