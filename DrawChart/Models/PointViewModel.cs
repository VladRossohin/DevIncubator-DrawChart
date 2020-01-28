using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawChart.Models
{
    public class PointViewModel
    {
        public int PointId { get; set; }
        public int UserDataId { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public PointViewModel() { }
        public PointViewModel(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}