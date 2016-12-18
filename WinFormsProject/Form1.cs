using System.Drawing;
using System.Windows.Forms;

namespace WinFormsProject
{
    public partial class Form1 : Form
    {
        private bool drawing = false;
        private Brush solidBrush = new SolidBrush(Color.Black);
        private Pen pen = new Pen(Color.Black,5);
        private Graphics graphics;
        private Point lastPoint;
        private DrawingItem drawingItem;
        public Form1()
        {
            lastPoint = new Point();
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
            drawingItem = DrawingItem.Pen;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            lastPoint.X = e.X;
            lastPoint.Y = e.Y;
            graphics.FillEllipse(solidBrush, new Rectangle((int)(e.Location.X - pen.Width / 2), (int)(e.Location.Y - pen.Width / 2), (int)pen.Width, (int)pen.Width));
            //dataGridView1.a
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                //graphics.FillRectangle(solidBrush, new Rectangle(e.Location.X, e.Location.Y, 3, 3));
                switch (drawingItem)
                {
                    case DrawingItem.Brush:
                        break;
                    case DrawingItem.Pen:
                        graphics.DrawLine(pen, lastPoint.X, lastPoint.Y, e.X, e.Y);
                        graphics.FillEllipse(solidBrush, new Rectangle((int)(e.Location.X - pen.Width / 2), (int)(e.Location.Y - pen.Width / 2), (int)pen.Width, (int)pen.Width));
                        lastPoint.X = e.X;
                        lastPoint.Y = e.Y;
                        break;
                }
                
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                graphics.FillEllipse(solidBrush, new Rectangle((int)(e.Location.X - pen.Width / 2), (int)(e.Location.Y - pen.Width / 2), (int)pen.Width, (int)pen.Width));

            }
            drawing = false;
        }

        private void Form1_ResizeEnd(object sender, System.EventArgs e)
        {
            pictureBox1.Size = Size;
            graphics.Dispose();
            graphics = pictureBox1.CreateGraphics();
        }

        private void listBox1_Click(object sender, System.EventArgs e)
        {
            ListBox list = (ListBox) sender;
            switch (list.SelectedIndex)
            {
                case 0:
                    drawingItem = DrawingItem.Pen;
                    break;
                case 1:
                    drawingItem = DrawingItem.Brush;
                    break;
            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = imageList1.Images[3];
            drawingItem = DrawingItem.Pen;
            pictureBox2.Image = imageList1.Images[0];
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = imageList1.Images[2];
            drawingItem = DrawingItem.Brush;
            pictureBox2.Image = imageList1.Images[1];
        }
    }
}
