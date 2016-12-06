using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasifikacija_KNN.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public Gender Gender { get; set; }

        public double Weight { get; set; }
        public double Height { get; set; }
        public int FootSize { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}
