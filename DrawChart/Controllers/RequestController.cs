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
        public RequestModel fromJSON(string plotRequest)
        {
            RequestModel _request = JsonConvert.DeserializeObject<RequestModel>(plotRequest);
            return _request;
        }
    }
}