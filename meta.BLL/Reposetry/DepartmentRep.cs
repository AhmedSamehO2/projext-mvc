using meta.BLL.Interface;
using meta.BLL.Model;
using meta.DAL.database;
using meta.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace meta.BLL.Reposetry
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly metaContext db;

        public DepartmentRep(metaContext db)
        {
            this.db = db;
        }

        public void Create(Department obj)
        {            
            db.Add(obj);
            db.SaveChanges();
        }

        public void Delete(Department obj)
        {
           
            db.Department.Remove(obj);
            db.SaveChanges();
        }

        public void Edit(Department obj)  
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Department> Get()
        {
            var data = db.Department.Select(a => a);
            return data;
        }

        public Department GetById(int id)
        {
            var data = db.Department.Where(x => x.Id == id)
                .Select(x => x).FirstOrDefault();
            return data;
        }

        public IEnumerable<Department> SearchByName(string Name)
        {
            var data = db.Department.Where(x => x.DepartmentName == Name) .Select(x => x);
            return data;
        }
    }
}
