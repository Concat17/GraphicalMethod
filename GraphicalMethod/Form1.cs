using System.Drawing;
using System.Windows.Forms;

/*
 * 1 Interface
 * 2 Line Class
 * 3 Draw Line Method (Class Drawer?)
 * 4 Points Finder
 * 5 Filter
 * 6 Polygon drawing
 */
namespace GraphicalMethod
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            Line.panelSize = panel1.Size;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawAxis(g); 
        }

        private void DrawAxis(Graphics g)
        { 
            g.DrawLine(Pens.LightBlue, panel1.Width / 2, 0, panel1.Width / 2, panel1.Height);
            g.DrawLine(Pens.LightBlue, 0, panel1.Height / 2, panel1.Width, panel1.Height / 2);
        }

        private void BtnRes_Click(object sender, System.EventArgs e)
        {
            //Line line1 = new Line(3, 2, 12, false);
            //line1.Draw(g, Pens.Black);

            //Line line2 = new Line(1, 2, 4, true);//find points filter points
            //line2.Draw(g, Pens.Red);

            //Line line3 = new Line(2, -1, 1, false);
            //line3.Draw(g, Pens.Green);

            //Line line1 = new Line(-1, 1, 5, false);
            //line1.Draw(g, Pens.Black);

            //Line line2 = new Line(1, 1, 8, false);//find points filter points
            //line2.Draw(g, Pens.Red);

            //Line line3 = new Line(3, 5, 18, true);
            //line3.Draw(g, Pens.Green);

            Line line1 = new Line(1, 2, 8, false);
            line1.Draw(g, Pens.Black);

            Line line2 = new Line(-2, -3, -4, false);//find points filter points
            line2.Draw(g, Pens.Red);

            Line line3 = new Line(-2, 1, -2, false);
            line3.Draw(g, Pens.Green);


            var points = PointManipulator.FindPoints(line1, line2, line3);
            foreach(var point in points)
            {
                g.DrawLine(Pens.Pink, point, new PointF(300, 300));
            }
        }
    }
}
