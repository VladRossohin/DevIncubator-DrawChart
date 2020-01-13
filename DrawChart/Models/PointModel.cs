using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawChart.Models
{
    public class PointModel
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointModel() { }
        public PointModel(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}