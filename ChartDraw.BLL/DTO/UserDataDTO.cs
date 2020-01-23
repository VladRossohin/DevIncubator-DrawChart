using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDraw.BLL.DTO
{
    public class UserDataDTO
    {
        public int Id { get; set; } 
        public double PointFrom { get; set; }
        public double PointTo { get; set; }
        public double Step { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
    }
}
