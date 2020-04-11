
using DomainEntityModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace WebMVCConsumeWebAPI.Controllers
{
    [HandleError]
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            IEnumerable<Employee> empList = null;

            // Call the Web API which its controller name is "Employee"
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee").Result;

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Web API call error. Error status code: " + response.StatusCode;
                return View(empList);
            }

            // If the Web API call is successful (response status code 200),
            // it will return/response back with IEnumerable<Employee> data
            empList = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;


            return View(empList);
        }

        
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Employee());
            else
            {
                // Call the Web API which its controller name is "Employee"
                HttpResponseMessage response 
                    = GlobalVariables.WebApiClient.GetAsync("Employee/" + id.ToString()).Result;

                if(!response.IsSuccessStatusCode)
                {
                    ViewBag.Error = "Web API call error. Error status code: " + response.StatusCode;
                    return View();
                }
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