using ChartDraw.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDraw.BLL.Interfaces
{
    public interface IUserDataService
    {
        void AddUserData(UserDataDTO userData);
        IEnumerable<UserDataDTO> GetAllUserDatas();
        //IEnumerable<PointDTO> GetPoints(UserDataDTO userData);
        List<PointDTO> Plot(UserDataDTO userData);
        void Dispose();

    }
}
