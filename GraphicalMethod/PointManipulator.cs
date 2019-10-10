﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalMethod
{
    class PointManipulator
    {
        static Line Ax = new Line(1, 0, 0, false);
        static Line Ay = new Line(0, 1, 0, false);

        public static List<PointF> getFigurePoints(Line l1, Line l2, Line l3, Size s)
        {
            var points = FilterPoints(l1, l2, l3);
            var scaledPoints = points.Select(p => Line.ScalePoint(p)).ToList();
            var res = scaledPoints.Where(p => p.X >= s.Width / 2 && p.Y <= s.Height / 2).ToList();
            return res;
        }

        public static List<PointF> FindPoints(Line l1, Line l2, Line l3)
        {
            List<PointF> points = new List<PointF>();
            points.Add(GetScaledPoint(l1, l2));
            points.Add(GetScaledPoint(l1, l3));
            points.Add(GetScaledPoint(l2, l3));
            points.Add(GetScaledPoint(l1, Ax));
            points.Add(GetScaledPoint(l2, Ax));
            points.Add(GetScaledPoint(l3, Ax));
            points.Add(GetScaledPoint(l1, Ay));
            points.Add(GetScaledPoint(l2, Ay));
            points.Add(GetScaledPoint(l3, Ay));
            return points;
        }

        public static PointF GetScaledPoint(Line l1, Line l2)
        {
            var intr3 = Intersect(l1, l2); 
            return intr3;
        }

        public static PointF Intersect(Line l1, Line l2)
        { 
            float delta = l1.A * l2.B - l2.A * l1.B;

            if (delta == 0)
                throw new ArgumentException("Lines are parallel");

            float x = (l2.B * l1.C - l1.B * l2.C) / delta;
            float y = (l1.A * l2.C - l2.A * l1.C) / delta;
            return new PointF(x, y);
        }

        public static List<PointF> FilterPoints(Line l1, Line l2, Line l3)
        {
            var points = FindPoints(l1, l2, l3);
            var filteredPoints = new List<PointF>();
            foreach(var point in points)
            {
                if (isLand(l1, point) && isLand(l2, point) && isLand(l3, point))
                    filteredPoints.Add(point);
            }
            return filteredPoints;
        }

        public static bool isLand(Line line, PointF point)
        {
            var rightPart = line.A * point.X + line.B * point.Y;
            rightPart = (float)Math.Round(rightPart, 3);
            if (rightPart >= line.C && line.isMore || rightPart <= line.C && !line.isMore)
                return true;
            return false;
        }
         
    } 
}
