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
        // I'll make an enum to store the employee type wages, because why no over engineer the shit out of a simple task?
        // Practice I guess, that's why lol... hopefully not bad practice tho
        // I think we keep this internal since I only really intend to use it in this class for now
        internal enum EmployeeType { 
            Salaried,
            Wages,
            PartTime,
            Invalid // Adding an invalid, might make the failing cause more graceful?
        }

        // Let's try making a lookup for the employee character that feels a bit better...
        // Associate the enum with the numbers that the empoyeeId starts with
        private static readonly Dictionary<char, EmployeeType> payTypeMap = new Dictionary<char, EmployeeType>()
                {
                    { '0', EmployeeType.Salaried }, { '1', EmployeeType.Salaried }, { '2', EmployeeType.Salaried }, { '3', EmployeeType.Salaried }, { '4', EmployeeType.Salaried },
                    { '5', EmployeeType.Wages }, { '6', EmployeeType.Wages }, { '7', EmployeeType.Wages },
                    { '8', EmployeeType.PartTime }, { '9', EmployeeType.PartTime }
                };

        internal static List<Employee>? createEmployeeList(string filepath)
        {
            string[] dataList = File.ReadAllLines(filepath);
            List<Employee> employeeList = new List<Employee>();

            foreach(string entry in dataList)
            {
                // create an array by splitting at the delimeter
                string[] lineData = entry.Split(':');

                // acess first index of line (the id) then take the first index of the id to determine type of employee
                char empPayIdentifier = lineData[0][0];
                //EmployeeType payType = EmployeeType.Invalid; // initialize to Invalid 

                Console.WriteLine(empPayIdentifier);

                // use TryGetValue() method as a ternary to return either the respective pay category, or Invlaid for use in a switch case
                EmployeeType employeeType = payTypeMap.TryGetValue(empPayIdentifier, out EmployeeType payType) ? payType : EmployeeType.Invalid;

                Dictionary<string, object> employeeDataDict = PullUserData(lineData, employeeType);

                switch (employeeType)
                {
                    case EmployeeType.Salaried:
                        Console.WriteLine($"{lineData[1]} is a {employeeType} employee!");
                        break;
                    case EmployeeType.Wages:
                        Console.WriteLine($"{lineData[1]} is a {employeeType} employee!");

                        break;
                    case EmployeeType.PartTime:
                        Console.WriteLine($"{lineData[1]} is a {employeeType} employee!");

                        break;
                    case EmployeeType.Invalid:
                        Console.WriteLine("Invalid employee identifier!");
                        break;
                    default:
                        Console.WriteLine("We don't actually know what happened if you made it this far in the switchcase...");
                        break;
                }



                //switch (empCategoryIdentifier){
                //    case '0':
                //    case '1':
                //    case '2':
                //    case '3':
                //    case '4':
                //        Salaried empSal = new (lineData[0], lineData[1], lineData[2], lineData[3], long.Parse(lineData[4]), double.Parse(lineData[7])));
                //        break;

                //    case '5':
                //    case '6':
                //    case '7':
                //        Salaried emp = new Salaried(lineData[0], lineData[1], lineData[2], lineData[3], long.Parse(lineData[4]), double.Parse(lineData[7])));

                //        break;

                //    case '8':
                //    case '9':
                //        break;

                //    default:
                //        Console.WriteLine("Invalid number");
                //        break;
                //    }

            }
            return employeeList;
        }

        internal static Dictionary<string, object> PullUserData(string[] employeeRawData, EmployeeType payStyle)
        {
            // Instantiate empty employee object/dict
            Dictionary<string, object> employeeDict = new Dictionary<string, object>();

            // yank out the user data from the line string[]
            string id = employeeRawData[0];
            string name = employeeRawData[1];
            string address = employeeRawData[2];
            string phone = employeeRawData[3];
            long sin = long.Parse(employeeRawData[4]);
            string date = employeeRawData[5];
            string company = employeeRawData[6];
            double rate = double.Parse(employeeRawData[7]);

            employeeDict.Add("id", id);
            employeeDict.Add("name", name);
            employeeDict.Add("address", address);
            employeeDict.Add("phone", phone);
            employeeDict.Add("sin", sin);
            employeeDict.Add("company", company);
            employeeDict.Add("rate", rate);

            if (payStyle != EmployeeType.Salaried){
                double hours = double.Parse(employeeRawData[8]);
                employeeDict.Add("hours", hours);
            }

            //Console.WriteLine(employeeDict.ToString());
            string log = string.Join("\n", employeeDict.Select(kv => $"{kv.Key}: {kv.Value}"));

            Console.WriteLine(log);


            return employeeDict;
        }
   
    }
}