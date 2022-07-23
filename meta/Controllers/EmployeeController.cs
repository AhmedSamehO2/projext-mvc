using AutoMapper;
using meta.BLL.Helper;
using meta.BLL.Interface;
using meta.BLL.Model;
using meta.DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace meta.Controllers
{
    public class EmployeeController : Controller
    {
        #region Fildes
        private readonly IDepartmentRep department;
        private readonly IMapper mapper;
        private readonly IEmployeeRep employee;
        private readonly ICountryRep country;
        private readonly ICityRep city;
        private readonly IDistrictRep district;

        #endregion

        #region Ctor
        public EmployeeController(IDepartmentRep _department, IMapper mapper, 
            IEmployeeRep employee,ICountryRep country , ICityRep city, IDistrictRep district)
        {
            this.department = _department;
            this.mapper = mapper;
            this.employee = employee;
            this.country = country;
            this.city = city;
            this.district = district;
        }
        #endregion

        public IActionResult Index(string SearchValue)
        {
            {
                if (SearchValue == null || SearchValue == "")
                {
                    var data = employee.Get();
                    var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
                    return View(result);
                }
                else
                {
                    var data = employee.SearchByName(SearchValue);
                    var result = mapper.Map<IEnumerable<EmployeeVM>>(data);

                    return Ok(result);
                }
            }
        }
       
        public IActionResult create()
        {
            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "DepartmentName");
            ViewBag.CountryList = new SelectList(country.Get(), "Id", "CountryName");

            return View();
        }
        [HttpPost]
        public IActionResult create(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                string CvUrl =  FileUploader.UploadFile("Files/Docs", model.Cv);
                string ImageUrl = FileUploader.UploadFile("Files/Image", model.Photo);

                    var data = mapper.Map<Employee>(model);
                    data.CvUrl = CvUrl;
                    data.PhotoUrl = ImageUrl;
                    employee.Create(data);
                    return RedirectToAction("Index", "Employee");
                }
                return View();
            }
            catch (Exception ex)
            {
                // Handdel Error
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var data = employee.GetById(id);
            var result = mapper.Map<EmployeeVM>(data);

            var dpt = department.Get();
            ViewBag.DepartmentList = new SelectList(dpt, "Id", "DepartmentName", data.DepartmentId);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(EmployeeVM model)
        {
            try
            {

                FileUploader.RemoveFile("Files/Image/", model.PhotoUrl);
                FileUploader.RemoveFile("Files/Docs/", model.CvUrl);

                var data = employee.GetById(model.Id);
                employee.Delete(data);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Handdel Error
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            var data = employee.GetById(id);
            var result = mapper.Map<EmployeeVM>(data);

            ViewBag.DepartmentList = new SelectList(department.Get(), "Id", "DepartmentName", data.DepartmentId);
            ViewBag.CountryList = new SelectList(country.Get(), "Id", "CountryName");

            ViewBag.DistrictList = new SelectList(district.Get(), "Id", "DistrictName",data.DistrictId);


            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    employee.Edit(data);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                // Handdel Error
                return View();
            }
        }
        [HttpGet]
        public IActionResult Detalis(int id)
        {
            var data = employee.GetById(id);
            var result = mapper.Map<EmploteeDetailsVM>(data);

            return Json(result);
        }

        #region Ajax
        [HttpPost]
        public JsonResult GetCityDatabyCountryId(int CtryId)
        {
            var data = city.Get().Where(x => x.CountryId == CtryId);
            return Json(data);
        }
        [HttpPost]
        public JsonResult GetDistrictbyCityId(int ctyId)
        {
            var data = district.Get().Where(x => x.CityId == ctyId);
            return Json(data);
        }


        #endregion

    }
}
