using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsProject.Logic
{
    /// <summary>
    /// Класс логики рисования
    /// </summary>
    public class BMPLogic
    {
        /// <summary>
        /// Кисть
        /// </summary>
        private Brush solidBrush = new SolidBrush(Color.Black);
        /// <summary>
        /// Перо
        /// </summary>
        private Pen pen = new Pen(Color.Black, 5);
        /// <summary>
        /// Ластик
        /// </summary>
        private Pen eraser = new Pen(Color.White, 5);
        /// <summary>
        /// Белая кисть
        /// </summary>
        private SolidBrush whiteBrush = new SolidBrush(Color.White);
        /// <summary>
        /// Объект класса Garphics
        /// </summary>
        private Graphics graphics;
        /// <summary>
        /// Предыдущая точка
        /// </summary>
        private Point lastPoint;
        /// <summary>
        /// Что сейчас рисовать
        /// </summary>
        private DrawingItem drawingItem;
        /// <summary>
        /// Текущий цвет
        /// </summary>
        private Color color = Color.Black;
        /// <summary>
        /// Текущий рисунок
        /// </summary>
        private Bitmap bmp;
        /// <summary>
        /// Предыдущие версии рисунка
        /// </summary>
        private List<Bitmap> oldBitmaps = new List<Bitmap>();
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Width">Ширина рисуунка</param>
        /// <param name="Height">Высота рисунка</param>
        public BMPLogic(int Width,int Height)
        {
            lastPoint = new Point();
            bmp = new Bitmap(Width, Height);
            for (int i = 0; i < Width; i++)
                for (int j= 0; j < Height; j++)
                    bmp.SetPixel(i,j,Color.White);
            graphics = Graphics.FromImage(bmp);
            drawingItem = DrawingItem.Pen;
            oldBitmaps.Add((Bitmap)bmp.Clone());
        }
        /// <summary>
        /// Начало рисования
        /// </summary>
        /// <param name="e">Параметры</param>
        /// <returns>Рисунок</returns>
        public Bitmap startDrawing(MouseEventArgs e)
        {
            lastPoint.X = e.X;
            lastPoint.Y = e.Y;
            switch (drawingItem)
            {
                case DrawingItem.Eraser:
                    graphics.FillEllipse(whiteBrush, new Rectangle((int)(e.Location.X - pen.Width / 2), (int)(e.Location.Y - pen.Width / 2), (int)pen.Width, (int)pen.Width));
                    break;
                case DrawingItem.Brush:
                case DrawingItem.Pen:
                    graphics.FillEllipse(solidBrush, new Rectangle((int)(e.Location.X - pen.Width / 2), (int)(e.Location.Y - pen.Width / 2), (int)pen.Width, (int)pen.Width));
                    break;

            }    
            return bmp;
        }
        /// <summary>
        /// Рисование
        /// </summary>
        /// <param name="e">Параметры</param>
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
            }

        }

        
        /// <summary>
        /// Конец рисования
        /// </summary>
        /// <param name="e">Параметры</param>
        /// <returns>Рисунок</returns>
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
                case DrawingItem.Ellipse:
                    x = Math.Min(lastPoint.X, e.X);
                    y = Math.Min(lastPoint.Y, e.Y);
                    graphics.DrawEllipse(pen, x, y, Math.Abs(e.X - lastPoint.X), Math.Abs(e.Y - lastPoint.Y));
                    break;
                case DrawingItem.Triangle:
                    x = Math.Min(lastPoint.X, e.X);
                    y = Math.Min(lastPoint.Y, e.Y);
                    int xMax = Math.Max(lastPoint.X, e.X);
                    int yMax = Math.Max(lastPoint.Y, e.Y);
                    graphics.DrawLine(pen,x+(Math.Abs(e.X - lastPoint.X))/2,y,x,yMax);
                    graphics.DrawLine(pen, x + (Math.Abs(e.X - lastPoint.X)) / 2, y,xMax,yMax);
                    graphics.DrawLine(pen,x,yMax,xMax,yMax);
                    break;
            }
            if (oldBitmaps.Count < 100)
                oldBitmaps.Add((Bitmap)bmp.Clone());
            else
            {
                oldBitmaps.Remove(oldBitmaps[0]);
                oldBitmaps.Add((Bitmap)bmp.Clone());
            }
            return bmp;
        }
        /// <summary>
        /// Метод, меняющий размер рисунка
        /// </summary>
        /// <param name="e">Параметры</param>
        /// <param name="size">Размер</param>
        /// <returns>Рисунок</returns>
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
        /// <summary>
        /// Выбор пера
        /// </summary>
        public void choosePen()
        {
            drawingItem = DrawingItem.Pen;
        }
        /// <summary>
        /// Выбор кисти
        /// </summary>
        public void chooseBrush()
        {
            drawingItem = DrawingItem.Brush;
        }
        /// <summary>
        /// Выбор ластика
        /// </summary>
        public void chooseEraser()
        {
            drawingItem = DrawingItem.Eraser;
        }
        /// <summary>
        /// Выбор цвета
        /// </summary>
        /// <param name="e">Параметры</param>
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
        /// <summary>
        /// Изменение ширины пера, кисти и так далее
        /// </summary>
        /// <param name="width">Ширина</param>
        public void onWidthChanged(int width)
        {
            pen.Width = width;
            eraser.Width = width;
        }
        /// <summary>
        /// Изменение красной части
        /// </summary>
        /// <param name="sender">Объект-отправитель</param>
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

        /// <summary>
        /// Изменение зеленой части цвета
        /// </summary>
        /// <param name="sender">Объект-отправитель</param>
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
        /// <summary>
        /// Изменение синей части цвета
        /// </summary>
        /// <param name="sender">Объект-отправитель</param>
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
        /// <summary>
        /// Изменение размера рисунка
        /// </summary>
        /// <param name="size">Размер</param>
        /// <returns>Рисунок</returns>
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
        /// <summary>
        /// Сохранение рисунка
        /// </summary>
        /// <returns>True, если удалось</returns>
        public bool saveBMP()
        {
            SaveAndOpenDialog saveDialog = new SaveAndOpenDialog();
            return saveDialog.saveBMP(bmp);
        }
        /// <summary>
        /// Открытие рисунка
        /// </summary>
        /// <returns>Рисунок</returns>
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
        /// <summary>
        /// Выбор прямоугольника
        /// </summary>
        public void chooseRectangle()
        {
            drawingItem = DrawingItem.Rectangle;
        }
        /// <summary>
        /// Выбор эллипса
        /// </summary>
        public void chooseEllipse()
        {
            drawingItem = DrawingItem.Ellipse;
        }
        /// <summary>
        /// Выбор треугольника
        /// </summary>
        public void chooseTriangle()
        {
            drawingItem = DrawingItem.Triangle;
        }
        /// <summary>
        /// Получение типа инструмента рисования
        /// </summary>
        /// <returns></returns>
        public DrawingItem GetDrawingItem()
        {
            return drawingItem;
        }
        /// <summary>
        /// Геттер пера
        /// </summary>
        /// <returns>Перо</returns>
        public Pen getPen()
        {
            return pen;
        }
        /// <summary>
        /// Геттер предыдущей точки
        /// </summary>
        /// <returns>Предыдущая точка</returns>
        public Point getLastPoint()
        {
            return lastPoint;
        }
        /// <summary>
        /// Получение предыдущей версии рисунка
        /// </summary>
        /// <returns>Рисунок</returns>
        public Bitmap getPrevious()
        {
            if (oldBitmaps.Count > 1 && oldBitmaps[oldBitmaps.Count - 1]!=null)
            {
                bmp.Dispose();
                bmp = (Bitmap)oldBitmaps[oldBitmaps.Count - 2].Clone();
                oldBitmaps[oldBitmaps.Count-1].Dispose();
                oldBitmaps.Remove(oldBitmaps[oldBitmaps.Count - 1]);
                graphics.Dispose();
                graphics = Graphics.FromImage(bmp);

            }
            return bmp;
        }
        /// <summary>
        /// Получение текущего рисунка
        /// </summary>
        /// <returns>Рисунок</returns>
        public Bitmap getBitmap()
        {
            return bmp;
        }
    }
}
