
using DomainEntityModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace WebMVCConsumeWebAPI.Controllers
{
 

    public class EmployeeController : Controller
    {
        private const string apiControllerName = "Employee";
        private HttpResponseMessage response;

        // GET: /Employee/
        public ActionResult Index()
        {
            IEnumerable<Employee> empList = null;

            // Call the Web API which its controller name is "Employee"
            response = GlobalVariables.WebApiClient.GetAsync(apiControllerName).Result;

            if (!response.IsSuccessStatusCode)
            {                
                throw new Exception("Web API call error. Error status code: " + response.StatusCode);
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
                response 
                    = GlobalVariables.WebApiClient.GetAsync($"{apiControllerName}/" + id.ToString()).Result;

                if(!response.IsSuccessStatusCode)
                {
                    throw new Exception("Web API call error. Error status code: " + response.StatusCode);
                }

                return View(response.Content.ReadAsAsync<Employee>().Result);
            }
        }

        /// <summary>
        /// TempData in ASP.NET MVC can be used to store temporary data 
        /// which can be used in the subsequent request. TempData will 
        /// be cleared out after the completion of a subsequent request.
        /// 
        /// First request is to assign/store data to TempData. 
        /// Second request is to read TempData.
        /// Subsequent request, TempData became null.
        /// 
        /// TempData is useful when you want to transfer non-sensitive data
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            if (emp.EmployeeID == 0)
            {
                response = GlobalVariables.WebApiClient.PostAsJsonAsync(apiControllerName, emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                response = GlobalVariables.WebApiClient.PutAsJsonAsync($"{apiControllerName}/" + emp.EmployeeID, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            response = GlobalVariables.WebApiClient.DeleteAsync($"{apiControllerName}/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}