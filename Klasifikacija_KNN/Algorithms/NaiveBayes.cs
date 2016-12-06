using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Accord.MachineLearning.Bayes;
using Accord.Statistics.Distributions.Fitting;
using Accord.Statistics.Distributions.Univariate;
using Klasifikacija_KNN.Algorithms.Interfaces;
using Klasifikacija_KNN.Domain.Abstract;
using Klasifikacija_KNN.Domain.Entities;

namespace Klasifikacija_KNN.Algorithms
{
    public class NaiveBayes : INaiveBayes<Person, PersonSample>
    {
        private readonly IList<Person> _trainingSet;

        public NaiveBayes()
        {
            _trainingSet = new List<Person>();
        }

        public void AddTrainingSet(IEnumerable<Person> trainingSet)
        {
            foreach(var person in trainingSet)
                _trainingSet.Add(person);
        }

        public Person Decide(PersonSample sample)
        {
            var inputs = GetInputs(_trainingSet);

            var outputs = GetOutputs(_trainingSet);

            var learner = new NaiveBayesLearning<NormalDistribution>
            {
                Options =
                {
                    InnerOption = new NormalOptions()
                    {
                        Regularization = 1e-5
                    }
                }
            };

            var answerer = learner.Learn(inputs, outputs);

            var gender = (Gender) answerer.Decide(new[] {sample.Weight, sample.Height, sample.FootSize});

            return new Person() {Gender = gender};
        }

        private static double[][] GetInputs(IList<Person> list)
        {
            var inputs = new double[list.Count][];

            for (var i = 0; i < list.Count; i++)
            {
                var currentItem = list[i];

                inputs[i] = new double[3];

                inputs[i][0] = currentItem.Weight;
                inputs[i][1] = currentItem.Height;
                inputs[i][2] = currentItem.FootSize;
            }

            return inputs;
        }

        private static int[] GetOutputs(IList<Person> list)
        {
            var inputs = new int[list.Count];

            for (var i = 0; i < list.Count; i++)
            {
                var currentItem = list[i];

                inputs[i] = (int) currentItem.Gender;
            }

            return inputs;
        }
    }
}