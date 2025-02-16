using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace InheritanceLab
{
                
    // Hopefully I can use this to work the methods from a consolidated access access
    internal static class PayrollSystem
    {

        internal static List<Employee>? createEmployeeList(string filepath)
        {
            char[] salaryNums = { '0', '1', '2', '3', '4' };
            string[] dataList = File.ReadAllLines(filepath);
            List<Employee> employeeList = new List<Employee>();

            foreach(string entry in dataList)
            {
                // create an array by splitting at the delimeter
                string[] lineData = entry.Split(':');

                // acess first index of line (the id) then take the first index of the id to determine type of employee
                char empCategoryIdentifier = lineData[0][0];
                Console.WriteLine(empCategoryIdentifier);

                switch (empCategoryIdentifier){
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                        double salary = double.Parse(data[5]);
                        employeeList.Add(new Salaried(id, name, address, phone, sin, salary));
                        break;

                    case '5':
                    case '6':
                    case '7':
                        double wageRate = double.Parse(data[5]);
                        employeeList.Add(new Wages(id, name, address, phone, sin, wageRate));
                        break;

                    case '8':
                    case '9':
                        double partTimeRate = double.Parse(data[5]);
                        employeeList.Add(new PartTime(id, name, address, phone, sin, partTimeRate));
                        break;

                    default:
                        Console.WriteLine($"Invalid employee ID prefix: {idPrefix}"); // Handle invalid IDs
                        break;
                    }

                    //Console.WriteLine(entry.Replace(':', '\n'));
                }
            return employeeList;
        }

    }
}