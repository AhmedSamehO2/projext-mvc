using AutoMapper;
using meta.BLL.Interface;
using meta.BLL.Model;
using meta.BLL.Reposetry;
using meta.DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace meta.Controllers
{
    public class DepartmentController : Controller
    {
        
          private readonly IDepartmentRep department;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentRep department, IMapper mapper)
        {
            this.department = department;
            this.mapper = mapper;
        }
        public IActionResult Index(string SearchValue)
        {
            if(SearchValue == null || SearchValue == "")
            {
                var data = department.Get();
                var result = mapper.Map<IEnumerable<DepartmentVM>>(data);
                return View(result);
            }
            else
            {
                var data = department.SearchByName(SearchValue);
                var result = mapper.Map<IEnumerable<DepartmentVM>>(data);

                return View(result);  
            }
          
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);
                    department.Create(data);
                    return RedirectToAction("Index");
                }
                return View();

            }catch (Exception ex)
            {
                return View();

            }

        }
        public IActionResult Detalis(int id)
        {
            var data = department.GetById(id);
            var result = mapper.Map<DepartmentVM>(data);

            return View(result);
        }
        public IActionResult Edit(int id)
        {
            var data = department.GetById(id);
            var result = mapper.Map<DepartmentVM>(data);

            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(model);

                    department.Edit(data);
                    return RedirectToAction("Index");
                }
                return View();

            }
            catch (Exception ex)
            {
                return View();

            }

        }
        public IActionResult Delete(int id)
        {
            var data = department.GetById(id);
            var result = mapper.Map<DepartmentVM>(data);

            return View(result);

        }
        [HttpPost]
        public IActionResult Delete(DepartmentVM model)
        {
            try
            {
                var oldData = department.GetById(model.Id);
                    department.Delete(oldData);
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }

    }
}
