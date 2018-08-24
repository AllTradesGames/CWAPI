using System;

namespace CWAPI
{
    public class Triangle
    {
        private int row = 0;

        public string Row
        {
            get { return Utilities.RowFromNumber(row); }
            set { row = Utilities.NumberFromRow(value); }
        }
        public int Column { get; set; }

        public Triangle(string in_row, int in_column)
        {
            Row = in_row;
            Column = in_column;
        }

        public Triangle(Point[] in_points)
        {
            // Calculate / set row and Column
            Point idPoint = new Point(-1, -1);
            if (in_points != null)
            {
                for (int ii = 0; ii < in_points.Length; ii++)
                {
                    if (in_points[ii].X % 10 == in_points[ii].Y % 10)
                    {
                        if (row != 0)
                            continue;
                        if (in_points[ii].Y % 10 == 0)
                        {
                            row = (in_points[ii].Y / 10) + 1;
                        }
                        else
                        {
                            row = ((in_points[ii].Y - 9) / 10) + 1;
                        }
                    }
                    else
                    {
                        idPoint = in_points[ii];
                    }
                }
            }

            if (idPoint.X == -1)
            {
                // Input points were invalid, throw error
                throw new Exception("Input points were invalid.");
            }
            else if (idPoint.X % 10 == 0)
            {
                Column = (idPoint.X / 5) + 1;
            }
            else
            {
                Column = (idPoint.X + 1) / 5;
            }
        }


        public Point[] GetPoints()
        {
            Point[] points = new Point[3];
            int col = (int)Math.Round((float)Column / 2f);
            points[0] = new Point((col - 1) * 10, (row - 1) * 10);
            points[1] = new Point(points[0].X + 9, points[0].Y + 9);
            if (Column % 2 == 0)
            {
                points[2] = new Point(points[0].X + 9, points[0].Y);
            }
            else
            {
                points[2] = new Point(points[0].X, points[0].Y + 9);
            }
            return points;
        }
    }
}
