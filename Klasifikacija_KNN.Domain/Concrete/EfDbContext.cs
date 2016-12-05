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
        public EfDbContext() : base("Klasifikacija")
        {
                Database.SetInitializer(new PlanDbInitializer());
        }

        public DbSet<Plan> Plans { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
