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
    public class CountryRep:ICountryRep
    {
        private readonly metaContext db;

        public CountryRep(metaContext db)
        {
            this.db = db;
        }
        public IEnumerable<Country> Get()
        {
            var data = db.Country.Select(a => a);
            return data;
        }

        public Country GetById(int id)
        {
            var data = db.Country.Where(x => x.Id == id)
                .Select(x => x).FirstOrDefault();
            return data;
        }
    }
}
