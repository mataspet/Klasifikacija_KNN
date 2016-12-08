using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klasifikacija_KNN.Domain.Entities;

namespace Klasifikacija_KNN.Domain.Concrete
{
    public class PlanDbInitializer : CreateDatabaseIfNotExists<EfDbContext>
    {
        protected override void Seed(EfDbContext context)
        {
            context.People.Add(new Person()
            {
                Gender = Gender.Male,
                Height = 1.83,
                Weight = 81.6,
                FootSize = 45
            });
            context.People.Add(new Person()
            {
                Gender = Gender.Male,
                Height = 1.8,
                Weight = 86.2,
                FootSize = 44
            });
            context.People.Add(new Person()
            {
                Gender = Gender.Male,
                Height = 1.7,
                Weight = 77.1,
                FootSize = 45
            });
            context.People.Add(new Person()
            {
                Gender = Gender.Male,
                Height = 1.8,
                Weight = 74.8,
                FootSize = 43
            });

            context.People.Add(new Person()
            {
                Gender = Gender.Female,
                Height = 1.52,
                Weight = 45.4,
                FootSize = 37
            });
            context.People.Add(new Person()
            {
                Gender = Gender.Female,
                Height = 1.67,
                Weight = 68,
                FootSize = 39
            });
            context.People.Add(new Person()
            {
                Gender = Gender.Female,
                Height = 1.65,
                Weight = 60,
                FootSize = 38
            });
            context.People.Add(new Person()
            {
                Gender = Gender.Female,
                Height = 1.75,
                Weight = 68,
                FootSize = 40
            });
            base.Seed(context);
        }
    }
}
