using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeModel empModel = new EmployeeModel();

        // GET: Employee
        public IEnumerable<Employee> Get()
        {
            return empModel.GetEmployees();
        }

        // GET: Employee/5
        public Employee Get(int id)
        {
            return empModel.GetEmployee(id);
        }

        // POST: api/Employee
        public void Post(Employee employee)
        {
            empModel.AddEmployee(employee);
        }

        // POST: api/Employee/5
        public void Put(int id, Employee employee)
        {
            empModel.UpdateEmployee(id, employee);
        }


        // DELETE api/Employee/5
        public void Delete(int id, Employee employee)
        {
            empModel.DeleteEmployee(id);
        }
    }
}
