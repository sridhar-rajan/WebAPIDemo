
using DomainEntityModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace WebMVCConsumeWebAPI.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            IEnumerable<Employee> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;


            return View(empList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Employee());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Employee>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            if (emp.EmployeeID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employee", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Employee/" + emp.EmployeeID, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Employee/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}