using DrawChart.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrawChart.Controllers
{
    public class RequestController : Controller
    {
        public UserDataViewModel fromJSON(string plotRequest)
        {
            UserDataViewModel _request = JsonConvert.DeserializeObject<UserDataViewModel>(plotRequest);
            return _request;
        }
        public bool Validate(UserDataViewModel request) {
            if (Math.Abs(request.A) > 1000 || Math.Abs(request.B) > 1000 || Math.Abs(request.C) > 1000)
            {
                return false;
            }
            if (request.Step <= 0)
            {
                return false;
            }
            if ((Math.Abs(request.PointFrom) + Math.Abs(request.PointTo)) / Math.Abs(request.Step) > 1000)
            {
                return false;
            }
            return true;
        }
    }
}