using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceLab
{
    internal class Salaried : Employee
    {
        public double Salary { get; set; }
        public double Sin { get; set; }

        public Salaried(string id, string name, string address, string phone, long sin, double salary) : base(id, name, address, phone)
        {
            Salary = salary;
            Sin = sin;

        }
    }
}