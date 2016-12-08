using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Accord.Statistics.Distributions.Fitting;
using Accord.Statistics.Distributions.Univariate;
using Klasifikacija_KNN.Algorithms.Interfaces;
using Klasifikacija_KNN.Domain.Abstract;
using Klasifikacija_KNN.Domain.Entities;

namespace Klasifikacija_KNN.Algorithms
{
    public class NaiveBayes : INaiveBayes<Person, PersonSample, PersonResult>
    {
        private readonly IList<Person> _trainingSet;

        private readonly IDictionary<Gender, IList<double>> _genderVariables;

        //private double _weightAverage = 0;
        //private double _weightDeviation = 0;
        //private double _heightAverage = 0;
        //private double _heightDeviation = 0;
        //private int _footSizeAverage = 0;
        //private int _footSizeDeviation = 0;

        public NaiveBayes()
        {
            _trainingSet = new List<Person>();
            _genderVariables = new Dictionary<Gender, IList<double>>();
        }

        public void AddTrainingSet(IEnumerable<Person> trainingSet)
        {
            foreach(var person in trainingSet)
                _trainingSet.Add(person);
        }

        public void GenerateVariables()
        {
            GenerateVariables(_trainingSet);
        }

        public IEnumerable<PersonResult> CalculateProbabilities(PersonSample sample)
        {
            var maleProbabilities = CalculateGenderProbabilities(sample, Gender.Male);
            var femaleProbabilities = CalculateGenderProbabilities(sample, Gender.Female);

            var malePosterior = (_genderVariables[Gender.Male][0]*maleProbabilities.Item1*maleProbabilities.Item2*
                                 maleProbabilities.Item3);

            var femalePosterior = (_genderVariables[Gender.Female][0]*femaleProbabilities.Item1*
                                   femaleProbabilities.Item2 *
                                   femaleProbabilities.Item3);

            return new List<PersonResult>()
            {
                new PersonResult()
                {
                    Gender = Gender.Male,
                    Probability = malePosterior
                },
                new PersonResult()
                {
                    Gender = Gender.Female,
                    Probability = femalePosterior
                }
            };
        }

        private Tuple<double, double, double> CalculateGenderProbabilities(PersonSample sample, Gender gender)
        {
            var sampleVariableList = new List<double> {sample.Weight, sample.Height, sample.FootSize};
            var probabilityList = new List<double>();
            var j = 0;
            for (var i = 1; i < _genderVariables[gender].Count; i += 2)
            {
                var firstPart = 1 / Math.Sqrt(2 *Math.PI * Math.Pow(_genderVariables[gender][i+1], 2));

                var secondPart1 = -Math.Pow(sampleVariableList[j] - _genderVariables[gender][i], 2);
                var secondPart2 = 2 * Math.Pow(_genderVariables[gender][i + 1], 2);
                var secondPart = secondPart1/secondPart2;
                var result = firstPart*Math.Exp(secondPart);
                probabilityList.Add(result);
                j++;
            }
            return new Tuple<double, double, double>(probabilityList[0], probabilityList[1], probabilityList[2]);
        }


        private void GenerateVariables(ICollection<Person> list)
        {
            var male = list.Where(x => x.Gender == Gender.Male).ToList();
            var female = list.Where(x => x.Gender == Gender.Female).ToList();

            var weight = GetVariables(male.Select(x => x.Weight));
            var height = GetVariables(male.Select(x => x.Height));
            var footSize = GetVariables(male.Select(x => (double) x.FootSize));
            var distribution = (double) male.Count/list.Count;

            _genderVariables.Add(Gender.Male, new List<double> { distribution, weight.Item1, weight.Item2, height.Item1, height.Item2, footSize.Item1, footSize.Item2 });

            weight = GetVariables(female.Select(x => x.Weight));
            height = GetVariables(female.Select(x => x.Height));
            footSize = GetVariables(female.Select(x => (double)x.FootSize));
            distribution = (double)female.Count / list.Count;

            _genderVariables.Add(Gender.Female, new List<double> { distribution, weight.Item1, weight.Item2, height.Item1, height.Item2, footSize.Item1, footSize.Item2 });
        }

        private static Tuple<double, double> GetVariables(IEnumerable<double> values)
        {
            var enumerable = values as IList<double> ?? values.ToList();

            if (!enumerable.Any())
                return null;

            var average = enumerable.Average();

            var sum = enumerable.Sum(v => Math.Pow(v - average, 2));

            return new Tuple<double, double>(average, Math.Sqrt((sum)/(enumerable.Count())));
        }
    }
}