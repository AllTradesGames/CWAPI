using System;
using System.Collections.Generic;

namespace CWAPI
{
    public class Point
    {
        public Point(int in_x, int in_y)
        {
            X = in_x;
            Y = in_y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
