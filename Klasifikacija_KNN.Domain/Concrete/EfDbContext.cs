using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klasifikacija_KNN.Domain.Entities;

namespace Klasifikacija_KNN.Domain.Concrete
{
    public class EfDbContext : DbContext
    {
        public DbSet<Plan> Plans { get; set; }
    }
}
