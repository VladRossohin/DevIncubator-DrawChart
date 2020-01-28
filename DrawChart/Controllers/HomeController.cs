using ChartDraw.BLL.DTO;
using ChartDraw.BLL.Interfaces;
using DrawChart.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DrawChart.Controllers
{
    public class HomeController : Controller
    {
        IPointService _pointService;
        IUserDataService _userDataService;

        public HomeController(IPointService pointService, IUserDataService userDataService)
        {
            _pointService = pointService;
            _userDataService = userDataService;
        }
public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [System.Web.Http.HttpPost]
        public string Plot(UserDataViewModel plotRequest)
        {
            try
            {
                var userDataDTO = new UserDataDTO { A = plotRequest.A, B = plotRequest.B, C = plotRequest.C, PointFrom = plotRequest.PointFrom, PointTo = plotRequest.PointTo };
                _userDataService.AddUserData(userDataDTO);
                List<PointDTO> pointDTOs = new List<PointDTO>();
                pointDTOs = _userDataService.Plot(userDataDTO);
                return JsonConvert.SerializeObject(pointDTOs);
            }
            catch (ValidationException ex)
            {
                return ex.ToString();
            }
        }
    }
}
