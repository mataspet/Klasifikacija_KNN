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
        [DisplayName("Operatorius")]
        public string OperatorName { get; set; }
        [DisplayName("Planas")]
        public string PlanName { get; set; }
        [DisplayName("Minutės")]
        public int Minutes { get; set; }
        [DisplayName("Sms")]
        public int Sms { get; set; }
        [DisplayName("Gigabaitai")]
        public double Gb { get; set; }
        [DisplayName("Atstumas")]
        public double Distance { get; set; }
    }
}
