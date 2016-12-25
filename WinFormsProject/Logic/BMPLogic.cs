using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsProject.Logic
{
    
    class BMPLogic
    {
        private Brush solidBrush = new SolidBrush(Color.Black);
        private Pen pen = new Pen(Color.Black, 5);
        private Pen eraser = new Pen(Color.White, 5);
        private SolidBrush whiteBrush = new SolidBrush(Color.White);
        private Graphics graphics;
        private Point lastPoint;
        private DrawingItem drawingItem;
        private Color color = Color.Black;
        private Bitmap bmp;
        private Graphics fileGraphics;
        private Bitmap currentBitmap;

        public BMPLogic(int Width,int Height)
        {
            lastPoint = new Point();
            bmp = new Bitmap(Width, Height);
            for (int i = 0; i < Width; i++)
                for (int j= 0; j < Height; j++)
                    bmp.SetPixel(i,j,Color.White);
            graphics = Graphics.FromImage(bmp);
            drawingItem = DrawingItem.Pen;
        }

        public Bitmap startDrawing(MouseEventArgs e)
        {
            lastPoint.X = e.X;
            lastPoint.Y = e.Y;
            if (drawingItem != DrawingItem.Eraser)
                graphics.FillEllipse(solidBrush, new Rectangle((int)(e.Location.X - pen.Width / 2), (int)(e.Location.Y - pen.Width / 2), (int)pen.Width, (int)pen.Width));
            else
                graphics.FillEllipse(whiteBrush, new Rectangle((int)(e.Location.X - pen.Width / 2), (int)(e.Location.Y - pen.Width / 2), (int)pen.Width, (int)pen.Width));
            if (drawingItem == DrawingItem.Rectangle)
            {
                if (currentBitmap != null)
                    currentBitmap.Dispose();
                currentBitmap = new Bitmap(bmp);
                return currentBitmap;
            }
            return bmp;
        }

        public void draw(MouseEventArgs e)
        {
            switch (drawingItem)
            {
                case DrawingItem.Brush:
                    graphics.FillEllipse(solidBrush, new Rectangle((int)(e.Location.X - pen.Width / 2), (int)(e.Location.Y - pen.Width / 2), (int)pen.Width, (int)pen.Width));
                    break;
                case DrawingItem.Pen:
                    graphics.DrawLine(pen, lastPoint.X, lastPoint.Y, e.X, e.Y);
                    graphics.FillEllipse(solidBrush, new Rectangle((int)(e.Location.X - pen.Width / 2), (int)(e.Location.Y - pen.Width / 2), (int)pen.Width, (int)pen.Width));
                    lastPoint.X = e.X;
                    lastPoint.Y = e.Y;
                    break;
                case DrawingItem.Eraser:
                    graphics.DrawLine(eraser, lastPoint.X, lastPoint.Y, e.X, e.Y);
                    graphics.FillEllipse(whiteBrush, new Rectangle((int)(e.Location.X - pen.Width / 2), (int)(e.Location.Y - pen.Width / 2), (int)pen.Width, (int)pen.Width));
                    lastPoint.X = e.X;
                    lastPoint.Y = e.Y;
                    break;
                case DrawingItem.Rectangle:
                    int x = Math.Min(lastPoint.X, e.X),
                        y = Math.Min(lastPoint.Y, e.Y),
                        xMax = Math.Max(lastPoint.X, e.X),
                        yMax = Math.Max(lastPoint.Y, e.Y);
                    for (int i = 0; i < currentBitmap.Width; i++)
                        for (int j = 0; j <= currentBitmap.Height; j++)
                            currentBitmap.SetPixel(i,j,bmp.GetPixel(i,j));
                    
                    using (Graphics graphic = Graphics.FromImage(currentBitmap))
                    {
                        
                        graphic.DrawRectangle(pen, x, y, Math.Abs(e.X - lastPoint.X), Math.Abs(e.Y - lastPoint.Y));
                    }
                    break;
            }

        }

        

        public Bitmap finishDrawing(MouseEventArgs e)
        {
           
            switch (drawingItem)
            {
                case DrawingItem.Brush:
                    graphics.FillEllipse(solidBrush, new Rectangle((int)(e.Location.X - pen.Width / 2), (int)(e.Location.Y - pen.Width / 2), (int)pen.Width, (int)pen.Width));
                    break;
                case DrawingItem.Pen:
                    graphics.FillEllipse(solidBrush, new Rectangle((int)(e.Location.X - pen.Width / 2), (int)(e.Location.Y - pen.Width / 2), (int)pen.Width, (int)pen.Width));
                    break;
                case DrawingItem.Eraser:
                    graphics.FillEllipse(whiteBrush, new Rectangle((int)(e.Location.X - pen.Width / 2), (int)(e.Location.Y - pen.Width / 2), (int)pen.Width, (int)pen.Width));
                    break;
                case DrawingItem.Rectangle:
                    int x = Math.Min(lastPoint.X, e.X),
                        y = Math.Min(lastPoint.Y, e.Y);
                    graphics.DrawRectangle(pen, x, y, Math.Abs(e.X - lastPoint.X), Math.Abs(e.Y - lastPoint.Y));
                    break;
            }
            return bmp;
        }

        public Bitmap onResizeEnd(EventArgs e,Size size)
        {
            Bitmap oldBmp = bmp;
            bmp = new Bitmap(size.Width,size.Height);
            for (int i = 0; i < bmp.Width; i++)
                for (int j = oldBmp.Height; j < bmp.Height; j++)
                    bmp.SetPixel(i, j, Color.White);
            for (int i = oldBmp.Width; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                    bmp.SetPixel(i, j, Color.White);
            for (int i = 0; i < oldBmp.Width; i++)
                for (int j = 0; j < oldBmp.Height; j++)
                {
                    if (i < bmp.Width && j < bmp.Height)
                    {
                        Color color = oldBmp.GetPixel(i, j);
                        bmp.SetPixel(i, j, color);
                    }
                }
            
            graphics.Dispose();
            graphics = Graphics.FromImage(bmp);
            return bmp;
        }

        public void choosePen()
        {
            drawingItem = DrawingItem.Pen;
        }

        public void chooseBrush()
        {
            drawingItem = DrawingItem.Brush;
        }

        public void chooseEraser()
        {
            drawingItem = DrawingItem.Eraser;
        }

        public void chooseColor(DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        pen.Color = Color.Black;
                        solidBrush.Dispose();
                        solidBrush = new SolidBrush(Color.Black);
                        break;
                    case 1:
                        pen.Color = Color.Blue;
                        solidBrush.Dispose();
                        solidBrush = new SolidBrush(Color.Blue);
                        break;
                    case 2:
                        pen.Color = Color.Green;
                        solidBrush.Dispose();
                        solidBrush = new SolidBrush(Color.Green);
                        break;
                    case 3:
                        pen.Color = Color.Aqua;
                        solidBrush.Dispose();
                        solidBrush = new SolidBrush(Color.Aqua);
                        break;
                }
            }
            else
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        pen.Color = Color.Red;
                        solidBrush.Dispose();
                        solidBrush = new SolidBrush(Color.Red);
                        break;
                    case 1:
                        pen.Color = Color.Magenta;
                        solidBrush.Dispose();
                        solidBrush = new SolidBrush(Color.Magenta);
                        break;
                    case 2:
                        pen.Color = Color.White;
                        solidBrush.Dispose();
                        solidBrush = new SolidBrush(Color.White);
                        break;
                    case 3:
                        pen.Color = Color.Yellow;
                        solidBrush.Dispose();
                        solidBrush = new SolidBrush(Color.Yellow);
                        break;
                }
            }
        }

        public void onWidthChanged(int width)
        {
            pen.Width = width;
            eraser.Width = width;
        }

        public void onChangeRedPart(Object sender)
        {
            try
            {
                int red = Int32.Parse(((TextBox)sender).Text);
                if (red > 255)
                {
                    red = 255;
                    ((TextBox)sender).Text = "255";
                }
                if (red < 0)
                {
                    red = 0;
                    ((TextBox)sender).Text = "0";
                }
                color = Color.FromArgb(red, color.G, color.B);
                pen.Color = color;
                solidBrush.Dispose();
                solidBrush = new SolidBrush(color);
            }
            catch (Exception exc)
            {
            }
        }


        public void onChangeGreenPart(Object sender)
        {
            try
            {
                int green = Int32.Parse(((TextBox)sender).Text);
                if (green > 255)
                {
                    green = 255;
                    ((TextBox)sender).Text = "255";
                }
                if (green < 0)
                {
                    green = 0;
                    ((TextBox)sender).Text = "0";
                }
                color = Color.FromArgb(color.R, green, color.B);
                pen.Color = color;
                solidBrush.Dispose();
                solidBrush = new SolidBrush(color);
            }
            catch (Exception exc)
            {
            }
        }

        public void onChangeBluePart(Object sender)
        {
            try
            {
                int blue = Int32.Parse(((TextBox)sender).Text);
                if (blue > 255)
                {
                    blue = 255;
                    ((TextBox)sender).Text = "255";
                }
                if (blue < 0)
                {
                    blue = 0;
                    ((TextBox)sender).Text = "0";
                }
                color = Color.FromArgb(color.R, color.G, blue);
                pen.Color = color;
                solidBrush.Dispose();
                solidBrush = new SolidBrush(color);
            }
            catch (Exception exc)
            {
            }
        }

        public Bitmap onResize(Size size)
        {
            if (size.Width > 0 && size.Height > 0)
            {
                Bitmap oldBmp = bmp;
                bmp = new Bitmap(size.Width, size.Height);
                for (int i = 0; i < bmp.Width; i++)
                    for (int j = oldBmp.Height; j < bmp.Height; j++)
                        bmp.SetPixel(i, j, Color.White);
                for (int i = oldBmp.Width; i < bmp.Width; i++)
                    for (int j = 0; j < bmp.Height; j++)
                        bmp.SetPixel(i, j, Color.White);
                for (int i = 0; i < oldBmp.Width && i < bmp.Width; i++)
                    for (int j = 0; (j < oldBmp.Height) && (j < bmp.Height); j++)
                    {
                        bmp.SetPixel(i, j, oldBmp.GetPixel(i, j));
                    }
                graphics.Dispose();
                graphics = Graphics.FromImage(bmp);
            }
            return bmp;
        }

        public bool saveBMP()
        {
            SaveAndOpenDialog saveDialog = new SaveAndOpenDialog();
            return saveDialog.saveBMP(bmp);
        }

        public Bitmap openBMP()
        {
            SaveAndOpenDialog openDialog = new SaveAndOpenDialog();
            Bitmap newBmp = openDialog.openBMP();
            if (newBmp != null)
            {
                bmp = newBmp;
            }
            return bmp;
        }

        public void chooseRectangle()
        {
            drawingItem = DrawingItem.Rectangle;
        }

        public void chooseEllipse()
        {
            drawingItem = DrawingItem.Ellipse;
        }

        public void chooseTriangle()
        {
            drawingItem = DrawingItem.Triangle;
        }

        public DrawingItem GetDrawingItem()
        {
            return drawingItem;
        }

        public Pen getPen()
        {
            return pen;
        }

        public Point getLastPoint()
        {
            return lastPoint;
        }

    }
}
