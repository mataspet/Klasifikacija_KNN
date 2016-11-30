using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using SelectListItem = System.Web.Mvc.SelectListItem;

namespace Klasifikacija_KNN.Models
{
    public class UserPlan
    {
        [Required(ErrorMessage = "Neįvestas minučių skaičius")]
        [Range(-1, int.MaxValue, ErrorMessage = "Mažiausias galimas minučių kiekio pasirinkimas -  -1 (neribotai)")]
        public int UserMinutes { get; set; }

        [Required(ErrorMessage = "Neįvestas SMS skaičius")]
        [Range(-1, int.MaxValue, ErrorMessage = "Mažiausias galimas SMS kiekio pasirinkimas -  -1 (neribotai)")]
        public int UserSms { get; set; }

        [Required(ErrorMessage = "Neįvestas gigabaitų skačius")]
        [Range(-1, double.MaxValue, ErrorMessage = "Mažiausias gigabaitų kiekio pasirinkimas -  -1 (neribotai)")]
        public double UserGb { get; set; }

        public int SelectedId { get; set; }

        public IEnumerable<SelectListItem> AlgorithmList { get; set; }
    }
}