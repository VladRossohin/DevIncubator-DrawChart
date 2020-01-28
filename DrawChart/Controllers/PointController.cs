using ChartDraw.BLL.DTO;
using ChartDraw.BLL.Interfaces;
using ChartDraw.BLL.Services;
using DrawChart.Models;
using DrawChart.Models.db;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace DrawChart.Controllers
{
    public class PointController : ApiController
    {
        ApplicationContext context = new ApplicationContext();
        RequestController requestController = new RequestController();
        public List<PointViewModel> _points = new List<PointViewModel>();
        IPointService _pointService = new PointService();
        IUserDataService _userDataService = new UserDataService();

        public PointController() { }
        public PointController(IPointService pointService, IUserDataService userDataService)
        {
            _pointService = pointService;
            _userDataService = userDataService;
        }

        public List<PointViewModel> GetAllPoints()
        {
            return _points;
        }

        public void Add(PointViewModel point)
        {
            _points.Add(point);
        }

        public string toJSON(List<PointViewModel> points)
        {
            string serialized = JsonConvert.SerializeObject(points);
            return serialized;
        }

        public List<PointViewModel> fromJSON(string json)
        {
            List<PointViewModel> _points = JsonConvert.DeserializeObject<List<PointViewModel>>(json);
            return _points;
        }

        [HttpPost]
        public string Plot(UserDataViewModel plotRequest)
        {
            try
            {
                var userDataDTO = new UserDataDTO { A = plotRequest.A, B = plotRequest.B, C = plotRequest.C, PointFrom = plotRequest.PointFrom, PointTo = plotRequest.PointTo, Step = plotRequest.Step };
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
    /*public string Plot(UserDataViewModel plotRequest)
    {
        UserDataViewModel request = plotRequest;

        if (!requestController.Validate(request))
        {
            return BadRequest().ToString();
        }

        context.OpenConnection();

        var table = new DataTable();
        var adapter = new MySqlDataAdapter();
        MySqlCommand UserDataCommand = new MySqlCommand("insert into `userdata` (`RangeFrom`, `RangeTo`, `step`, `a`, `b`, `c`) values (" + request.PointFrom + ", " + request.PointTo + ", " + request.Step + ", " + request.A + ", " + request.B + ", " + request.C + ");");
        UserDataCommand.Connection = context.connection;
        UserDataCommand.ExecuteNonQuery();
        MySqlCommand UserDataIdCommand = new MySqlCommand("SELECT MAX(userdata.UserDataId) from `userdata`;");
        UserDataIdCommand.Connection = context.connection;
        int ChartId = int.Parse(UserDataIdCommand.ExecuteScalar().ToString());
        List<PointViewModel> points = new List<PointViewModel>();

        for (double i = request.PointFrom; i <= request.PointTo; i += request.Step)
        {
            if (request.PointFrom == request.PointTo)
            {
                break;
            }

            points.Add(new PointViewModel(i, request.A * i * i + request.B * i + request.C));
            MySqlCommand PointCommand = new MySqlCommand("INSERT INTO `points` (`ChartId`, `PointX`, `PointY`) VALUES (" + ChartId + ", " + i + ", " + points.LastOrDefault().Y + ");");
            PointCommand.Connection = context.connection;
            PointCommand.ExecuteNonQuery();

        }
        context.closeConnection();

        return JsonConvert.SerializeObject(points);
    }*/
}
