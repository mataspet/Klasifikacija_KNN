using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klasifikacija_KNN.Domain.Entities;

namespace Klasifikacija_KNN.Domain.Abstract
{
    public interface IPlanRepository
    {
        IEnumerable<Plan> Plans { get; }
    }
}
