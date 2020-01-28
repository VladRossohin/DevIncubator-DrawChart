using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDraw.DAL.Entities
{
    public class Point
    {
        public int Id { get; set; }
        public int UserDataId { get; set; }
        public double PointX { get; set; }
        public double PointY { get; set; }
        public UserData UserData { get; set; }

        public Point()
        {
        }

        public Point(int userDataId, double pointX, double pointY, UserData userData)
        {
            UserDataId = userDataId;
            PointX = pointX;
            PointY = pointY;
            UserData = userData;
        }

        public Point(int id, int userDataId, double pointX, double pointY, UserData userData)
        {
            Id = id;
            UserDataId = userDataId;
            PointX = pointX;
            PointY = pointY;
            UserData = userData;
        }
    }
}
