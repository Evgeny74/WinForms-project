using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsProject
{
    class ImageBox : PictureBox
    {
        private Rectangle rectangle;
        private Pen pen = new Pen(Color.Black,5);
        private DrawingItem drawingItem;

        public ImageBox()
        { }
        protected override void OnPaint(PaintEventArgs e)
        {
                base.OnPaint(e);
                switch (drawingItem)
                {
                    case DrawingItem.Rectangle:
                        e.Graphics.DrawRectangle(pen, rectangle);
                        break;
                    case DrawingItem.Ellipse:
                        e.Graphics.DrawEllipse(pen, rectangle);
                        break;
                    case DrawingItem.Triangle:
                        e.Graphics.DrawLine(pen, rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Bottom);
                        e.Graphics.DrawLine(pen, rectangle.Left, rectangle.Bottom, (rectangle.Right + rectangle.Left)/2,
                            rectangle.Top);
                        e.Graphics.DrawLine(pen, rectangle.Right, rectangle.Bottom, (rectangle.Right + rectangle.Left)/2,
                            rectangle.Top);
                        break;
                }

        }

        public void setRectangle(Rectangle r,DrawingItem drawingItem)
        {
            rectangle = r;
            this.drawingItem = drawingItem;
        }

        public void setPen(Pen pen)
        {
            this.pen = pen;
        }

        public Pen getPen()
        {
            return pen;
        }

        public DrawingItem getDrawingItem()
        {
            return drawingItem;
        }

    }
}
