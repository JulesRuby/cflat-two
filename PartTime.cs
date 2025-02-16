﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceLab
{
    internal class PartTime : Employee
    {
        public double Rate { get; set; }
        public double Sin{ get; set; }

        public PartTime(string id, string name, string address, string phone, long sin, double rate) : base(id, name, address, phone)
        {
            Rate = rate;
            Sin = sin;

        }
    }
}