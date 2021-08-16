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
        private Point a;
        private Point b;
        private Point c;
        private Point d;

        public Point A
        {
            get { return a; }
            set { a = value;  }
        }

        public Point B
        {
            get { return b; }
            set { b = value; }
        }

        public Point C
        {
            get { return c; }
            set { c = value; }
        }

        public Point D
        {
            get { return d; }
            set { d = value; }
        }

        private Side ab;
        private Side bc;
        private Side cd;
        private Side ad;

        public Side AB
        {
            get { return ab; }
            private set { ab = value; }
        }

        public Side BC
        {
            get { return bc; }
            private set { bc = value; }
        }

        public Side CD
        {
            get { return cd; }
            private set { cd = value; }
        }

        public Side AD
        {
            get { return ad; }
            private set { ad = value; }
        }

        public Block()
        {

        }

        public Block(Point a, Point b, Point c, Point d)
        {
            A = a;
            B = b;
            C = c;
            D = d;

            AB = new Side(A, B);
            BC = new Side(B, C);
            CD = new Side(C, D);
            AD = new Side(D, A);

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
    }

    
}
