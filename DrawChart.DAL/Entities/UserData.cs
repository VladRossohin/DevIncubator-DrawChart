using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDraw.DAL.Entities
{
    public class UserData
    {
        public int Id { get; set; }
        public double PointFrom { get; set; }
        public double PointTo { get; set; }
        public double Step { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public ICollection<Point> Points { get; set; }

        public UserData()
        {
        }

        public UserData(double pointFrom, double pointTo, double step, double a, double b, double c)
        {
            PointFrom = pointFrom;
            PointTo = pointTo;
            Step = step;
            A = a;
            B = b;
            C = c;
        }

        public UserData(double pointFrom, double pointTo, double step, double a, double b, double c, ICollection<Point> points)
        {
            PointFrom = pointFrom;
            PointTo = pointTo;
            Step = step;
            A = a;
            B = b;
            C = c;
            Points = points;
        }

        public UserData(int id, double pointFrom, double pointTo, double step, double a, double b, double c, ICollection<Point> points)
        {
            Id = id;
            PointFrom = pointFrom;
            PointTo = pointTo;
            Step = step;
            A = a;
            B = b;
            C = c;
            Points = points;
        }
    }
}
