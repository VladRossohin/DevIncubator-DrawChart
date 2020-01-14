﻿using DrawChart.Models;
using DrawChart.Models.db;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DrawChart.Controllers
{
    public class PointController : ApiController
    {
        ApplicationContext context = new ApplicationContext();
        RequestController requestController = new RequestController();
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
            if (!requestController.Validate(request)) return BadRequest().ToString();
            context.OpenConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand UserDataCommand = new MySqlCommand("insert into `userdata` (`RangeFrom`, `RangeTo`, `step`, `a`, `b`, `c`) values (" + request.XFrom + ", " + request.XTo + ", " + request.Step + ", " + request.A + ", " + request.B + ", " + request.C + ");");
            UserDataCommand.Connection = context.connection;
            //UserDataCommand.Connection.Open();
            UserDataCommand.ExecuteNonQuery();
            //UserDataCommand.Connection.Close();
            MySqlCommand UserDataIdCommand = new MySqlCommand("SELECT MAX(userdata.UserDataId) from `userdata`;");
            UserDataIdCommand.Connection = context.connection;
            //UserDataIdCommand.Connection.Open();
            int ChartId = int.Parse(UserDataIdCommand.ExecuteScalar().ToString());
            //ChartId = 1;
            //UserDataIdCommand.Connection.Close();
            List<PointModel> points = new List<PointModel>();
            for (double i = request.XFrom; i <= request.XTo; i += request.Step)
            {
                if (request.XFrom == request.XTo) break;
                points.Add(new PointModel(i, request.A * i * i + request.B * i + request.C));
                MySqlCommand PointCommand = new MySqlCommand("INSERT INTO `points` (`ChartId`, `PointX`, `PointY`) VALUES (" + ChartId + ", " + i + ", " + points.LastOrDefault().Y + ");");
                PointCommand.Connection = context.connection;
                //PointCommand.Connection.Open();
                PointCommand.ExecuteNonQuery();
                //PointCommand.Connection.Close();

            }
            context.closeConnection();

            return JsonConvert.SerializeObject(points);
        }
    }
}