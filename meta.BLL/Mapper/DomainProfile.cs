using AutoMapper;
using meta.BLL.Model;
using meta.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta.BLL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();
            CreateMap<EmploteeDetailsVM, Employee>().ReverseMap();
            CreateMap<DepartmentDetailsVM, Department>().ReverseMap();
            CreateMap<DistrictDetailsVM, District>().ReverseMap();



            CreateMap<Country, CountryVM>();
            CreateMap<CountryVM, Country>();


            CreateMap<City, CityVM>();
            CreateMap<CityVM, City>();

            CreateMap<District, DistrictVM>();
            CreateMap<DistrictVM, District>();
        }
    }
}
