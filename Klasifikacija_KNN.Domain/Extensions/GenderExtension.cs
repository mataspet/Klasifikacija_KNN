using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klasifikacija_KNN.Domain.Entities;

namespace Klasifikacija_KNN.Domain.Extensions
{
    public static class GenderExtension
    {
        public static string ToLocalisedString(this Gender value)
        {
            switch (value)
            {
                case Gender.Male:
                    return "Vyras";
                case Gender.Female:
                    return "Moteris";
                default:
                    return "Padaras";
            }
        }
    }
}
