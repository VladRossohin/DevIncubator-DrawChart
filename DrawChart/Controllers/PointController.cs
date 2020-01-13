using DrawChart.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DrawChart.Controllers
{
    public class PointController : ApiController
    {
        public List<PointModel> _points = new List<PointModel>();
        public List<PointModel> GetAllPoints()
        {
            return _points;
        }
        public void Add(PointModel point)
        {
            _points.Add(point);
        }
        public string toJSON(List<PointModel> points)
        {
            string serialized = JsonConvert.SerializeObject(points);
            return serialized;
        }
        public List<PointModel> fromJSON(string json)
        {
            List<PointModel> _points = JsonConvert.DeserializeObject<List<PointModel>>(json);
            return _points;
        }

        [System.Web.Http.HttpPost]
        public string Plot(RequestModel plotRequest)
        {
            /*  Console.WriteLine(plotRequest.ToString());        
              RequestModel request = JsonConvert.DeserializeObject<RequestModel>(plotRequest.ToString());
            */  
            //RequestModel request = JsonConvert.DeserializeObject<RequestModel>(await this.Request.Content.ReadAsStringAsync());
            RequestModel request = plotRequest;
            List<PointModel> points = new List<PointModel>();
            for (double i = request.XFrom; i <= request.XTo; i += request.Step)
            {
                if (request.XFrom == request.XTo) break;
                points.Add(new PointModel(i, request.A * i * i + request.B * i + request.C));
            }
            return JsonConvert.SerializeObject(points);
        }
    }
}