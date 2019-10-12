using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalMethod
{
    static class PointManipulator
    {
        static Line Ax = new Line(1, 0, 0, false);
        static Line Ay = new Line(0, 1, 0, false);

        public static List<PointF> getFigurePoints(Line l1, Line l2, Line l3, Size s)
        {
            var points = FindAndFilter(l1, l2, l3); 
            var sortedPoints = SortPoints(points); 
            var scaledPoints = sortedPoints.Select(p => Line.ScalePoint(p)).ToList(); 
            return scaledPoints;
        }

        public static List<PointF> FindPoints(Line l1, Line l2, Line l3)
        {
            List<PointF> points = new List<PointF>();
            List<Line> lines = new List<Line>() { l1, l2, l3, Ax, Ay };
            while (lines.Count > 0)
            {
                for (var i = 1; i < lines.Count; i++)
                {
                    var delta = Delta(lines[0], lines[i]);
                    if(delta != 0)
                    {
                        var intersection = Intersect(lines[0], lines[i], delta);
                        points.Add(intersection);
                    } 
                }
                lines.RemoveAt(0);
            } 
            return points;
        } 

        public static PointF Intersect(Line l1, Line l2, float delta)
        {  
            float x = (l2.B * l1.C - l1.B * l2.C) / delta;
            float y = (l1.A * l2.C - l2.A * l1.C) / delta;
            return new PointF(x, y);
        }

        private static float Delta(Line l1, Line l2)
        {
            return l1.A * l2.B - l2.A * l1.B;
        }

        public static List<PointF> FindAndFilter(Line l1, Line l2, Line l3)
        { 
            var filteredPoints = new List<PointF>();
            var points = FindPoints(l1, l2, l3);
            foreach(var point in points)
            {
                if (isFirstQuarter(point) && isInAllAreas(l1, l2, l3, point))
                    filteredPoints.Add(point);
            }
            return filteredPoints;
        }

        private static bool isFirstQuarter(PointF p)
        {
            return p.X >= 0 && p.Y >= 0;
        }

        private static bool isInAllAreas(Line l1, Line l2, Line l3, PointF point)
        {
            return isLand(l1, point) && isLand(l2, point) && isLand(l3, point);
        }

        public static bool isLand(Line line, PointF point)
        {
            var rightPart = line.A * point.X + line.B * point.Y;
            rightPart = RidOfMantissa(rightPart);
            if (rightPart >= line.C && line.isMore || rightPart <= line.C && !line.isMore)
                return true;
            return false;
        }

        private static float RidOfMantissa(float number)
        {
            return (float)Math.Round(number, 3);
        } 

        static List<PointF> SortPoints(List<PointF> points)
        {
            var PointsCopy = new List<PointF>(points);
            var sorted = new List<PointF>();
            sorted.Add(PointsCopy[PointsCopy.Count - 1]);
            PointsCopy.RemoveAt(PointsCopy.Count - 1);
            while (PointsCopy.Count > 0)
            {
                int indAdjacent = FindAdjacent(sorted[sorted.Count - 1], PointsCopy);
                sorted.Add(PointsCopy[indAdjacent]);
                PointsCopy.RemoveAt(indAdjacent);
            }
            return sorted;
        }

        private static int FindAdjacent(PointF lastP, List<PointF> cPoints)
        {
            var ind = 0;
            for (var i = 0; i < cPoints.Count; i++)
            {
                if (isAdjacent(lastP, cPoints[i], cPoints))
                    return i;
            }
            return ind;
        }

        private static bool isAdjacent(PointF lp1, PointF lp2, List<PointF> cPoints)
        {
            var side = 0;
            foreach (var p in cPoints)
            {
                if (lp2 == p)
                    continue;
                if (side == 0)
                {
                    side = getPointSide(lp1, lp2, p);
                }
                else
                {
                    if (side != getPointSide(lp1, lp2, p))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static int getPointSide(PointF lp1, PointF lp2, PointF p)
        {
            if ((p.X - lp1.X) / (lp2.X - lp1.X) - (p.Y - lp1.Y) / (lp2.Y - lp1.Y) > 0)
                return 2;
            return 1;
        } 

        public static PointF MaxZ(Line z, Line l1, Line l2, Line l3)
        {
            var points = FindAndFilter(l1, l2, l3);
            float max = float.NegativeInfinity;
            PointF maxPoint = new PointF(0, 0);
            foreach(var point in points)
            {
                var m = z.A * point.X + z.B * point.Y;
                if(m > max)
                {
                    max = m;
                    maxPoint = point;
                }
            }
            return maxPoint;
        }

        public static PointF MinZ(Line z, Line l1, Line l2, Line l3)
        {
            var points = FindAndFilter(l1, l2, l3);
            float min = float.PositiveInfinity;
            PointF minPoint = new PointF(0, 0);
            foreach (var point in points)
            {
                var m = z.A * point.X + z.B * point.Y;
                if (m < min)
                {
                    min = m;
                    minPoint = point;
                }
            }
            return minPoint;
        }
    } 
}
