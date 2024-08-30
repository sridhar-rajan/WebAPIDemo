using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class EmployeeSapService{
   static HttpClient client = new HttpClient();

    public async Task<Employee> GetEmployeeProfileAsync(string id)
        {
 // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Employee employee = null;
            HttpResponseMessage response = await client.GetAsync(id);
            if (response.IsSuccessStatusCode)
            {
                employee = await response.Content.ReadAsAsync<Employee>();
            }
            return employee;
        }

        static async Task<Employee> UpdateEmployeeProfileAsync(Employee employee)
        {
 // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/Employee/{employee.Id}", employee);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            employee = await response.Content.ReadAsAsync<Employee>();
            return employee;
        }
}
