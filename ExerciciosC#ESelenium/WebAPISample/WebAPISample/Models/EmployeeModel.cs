using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPISample.Models
{
    public class EmployeeModel
    {
        public static List<Employee> _employees = new List<Employee>();

        public EmployeeModel()
        {
            if (_employees.Count <= 0)
            {
                AddEmployee(new Employee() { Name = "Clark", Department = "Accounting", Designation = "Manager"});
                AddEmployee(new Employee() { Name = "Jones", Department = "Research", Designation = "Manager" });
                AddEmployee(new Employee() { Name = "Smith", Department = "Research", Designation = "Analyst" });
            }
        }

        public void AddEmployee(Employee employee)
        {
            //get next ID
            if (_employees.Count > 0)
            {
                employee.ID = _employees.Max(e => e.ID) + 1;
            }
            else
            {
                employee.ID = 1;
            }
            _employees.Add(employee);
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        public Employee GetEmployee(int id)
        {
            var emp = _employees.Where(e => e.ID == id).FirstOrDefault();
            return emp;
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            var emp = _employees.Where(e => e.ID == id).FirstOrDefault();

            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Department = employee.Department;
                emp.Designation = employee.Designation;
            }
        }

        public void DeleteEmployee(int id)
        {
            var emp = _employees.Where(e => e.ID == id).FirstOrDefault();
            if (emp != null)
            {
                _employees.Remove(emp);
            }
        }
    }
}