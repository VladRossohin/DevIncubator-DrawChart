using ChartDraw.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDraw.BLL.Interfaces
{
    public interface IPointService
    {
        void AddPoint(PointDTO point);
        IEnumerable<PointDTO> GetAllPoints();
        UserDataDTO GetUserData(PointDTO point);
        void Dispose();
    }
}
