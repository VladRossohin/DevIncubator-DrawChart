using DrawChart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrawChart.Controllers
{
    public class HomeController : Controller
    {
        private PointController pointController = new PointController();
        private RequestController requestController = new RequestController();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpPost]
        public ActionResult Plot(RequestViewModel plotRequest)
        {
            RequestViewModel request = plotRequest;
            List<PointViewModel> points = new List<PointViewModel>();
            for (double i = request.XFrom; i <= request.XTo; i += request.Step)
            {
                points.Add(new PointViewModel(i, request.A * i * i + request.B * i + request.C));
            }
            ViewBag.plotData = pointController.toJSON(points);
            return View(points);
        }
    }
}
