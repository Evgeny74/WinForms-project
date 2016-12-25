using System.Drawing;
using System.Windows.Forms;

namespace WinFormsProject
{
    class ImageBox : PictureBox
    {
        private Rectangle rectangle;
        private Pen pen = new Pen(Color.Black,5);

        public ImageBox()
        { }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(pen,rectangle);
        }

        public void setRectangle(Rectangle r)
        {
            rectangle = r;
        }

        public void setPen(Pen pen)
        {
            this.pen = pen;
        }
    }
}
