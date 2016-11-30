using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Klasifikacija_KNN.Domain.Entities
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string OperatorName { get; set; }
        public string PlanName { get; set; }
        public int Minutes { get; set; }
        public int Sms { get; set; }
        public double Gb { get; set; }
        public double Distance { get; set; }
    }
}
