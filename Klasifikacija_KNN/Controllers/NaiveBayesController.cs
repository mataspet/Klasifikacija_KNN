using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Klasifikacija_KNN.Algorithms;
using Klasifikacija_KNN.Domain.Abstract;
using Klasifikacija_KNN.Models.ViewModels;

namespace Klasifikacija_KNN.Controllers
{
    public class NaiveBayesController : Controller
    {
        private IPlanRepository _planRepository;
        private NaiveBayes _naiveBayes;
        public NaiveBayesController(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
            _naiveBayes = new NaiveBayes();
            _naiveBayes.AddTrainingSet(_planRepository.People);
        }

        // GET: NaiveBayes
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Result(PersonSample sample)
        {
            _naiveBayes.GenerateVariables();
            var result = _naiveBayes.CalculateProbabilities(sample).OrderByDescending(x => x.Probability).ToList();
            
            return PartialView("Table", new TableViewModel() { Results = result, Winner = result.FirstOrDefault(x => x.Probability == result.Max(y => y.Probability))});
        }
    }
}