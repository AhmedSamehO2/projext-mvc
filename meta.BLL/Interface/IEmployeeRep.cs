using meta.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta.BLL.Interface
{
    public interface IEmployeeRep
    {
        Employee GetById(int id);
        IEnumerable<Employee> SearchByName(string Name);
        void Edit(Employee obj);
        void Delete(Employee obj);
        void Create(Employee obj);
        IEnumerable<Employee> Get();
    }
}
