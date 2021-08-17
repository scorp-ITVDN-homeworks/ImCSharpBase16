using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Task01
{
    public class Block
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<Point> points;
        public List<Point> Points
        {
            get { return points; }
            set { points = value; }
        }

        private List<Side> sides = new List<Side>() { Capacity = 4, };
        public List<Side> Sides
        {
            get { return sides; }
            set { sides = value; }
        }

        public Block(string name, Point a, Point b, Point c, Point d)
        {
            this.name = name;

            Points = new List<Point>() { Capacity = 4, };
            Points.Add(a);
            Points.Add(b);
            Points.Add(c);
            Points.Add(d);

            Sides = new List<Side>() { Capacity = 4, };
            Sides.Add(new Side(Points[0],Points[1]));
            Sides.Add(new Side(Points[1], Points[2]));
            Sides.Add(new Side(Points[2], Points[3]));
            Sides.Add(new Side(Points[3], Points[0]));

        }

        public class Side
        {
            private Point startPoint;
            private Point endPoint;
            private double length;

            public Point StartPoint
            {
                get { return startPoint; }
            }

            public Point EndPoint
            {
                get { return endPoint; }
            }

            public double SideLength
            {
                get { GetSideLength(); return length; }
            }

            public Side(Point startPoint, Point endPoint)
            {
                this.startPoint = startPoint;
                this.endPoint = endPoint;
                GetSideLength();
            }
            
            public void GetSideLength()
            {
                if (startPoint.Equals(endPoint)) length = 0;

                if(startPoint.X == endPoint.X)
                {
                    length = Math.Abs(startPoint.Y - endPoint.Y);
                    return;
                }

                if(startPoint.Y == endPoint.Y)
                {
                    length = Math.Abs(startPoint.X - endPoint.X);
                    return;
                }

                double x = Math.Abs(startPoint.X - endPoint.Y);
                double y = Math.Abs(startPoint.Y - endPoint.Y);

                length = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            }
        }

        public static Block CreateBlock(string name, int width, int height, Point startPoint)
        {
            return new Block
                (
                name,
                startPoint,
                new Point(startPoint.X + width, startPoint.Y),
                new Point(startPoint.X + width, startPoint.Y + height),
                new Point(startPoint.X, startPoint.Y + height)
                );
        }

        public override bool Equals(object obj)
        {
            Block blockToCompare = (Block)obj;
            bool areEquals = false;
            int counter = 0;
            int step = 0;
            foreach(var side in Sides)
            {
                counter = step;
                for(int i = 0; i < blockToCompare.Sides.Count; i++)
                {
                    areEquals = Sides[counter].SideLength == blockToCompare.Sides[i].SideLength;
                    if (areEquals == false) break;
                    counter++;
                    if (counter > Sides.Count - 1) counter = 0;
                }
                if (areEquals == true) break;
                step++;
            }

            return areEquals;
        }
    }

    
}
