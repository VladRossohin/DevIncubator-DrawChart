using ChartDraw.BLL.DTO;
using ChartDraw.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDraw.BLL.Services
{
    public class PointService : IPointService
    {
        public void AddPoint(PointDTO point)
        {
            
        }

        public IEnumerable<PointDTO> GetAllPoints()
        {
            throw new NotImplementedException();
        }

        public UserDataDTO GetUserData(PointDTO point)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
