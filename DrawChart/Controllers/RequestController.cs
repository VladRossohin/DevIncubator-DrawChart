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
        public RequestViewModel fromJSON(string plotRequest)
        {
            RequestViewModel _request = JsonConvert.DeserializeObject<RequestViewModel>(plotRequest);
            return _request;
        }
        public bool Validate(RequestViewModel request) {
            if (Math.Abs(request.A) > 1000 || Math.Abs(request.B) > 1000 || Math.Abs(request.C) > 1000)
            {
                return false;
            }
            if (request.Step <= 0)
            {
                return false;
            }
            if ((Math.Abs(request.XFrom) + Math.Abs(request.XTo)) / Math.Abs(request.Step) > 1000)
            {
                return false;
            }
            return true;
        }
    }
}