using meta.BLL.Model;
using meta.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta.BLL.Interface
{
    public interface IDepartmentRep
    {
        Department GetById(int id);
        IEnumerable<Department> SearchByName(string Name);
        void Edit(Department obj);
        void Delete(Department obj);
        void Create(Department obj);
        IEnumerable<Department> Get();



    }
}
