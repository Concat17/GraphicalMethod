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
        public static Size panelSize;
        public static PointF AxisCenter {get; set;}

        public Line(float a, float b, float c, bool isMore)
        {
            A = a;
            B = b;
            C = c;
            this.isMore = isMore; 

        }
         
        public static PointF ScalePoint(PointF p)
        { 
            var x = 30 * p.X + AxisCenter.X;
            var y = 30 * -p.Y + AxisCenter.Y;
            return new PointF(x, y);
        }  

        public void Draw(Graphics g, Pen pen)
        { 
            var line = GetLinesPoints(panelSize); 
            if (line.Count > 0)
                g.DrawLine(pen, line[0], line[line.Count - 1]);
        } 
         
        public List<PointF> GetLinesPoints(Size panelSize)
        { 
            List<PointF> linePoints = new List<PointF>();  
            if(B != 0)
            {
                float y;
                for (float x = 0; x < AxisCenter.X; x = x + 0.01f)
                {
                    y = -(A * x - C) / B;
                    if ((10 * (float)Math.Round(-y, 6) + AxisCenter.X) <= AxisCenter.X)  
                    {
                        linePoints.Add(ScalePoint(new PointF(x, y)));
                    }
                } 
            }
            else
            {
                float x;
                for (float y = 0; y < AxisCenter.Y; y = y + 0.01f) 
                { 
                    x = -(B * y - C) / A;
                    if ((10 * (float)Math.Round(-x, 6) + AxisCenter.Y) <= AxisCenter.Y)
                    {
                        linePoints.Add(ScalePoint(new PointF(x, y)));
                    }
                }
            }
            return linePoints;
        } 
         
        public static Line ShiftLine(Line z, PointF p)
        {
            var c = z.A * p.X + z.B * p.Y;
            return new Line(z.A, z.B, c, false);
        }

        public static float CalcZValue(Line z, PointF p)
        {
            return z.A * p.X + z.B * p.Y;
        }
    }
}
