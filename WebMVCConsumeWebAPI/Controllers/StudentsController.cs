using DomainEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebMVCConsumeWebAPI.Controllers
{
    public class StudentsController : Controller
    {
        private const string apiControllerName = "Students";
        private HttpResponseMessage response;

        public ActionResult JQueryCallApi()
        {
            return View();
        }

        // GET: Students
        public ActionResult Index()
        {
            IEnumerable<Student> studentList = null;

            response = GlobalVariables.WebApiClient.GetAsync(apiControllerName).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Web API call error. Error status code: " + response.StatusCode);
            }

            studentList = response.Content.ReadAsAsync<IEnumerable<Student>>().Result;

            return View(studentList);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            response = GlobalVariables.WebApiClient.GetAsync($"{apiControllerName}/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<Student>().Result);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here
                response = GlobalVariables.WebApiClient.PostAsJsonAsync(apiControllerName,student).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            response = GlobalVariables.WebApiClient.GetAsync($"{apiControllerName}/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<Student>().Result);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                // TODO: Add update logic here
                response 
                    = GlobalVariables.WebApiClient.PutAsJsonAsync($"{apiControllerName}/id" + id.ToString(), student).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            response = GlobalVariables.WebApiClient.GetAsync($"{apiControllerName}/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<Student>().Result);
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                // TODO: Add delete logic here
                response
                    = GlobalVariables.WebApiClient.DeleteAsync($"{apiControllerName}/id" + id.ToString()).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
