
using DomainEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleAppConsumeAPI
{
    class Program
    {
        private const string webAPIURL = "http://localhost:64028/";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Print all employees");
                Console.WriteLine("2. Add employee data.");
                Console.WriteLine("3. Update / Delete employee data by Id");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your option:");
                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        PrintEmployee().Wait();
                        break;
                    case "2":
                        AddEmployee().Wait();
                        break;
                    case "3":
                        UpdateDeleteEmployee().Wait();
                        break;
                    case "4":
                        Console.WriteLine("Bye");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;

                }
            }

        }

        static async Task CallWebAPIAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webAPIURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method
                HttpResponseMessage response = await client.GetAsync("api/Employee/1");
                if (response.IsSuccessStatusCode)
                {
                    Employee employee = await response.Content.ReadAsAsync<Employee>();

                    Console.WriteLine("Id:{0}\n", employee.EmployeeID);

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

                //POST Method
                var departmentPost = new Employee() { Name = "Test Department" };
                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/Employee", departmentPost);
                if (responsePost.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    Uri returnUrl = responsePost.Headers.Location;
                    Console.WriteLine(returnUrl);
                }

                ////PUT Method
                var departmentPut = new Employee() { EmployeeID = 9, Name = "Updated Department" };
                HttpResponseMessage responsePut = await client.PutAsJsonAsync("api/Employee", departmentPut);
                if (responsePut.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                }

                //Delete Method
                int departmentId = 9;
                HttpResponseMessage responseDelete = await client.DeleteAsync("api/Employee/" + departmentId);
                if (responseDelete.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                }
            }
            Console.Read();
        }

        static async Task PrintEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webAPIURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method
                HttpResponseMessage response = await client.GetAsync("api/Employee");
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<Employee> employees = await response.Content.ReadAsAsync<IEnumerable<Employee>>();

                    foreach (var item in employees)
                    {
                        Console.WriteLine($"Employee Id: {item.EmployeeID}");
                        Console.WriteLine($"Name: {item.Name}");
                        Console.WriteLine($"Position: {item.Position}");
                        Console.WriteLine($"Age: {item.Age}");
                        Console.WriteLine($"Salary: {item.Salary}\n");
                    }
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
        }

        static async Task AddEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webAPIURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var employee = new Employee();

                //POST Method
                Console.Write("Enter your name: ");
                employee.Name = Console.ReadLine();

                Console.Write("Enter your position: ");
                employee.Position = Console.ReadLine();

                Console.Write("Enter your age: ");
                employee.Age = Convert.ToInt16(Console.ReadLine());

                Console.Write("Enter your salary: ");
                employee.Salary = Convert.ToInt16(Console.ReadLine());

                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/Employee", employee);
                if (responsePost.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    Uri returnUrl = responsePost.Headers.Location;
                    if (returnUrl != null)
                    {
                        Console.WriteLine("Employee data successfully added.");
                    }
                    //Console.WriteLine(returnUrl);
                }
                else
                {
                    Console.WriteLine("Internal server Error: " + responsePost.ReasonPhrase);
                }
            }

        }

        static async Task UpdateDeleteEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webAPIURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                Console.Write("Enter Employee ID for update / delete: ");
                int empId = Convert.ToInt16(Console.ReadLine());

                Console.Write("Update (u) or delete (d)?");
                string opt = Console.ReadLine();

                switch (opt.ToLower())
                {
                    case "u":
                        var employee = new Employee();
                        employee.EmployeeID = empId;

                        Console.Write("Enter your name: ");
                        employee.Name = Console.ReadLine();

                        Console.Write("Enter your position: ");
                        employee.Position = Console.ReadLine();

                        Console.Write("Enter your age: ");
                        employee.Age = Convert.ToInt16(Console.ReadLine());

                        Console.Write("Enter your salary: ");
                        employee.Salary = Convert.ToInt16(Console.ReadLine());

                        HttpResponseMessage responsePut = await client.PutAsJsonAsync("api/Employee", employee);
                        if (responsePut.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Successful updated.");
                        }
                        else
                        {
                            Console.WriteLine("Internal server Error");
                        }
                        break;
                    case "d":
                        break;
                    default:
                        return;

                }


            }

        }
    }
}
