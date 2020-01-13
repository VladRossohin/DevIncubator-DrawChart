using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawChart.Models
{
    public class RequestModel
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double Step { get; set; }
        public double XFrom { get; set; }
        public double XTo { get; set; }
        public RequestModel() { }
        public RequestModel(double a, double b, double c, double step, double xFrom, double xTo)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            this.Step = step;
            this.XFrom = xFrom;
            this.XTo = xTo;
        }
    }
}