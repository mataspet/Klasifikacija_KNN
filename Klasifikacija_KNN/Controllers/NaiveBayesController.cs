using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Klasifikacija_KNN.Algorithms;
using Klasifikacija_KNN.Domain.Abstract;

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
            var result = _naiveBayes.Decide(sample);
            TempData["gender"] = result.Gender.ToString();
            return PartialView("Table");
        }
    }
}