using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klasifikacija_KNN.Domain.Entities;

namespace Klasifikacija_KNN.Domain.Abstract
{
    public interface IDistanceCalculator
    {
        IEnumerable<Plan> EuclideanDistance(IEnumerable<Plan> plans, IEnumerable<double> userPlan);
        IEnumerable<Plan> ManhattanDistance(IEnumerable<Plan> plans, IEnumerable<double> userPlan);
        IEnumerable<Plan> ChebyshevDistance(IEnumerable<Plan> plans, IEnumerable<double> userPlan);
    }
}
