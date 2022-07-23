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
    public class DistrictRep: IDistrictRep
    {
        private readonly metaContext db;

        public DistrictRep(metaContext db)
        {
            this.db = db;
        }
        public IEnumerable<District> Get()
        {
            var data = db.District.Select(a => a);
            return data;
        }

        public District GetById(int id)
        {
            var data = db.District.Where(x => x.Id == id)
                .Select(x => x).FirstOrDefault();
            return data;
        }
    }
}
