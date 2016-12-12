using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klasifikacija_KNN.Domain.Abstract;
using Klasifikacija_KNN.Domain.Entities;

namespace Klasifikacija_KNN.Domain.Concrete
{
    public class DistanceCalculator : IDistanceCalculator
    {
        public IEnumerable<Plan> EuclideanDistance(IEnumerable<Plan> plans, IEnumerable<double> userPlan)
        {
            foreach (var plan in plans)
            {
                plan.Distance =
                    Math.Sqrt(Math.Pow(userPlan.ElementAt(0) - plan.Minutes, 2) +
                              Math.Pow(userPlan.ElementAt(1) - plan.Sms, 2) +
                              Math.Pow(userPlan.ElementAt(2) - plan.Gb, 2));
            }

            return plans.OrderBy(p => p.Distance);
        }

        public IEnumerable<Plan> ManhattanDistance(IEnumerable<Plan> plans, IEnumerable<double> userPlan)
        {
            foreach (var plan in plans)
            {
                plan.Distance = Math.Abs(userPlan.ElementAt(0) - plan.Minutes) + Math.Abs(userPlan.ElementAt(1) - plan.Sms) +
                                Math.Abs(userPlan.ElementAt(2) - plan.Gb);
            }

            return plans.OrderBy(p => p.Distance);
        }

        public IEnumerable<Plan> ChebyshevDistance(IEnumerable<Plan> plans, IEnumerable<double> userPlan)
        {

            foreach (var plan in plans)
            {
                plan.Distance = new List<double>
                {
                    Math.Abs(userPlan.ElementAt(0) - plan.Minutes),
                    Math.Abs(userPlan.ElementAt(1) - plan.Sms),
                    Math.Abs(userPlan.ElementAt(2) - plan.Gb),
                }.Max();
            }
            return plans.OrderBy(p => p.Distance);
        }
    }
}
