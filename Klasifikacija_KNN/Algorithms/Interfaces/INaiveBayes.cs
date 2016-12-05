using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Klasifikacija_KNN.Domain.Entities;

namespace Klasifikacija_KNN.Algorithms.Interfaces
{
    public interface INaiveBayes<T, in TModel>
    {
        void AddTrainingSet(IEnumerable<T> trainingSet);
        T Decide(TModel sample);
    }
}
