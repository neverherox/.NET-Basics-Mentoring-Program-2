using System;
using System.Collections.Generic;
using Models;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee
            {
                EmployeeName = "Kiryl"
            };
            var employee1 = new Employee
            {
                EmployeeName = "Deputat"
            };
            var employees = new List<Employee>();
            employees.Add(employee);
            employees.Add(employee1);
            var department = new Department
            {
                DepartmentName = "epam",
                Employees = employees
            };

            var clone = (Department) department.Clone();
            clone.DepartmentName = "intexsoft";
            clone.Employees[0].EmployeeName = "Mark";
            clone.Employees[1].EmployeeName = "Vlad";

            if (clone.DepartmentName == department.DepartmentName ||
                clone.Employees[0].EmployeeName == department.Employees[0].EmployeeName ||
                clone.Employees[1].EmployeeName == department.Employees[1].EmployeeName)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
