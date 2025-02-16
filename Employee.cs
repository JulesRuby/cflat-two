using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceLab
{
    internal class Employee
    {
        // This should technically be fine since auto implemented properties implicitly create an instance backed private field
        // but also this means that the class diagram file does not display the private fields, so maybe I'll do this the longer way?
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        /* For some reason the instructions indicate that all employees have id, name, and sin. Yet the class diagram
         * expresses that they also include a phone number, which also isn't even a field/property? What is with these 
         * assignments?
         * 
         * I'm just going to infer for now that phone and SIN are probably also safe to consider as private fields and
         * carry forward like that
        */
        protected Employee(string id, string name, string address, string phone)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
        }
    }
}