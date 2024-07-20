using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.FlowAnalysis;
using ModelBinding.DAL;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        //http://localhost:1234/Employees/index
        public ActionResult Index()
        {
            List<Employee> emp = EmpDAl.GetAllEmployees();

            return View(emp);
        }

        // GET: EmployeesController/Details/5
        //http://localhost:1234/Employees/Detail/id
        public ActionResult Details(int id)
        {
            
            Employee emp = EmpDAl.GetSingleEmployee(id);
            
            return View(emp);
        }

        // GET: EmployeesController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
               EmpDAl.Insert(emp);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {

            Employee emp= EmpDAl.GetSingleEmployee(id);

            return View(emp);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj)
        {
            try
            {
                EmpDAl.Edit(id,obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee emp = EmpDAl.GetSingleEmployee(id);

            return View(emp);

        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee obj,int id)
        {
            try
            {
                EmpDAl.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
