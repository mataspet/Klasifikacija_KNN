using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klasifikacija_KNN.Domain.Abstract;
using Klasifikacija_KNN.Domain.Entities;

namespace Klasifikacija_KNN.Domain.Concrete
{
    public class EfPlansRepository : IPlanRepository
    {
        private readonly EfDbContext _context = new EfDbContext();
        public IEnumerable<Plan> Plans => _context.Plans;
    }
}
