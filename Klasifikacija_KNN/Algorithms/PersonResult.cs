using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Klasifikacija_KNN.Domain.Entities;

namespace Klasifikacija_KNN.Algorithms
{
    public class PersonResult
    {
        public Gender Gender { get; set; }
        public double Probability { get; set; }
    }
}