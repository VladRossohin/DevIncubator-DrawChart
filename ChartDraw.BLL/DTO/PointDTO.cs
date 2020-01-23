using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDraw.BLL.DTO
{
    public class PointDTO
    {
        public int Id { get; set; }
        public int UserDataId { get; set; }
        public double PointX { get; set; }
        public double PointY { get; set; }
    }
}
