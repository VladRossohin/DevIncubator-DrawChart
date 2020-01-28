using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawChart.Models
{
    public class UserDataViewModel
    {
        public int Id { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double Step { get; set; }
        public double PointFrom { get; set; }
        public double PointTo { get; set; }
        public UserDataViewModel() { }
        public UserDataViewModel(double a, double b, double c, double step, double xFrom, double xTo)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            this.Step = step;
            this.PointFrom = xFrom;
            this.PointTo = xTo;
        }
    }
}