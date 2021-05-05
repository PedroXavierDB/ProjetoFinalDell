using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace ConsumeASP.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            RunClient();

            Console.ReadLine();
        }

        static void RunClient()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44383/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //GetById(client, "1").Wait();
                //PostData(client, new Employee() { Name = "A", Department = "B", Designation = "C" }).Wait();
                DeleteData(client, "4").Wait();
                GetAll(client).Wait();
                //UpdateData(client, "4", new Employee() { Name = "C", Department = "B", Designation = "C" }).Wait();
                

            }
        }

        static async Task GetById(HttpClient client, string id)
        {
            //GET api/employees
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/employee/" + id);
                response.EnsureSuccessStatusCode();

                Employee emp = await response.Content.ReadAsAsync<Employee>();

                Console.WriteLine("Name: {0}\tDepartment: {1}\tDesignation: {2}", emp.Name, emp.Department, emp.Designation);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task GetAll(HttpClient client)
        {
            //GET api/employees
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/employee");
                response.EnsureSuccessStatusCode();

                List<Employee> emps = await response.Content.ReadAsAsync<List<Employee>>();
                foreach(Employee emp in emps)
                {
                    Console.WriteLine("Id: {0}\tName: {1}\tDepartment: {2}\tDesignation: {3}", emp.ID, emp.Name, emp.Department, emp.Designation);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task PostData(HttpClient client, Employee emp)
        {
            //POST api/employees
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/employee", emp);
                response.EnsureSuccessStatusCode();

                List<Employee> emps = await response.Content.ReadAsAsync<List<Employee>>();
                Console.WriteLine("Saved");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task UpdateData(HttpClient client, string id, Employee emp)
        {
            //PUT api/employees/id
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("api/employee/" + id, emp);
                response.EnsureSuccessStatusCode();

                Console.WriteLine("Updated");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task DeleteData(HttpClient client, string id)
        {
            //Delete api/employees/id
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("api/employee/" + id);
                response.EnsureSuccessStatusCode();

                Console.WriteLine("Deleted");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }


public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
    }
}
