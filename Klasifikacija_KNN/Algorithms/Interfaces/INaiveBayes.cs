using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Klasifikacija_KNN.Domain.Entities;

namespace Klasifikacija_KNN.Algorithms.Interfaces
{
    public interface INaiveBayes<in T, in TModel, out TOut>
    {
        void AddTrainingSet(IEnumerable<T> trainingSet);
        IEnumerable<TOut> CalculateProbabilities(TModel sample);
    }
}
