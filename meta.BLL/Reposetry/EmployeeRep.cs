using meta.BLL.Interface;
using meta.DAL.database;
using meta.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta.BLL.Reposetry
{
    public class EmployeeRep:IEmployeeRep
    {
        private readonly metaContext db;
        public EmployeeRep(metaContext db)
        {
            this.db = db;
        }

        public EmployeeRep()
        {
        }

        public Employee GetById(int id)
        {
            var data = db.Employee.Include("Department").Include("District").Where(x => x.Id == id).FirstOrDefault();
            return data;
        }
       
        public void Delete(Employee obj)
        {
            db.Employee.Remove(obj);
            db.SaveChanges();
        }

        public void Edit(Employee obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
        public IEnumerable<Employee> SearchByName(string Name)
        {
            var data = db.Employee.Include("Department").Include("District").Where(x => x.Name == Name).Select(x => x);

            return data;
        }
        public IEnumerable<Employee> Get()
        {
            var data = db.Employee.Include("Department").Include("District").Select(a => a);
            return data;
        }

        public void Create(Employee obj)
        {
            db.Employee.Add(obj);
            db.SaveChanges();
        }
    }
}
