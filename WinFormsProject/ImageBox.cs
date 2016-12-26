using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsProject
{
    /// <summary>
    /// Класса для рисования
    /// </summary>
    public class ImageBox : PictureBox
    {
        /// <summary>
        /// Прямоугольник для рисования
        /// </summary>
        private Rectangle rectangle;
        /// <summary>
        /// Перо, используемое для рисования
        /// </summary>
        private Pen pen = new Pen(Color.Black,5);
        /// <summary>
        /// Какую фишуру рисовать
        /// </summary>
        private DrawingItem drawingItem;
        /// <summary>
        /// Конструткор
        /// </summary>
        public ImageBox()
        { }
        /// <summary>
        /// Метод перерисовки
        /// </summary>
        /// <param name="e">Аргументы</param>
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
        /// <summary>
        /// Установка прямоугольника
        /// </summary>
        /// <param name="r">Прямоугольник</param>
        /// <param name="drawingItem">Какую фигуру рисовать</param>
        public void setRectangle(Rectangle r,DrawingItem drawingItem)
        {
            rectangle = r;
            this.drawingItem = drawingItem;
        }
        /// <summary>
        /// Установка пера
        /// </summary>
        /// <param name="pen">Перо</param>
        public void setPen(Pen pen)
        {
            this.pen = pen;
        }
        /// <summary>
        /// Метод полученгия пера
        /// </summary>
        /// <returns>Перо</returns>
        public Pen getPen()
        {
            return pen;
        }
        /// <summary>
        /// Метод получения фигуры
        /// </summary>
        /// <returns>Тип фигуры</returns>
        public DrawingItem getDrawingItem()
        {
            return drawingItem;
        }
        /// <summary>
        /// Получение прямоугольника
        /// </summary>
        /// <returns>Прямоугольник</returns>
        public Rectangle GetRectangle()
        {
            return rectangle;
        }

    }
}
