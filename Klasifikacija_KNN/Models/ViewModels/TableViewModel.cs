using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Klasifikacija_KNN.Algorithms;

namespace Klasifikacija_KNN.Models.ViewModels
{
    public class TableViewModel
    {
        public IEnumerable<PersonResult> Results { get; set; }
        public PersonResult Winner { get; set; }
    }
}