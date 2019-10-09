using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicalMethod
{
    public class Line
    {
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }
        public bool isMore { get; set; }

        public Line(float a, float b, float c, bool isMore)
        {
            A = a;
            B = b;
            C = c;
            this.isMore = isMore;
            //Simplify(); 
        }

        public void Simplify()// A = 3 B = 2 C = 12
        {
            if(B > 0)
            {
                A = -A;
            }
            else
            {
                B = -B;
                C = -C;
                isMore = !isMore;
            }
        }

        public void Draw(Graphics g, Size size, Pen pen)
        {
            //var p0 = GetPoint0(size);
            //var p1 = GetPoint1(size);
            //p0 = ScalePoint(p0, size);
            //p1 = ScalePoint(p1, size);
            //g.DrawLine(pen, p0, p1);
            var l1 = GetLinesPoints(size);

            if (l1.Count > 0)
                g.DrawLine(pen, l1[0], l1[l1.Count - 1]);
        } 

        public PointF GetPoint0(Size s)//y = -(Ax - C)/ B
        {
            var x = 0;
            var y = -(A * x - C) / B;
            return new PointF(x, y);
        }

        public PointF GetPoint1(Size s)//x = -(By - C) / A
        {
            var y = 0;
            var x = -(B * y - C) / A;
            return new PointF(x, y);
        }

        public List<PointF> GetLinesPoints(Size p)
        {

            List<PointF> l = new List<PointF>(); //Ax + By + C = 0   y = -(Ax - C)/ B
            float y;

            for (float j = 0; j < p.Width / 2; j = j + 0.01f) // t1 = C t2 = A t3 = B
            {
                //y = (C - A * j) / B;
                y = -(A * j - C) / B;

                if ((10 * (float)Math.Round(-y, 6) + p.Height / 2) <= p.Height / 2)
                {
                    l.Add(new PointF(10 * (float)j + p.Width / 2, 10 * (float)-y + p.Height / 2));
                }
            }
            return l;
        }

        public PointF Intersect(Line l2)
        {
            var A1 = A;
            var B1 = B;
            var C1 = C;
            var A2 = l2.A;
            var B2 = l2.B;
            var C2 = l2.C;
            float delta = A1 * B2 - A2 * B1;

            if (delta == 0)
                throw new ArgumentException("Lines are parallel");

            float x = (B2 * C1 - B1 * C2) / delta;
            float y = (A1 * C2 - A2 * C1) / delta;
            return new PointF(x, y);
        }

        public PointF ScalePoint(PointF p, Size s)
        {
            PointF l = new PointF();
            //if ((10 * (float)Math.Round(-p.Y, 6) + s.Height / 2) <= s.Height / 2)
            //{
            //    //l.Add(new PointF(10 * (float)j + s.Width / 2, 10 * (float)-y + s.Height / 2));
            //    l.X = 10 * p.X + s.Width / 2;
            //    l.Y = 10 * -p.Y + s.Height / 2;
            //}
            l.X = 10 * p.X + s.Width / 2;
            l.Y = 10 * -p.Y + s.Height / 2;
            return l;
        }
    }
}
