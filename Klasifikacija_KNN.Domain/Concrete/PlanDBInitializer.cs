using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klasifikacija_KNN.Domain.Entities;

namespace Klasifikacija_KNN.Domain.Concrete
{
    public class PlanDbInitializer : DropCreateDatabaseAlways<EfDbContext>
    {
        protected override void Seed(EfDbContext context)
        {
            context.Plans.Add(new Plan()
            {
                Gb = 2,
                Minutes = 300,
                Sms = 1000,
                OperatorName = "Omnitel",
                PlanName = "Lėtiems"
            });

            context.Plans.Add(new Plan()
            {
                Gb = 3,
                Minutes = 400,
                Sms = 2000,
                OperatorName = "Omnitel",
                PlanName = "Greitiems"
            });
            base.Seed(context);
        }
    }
}
