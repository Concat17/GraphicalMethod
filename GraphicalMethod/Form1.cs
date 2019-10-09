using System.Drawing;
using System.Windows.Forms;

/*
 * 1 Interface
 * 2 Line Class
 * 3 Draw Line Method (Class Drawer?)
 * 4 Points Finder
 * 5 Filter
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
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawAxis(g); 
        }

        private void DrawAxis(Graphics g)
        {
            PointF center = new PointF(panel1.Width / 2, panel1.Height / 2);
            g.DrawLine(Pens.LightBlue, panel1.Width / 2, 0, panel1.Width / 2, panel1.Height);
            g.DrawLine(Pens.LightBlue, 0, panel1.Height / 2, panel1.Width, panel1.Height / 2);
        }

        private void BtnRes_Click(object sender, System.EventArgs e)
        {
            var x = 3;
            var y = 2;
            var k = 12;
            var isMore = false;
            Line line1 = new Line(x, y, k, isMore);
            line1.Draw(g, panel1.Size, Pens.Black);

            Line line2 = new Line(1, 2, 4, true);
            line2.Draw(g, panel1.Size, Pens.Red);

            Line line3 = new Line(2, -1, 1, false);
            line3.Draw(g, panel1.Size, Pens.Green);

            var intr = line2.Intersect(line3);
            var scaledintr = line2.ScalePoint(intr, panel1.Size);

            g.DrawLine(Pens.Pink, scaledintr, new PointF(300, 300));

             
        }
    }
}
