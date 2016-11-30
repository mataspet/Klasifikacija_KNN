using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using Klasifikacija_KNN.Domain.Abstract;
using Klasifikacija_KNN.Models;


namespace Klasifikacija_KNN.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private readonly IPlanRepository _planRepository;
        private readonly IDistanceCalculator _distanceCalculator;

        public HomeController(IPlanRepository planRepository, IDistanceCalculator distanceCalculator)
        {
            _planRepository = planRepository;
            _distanceCalculator = distanceCalculator;
        }

        public ActionResult Index()
        {
            var userPlan = new UserPlan
            {
                AlgorithmList = new []
                {
                    new System.Web.Mvc.SelectListItem {Value = "0", Text = "Euklido"},
                    new System.Web.Mvc.SelectListItem { Value = "1", Text = "Manhatano"},
                    new System.Web.Mvc.SelectListItem { Value = "2", Text = "Čebyševo"}
                }
            };
            return View(userPlan);
        }
        
        public ActionResult CalculateDistances(UserPlan userPlan)
        {
            var userPlanParams = new List<double> { userPlan.UserMinutes, userPlan.UserSms, userPlan.UserGb};
            switch (userPlan.SelectedId)
            {
                case 0:
                    return View(_distanceCalculator.EuclideanDistance(_planRepository.Plans, userPlanParams));
                case 1:
                    return View(_distanceCalculator.ManhattanDistance(_planRepository.Plans, userPlanParams));
                case 2:
                    return View(_distanceCalculator.ManhattanDistance(_planRepository.Plans, userPlanParams));
                default:
                    return View(_distanceCalculator.EuclideanDistance(_planRepository.Plans, userPlanParams));
            }
        }
    }
}