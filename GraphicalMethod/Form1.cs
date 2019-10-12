using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System;
using System.Collections.Generic;

/*
 * 1 Interface
 * 2 Line Class
 * 3 Draw Line Method (Class Drawer?)
 * 4 Points Finder
 * 5 Filter
 * 6 Polygon drawing
 * 7 Fix Stack overflow at examples like this: x <= 4
 * 8 Add Z-func and vector n
 * 9 Implement finding max and min
 */
namespace GraphicalMethod
{
    public partial class Form1 : Form
    {
        Line lineZ;
        Line line1;
        Line line2;
        Line line3;
        Line lineMin;
        Line lineMax;

        PointF[] polygon;

        bool isResPressed;

        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            Line.panelSize = panel1.Size;
            isResPressed = false;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawAxis(g);
            if (isResPressed)
            { 
                g.FillPolygon(Brushes.Pink, polygon);
                line1.Draw(g, Pens.Red);
                line2.Draw(g, Pens.Green);
                line3.Draw(g, Pens.Blue);
                lineMax.Draw(g, Pens.Olive);
                lineMin.Draw(g, Pens.Black);
            }
        }

        private void DrawAxis(Graphics g)
        { 
            g.DrawLine(Pens.LightBlue, panel1.Width / 2, 0, panel1.Width / 2, panel1.Height);
            g.DrawLine(Pens.LightBlue, 0, panel1.Height / 2, panel1.Width, panel1.Height / 2);
        }

        private void BtnRes_Click(object sender, System.EventArgs e)
        {
            ExtractLines();
            polygon = PointManipulator.getFigurePoints(line1, line2, line3, panel1.Size).ToArray(); 

            txbMin.Text = FindSolution(PointManipulator.MinZ).ToString();
            lineMin = InitLine(lineMin, PointManipulator.MinZ); 

            txbMax.Text = FindSolution(PointManipulator.MaxZ).ToString();
            lineMax = InitLine(lineMax, PointManipulator.MaxZ);

            isResPressed = true;
            panel1.Invalidate();
        }

        private void ExtractLines()
        {
            lineZ = extractZLine();
            line1 = extractLine(txb11, txb12, txb13, cmb1);
            line2 = extractLine(txb21, txb22, txb23, cmb2);
            line3 = extractLine(txb31, txb32, txb33, cmb3);
        }

        private Line extractLine(TextBox txb1, TextBox txb2, TextBox txb3, ComboBox cmb)
        {
            var A = int.Parse(txb1.Text);
            var B = int.Parse(txb2.Text);
            var C = int.Parse(txb3.Text);
            var sign = cmb.Text == "≥"; 
            return new Line(A, B, C, sign);
        }

        private Line extractZLine()
        {
            var A = int.Parse(txbZ1.Text);
            var B = int.Parse(txbZ2.Text);
            var C = 0;
            var sign = false;
            return new Line(A, B, C, sign);
        }

        private float FindSolution(Func<Line, Line, Line, Line, PointF> Condition)
        {
            var point = Condition(lineZ, line1, line2, line3); 
            return Line.CalcZValue(lineZ, point); 
        }

        private Line InitLine(Line line, Func<Line, Line, Line, Line, PointF> Condition)
        {
            var point = Condition(lineZ, line1, line2, line3);
            return Line.ShiftLine(lineZ, point);
        }
    }
}
//Line lineZ = new Line(5, 1, 0, false);

//Line line1 = new Line(3, 2, 12, false);
//line1.Draw(g, Pens.Red);

//Line line2 = new Line(1, 2, 4, true);//find points filter points
//line2.Draw(g, Pens.Green);

//Line line3 = new Line(2, -1, 1, false);
//line3.Draw(g, Pens.Blue);

//var testPoints = new List<PointF>() { new PointF(1, 2), new PointF(3, 2), new PointF(2, 1), new PointF(2, 3) };
//var res = testPoints.OrderBy(x => Math.Atan2(x.X, x.Y)).ToList();
//var f = 3;
//PointManipulator.isLand(line3, new PointF(1.2f, 1.4f));

//Line line1 = new Line(-1, 1, 5, false);
//line1.Draw(g, Pens.Black);

//Line line2 = new Line(1, 1, 8, false);
//line2.Draw(g, Pens.Red);

//Line line3 = new Line(3, 5, 18, true);
//line3.Draw(g, Pens.Green);

//Line line1 = new Line(1, 2, 8, false);
//line1.Draw(g, Pens.Black);

//Line line2 = new Line(-2, -3, -4, false);//find points filter points
//line2.Draw(g, Pens.Red);

//Line line3 = new Line(-2, 1, -2, false);
//line3.Draw(g, Pens.Green);

//Line line1 = new Line(2, 4, 20, false);
//line1.Draw(g, Pens.Black);

//Line line2 = new Line(3, -5, 1, false);//find points filter points
//line2.Draw(g, Pens.Red);

//Line line3 = new Line(1, 0, 4, false);
//line3.Draw(g, Pens.Green);

//Line lineZ = new Line(1, -2, 0, false);
//Line line1 = new Line(5, 3, 30, true);
//line1.Draw(g, Pens.Black);
//Line line2 = new Line(1, -1, 3, false);//find points filter points
//line2.Draw(g, Pens.Red);
//Line line3 = new Line(-3, 5, 15, false);
//line3.Draw(g, Pens.Green);