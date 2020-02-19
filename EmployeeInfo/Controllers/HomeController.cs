using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeInfo.Models;
using PagedList;
using PagedList.Mvc;

     

namespace EmployeeInfo.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeDbContext dbContext = new EmployeeDbContext();
        //private pagesize = 

        public ActionResult Index(string sortOrder, string SearchString, int? page)
        {
            var employees = dbContext.Employees.ToList(); 
            employees = SearchEmployees(employees, SearchString);
            employees = SortEmployees(employees, sortOrder);
            return View(employees.ToPagedList(page ?? 1, 3));
        }

        [NonAction]
        private List<Employee> SearchEmployees(List<Employee> employees, string query)
        {
            if (!String.IsNullOrEmpty(query) || !String.IsNullOrWhiteSpace(query))
            {
                employees = employees.Where(e => e.Name.Contains(query) ||
                                                e.Branch.Contains(query) ||
                                                e.Department.Contains(query)).ToList();
            }
            return employees;
        }

        [NonAction]
        private List<Employee> SortEmployees(List<Employee> employees, string SortOrder)
        {
            string SortBy = "";
            //if (String.IsNullOrEmpty(SortOrder))
            //{
            //    SortBy = ViewBag.IdSort = "Id asc"; 
            //}
            //else if (SortOrder.Contains("Id"))
            //{
            //    SortBy = ViewBag.IdSort = (ViewBag.IdSort == "Id asc") ? "Id desc" : "Id asc"; 
            //} 
            //else if (SortOrder.Contains("Name"))
            //{
            //    SortBy = ViewBag.NameSort = (ViewBag.NameSort == "Name asc") ? "Name desc" : "Name asc";
            //}
            //else if (SortOrder.Contains("Dept"))
            //{
            //    SortBy = ViewBag.DeptSort = (ViewBag.DeptSort == "Dept asc") ? "Dept desc" : "Dept asc";
            //}
            //else if (SortOrder.Contains("Branch"))
            //{
            //    SortBy = ViewBag.BranchSort = (ViewBag.BranchSort == "Branch asc") ? "Branch desc" : "Branch asc";
            //}  

            if (String.IsNullOrEmpty(SortOrder))
            {
                TempData["LastSort"] = SortBy = "Id asc";
            }
            else if (SortOrder.Contains("Id"))
            {
                TempData["LastSort"] = SortBy = ( (string)(TempData["LastSort"]) == "Id asc") ? "Id desc" : "Id asc";
            }
            else if (SortOrder.Contains("Name"))
            {
                TempData["LastSort"] = SortBy = ((string)(TempData["LastSort"]) == "Name asc") ? "Name desc" : "Name asc";
            }
            else if (SortOrder.Contains("Dept"))
            {
                TempData["LastSort"] = SortBy = ((string)(TempData["LastSort"]) == "Dept asc") ? "Dept desc" : "Dept asc";
            }
            else if (SortOrder.Contains("Branch"))
            {
                TempData["LastSort"] = SortBy = ((string)(TempData["LastSort"]) == "Branch asc") ? "Branch desc" : "Branch asc";
            }


            switch (SortBy)
            {
                case "Id asc":
                    employees = employees.OrderBy(e => e.Id).ToList();
                    break;
                case "Id desc":
                    employees = employees.OrderByDescending(e => e.Id).ToList();
                    break;
                case "Name asc":
                    employees = employees.OrderBy(e => e.Name).ToList();
                    break;
                case "Name desc":
                    employees = employees.OrderByDescending(e => e.Name).ToList();
                    break;
                case "Dept asc":
                    employees = employees.OrderBy(e => e.Department).ToList();
                    break;
                case "Dept desc":
                    employees = employees.OrderByDescending(e => e.Department).ToList();
                    break;
                case "Branch asc":
                    employees = employees.OrderBy(e => e.Branch).ToList();
                    break;
                case "Branch desc":
                    employees = employees.OrderByDescending(e => e.Branch).ToList();
                    break;
                default:
                    break;
            }
            return employees;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}