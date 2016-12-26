using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsProject.Logic;

namespace WinFormsProject
{
    /// <summary>
    /// Основная форма приложения
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Рисует ли сейчас пользователь или нет
        /// </summary>
        private bool drawing = false;
        /// <summary>
        /// Последнее состояние окна
        /// </summary>
        private FormWindowState LastState;
        /// <summary>
        /// Класс логики отрисовки
        /// </summary>
        private BMPLogic logic;
        /// <summary>
        /// Окно для рисования
        /// </summary>
        private ImageBox picture;
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public Form1()
        {
            picture = new ImageBox();
            ((System.ComponentModel.ISupportInitialize) (this.picture)).BeginInit();
            this.picture.BackColor = System.Drawing.SystemColors.Window;
            this.picture.Location = new System.Drawing.Point(74, 98);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(321, 296);
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            this.Controls.Add(this.picture);
            InitializeComponent();
            colors.Rows.Add();
            colors.Rows.Add();
            colors.Rows[0].Height = 15;
            colors.Rows[1].Height = 15;
            colors.Rows[0].Cells[0].Value = imageList1.Images[4];
            colors.Rows[0].Cells[1].Value = imageList1.Images[5];
            colors.Rows[0].Cells[2].Value = imageList1.Images[6];
            colors.Rows[0].Cells[3].Value = imageList1.Images[7];
            colors.Rows[1].Cells[0].Value = imageList1.Images[8];
            colors.Rows[1].Cells[1].Value = imageList1.Images[9];
            colors.Rows[1].Cells[2].Value = imageList1.Images[10];
            colors.Rows[1].Cells[3].Value = imageList1.Images[11];
            colors.AllowUserToAddRows = false;
            colors.AllowUserToDeleteRows = false;
            red.Text = "0";
            green.Text = "0";
            blue.Text = "0";
            LastState = WindowState;
            logic = new BMPLogic(picture.Width, picture.Height);
        }
        /// <summary>
        /// Обработка Mouse down на picture
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            picture.Image = logic.startDrawing(e);
        }
        /// <summary>
        /// Обработка Mouse move на picture
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                try
                {
                    if (logic.GetDrawingItem() == DrawingItem.Rectangle || logic.GetDrawingItem() == DrawingItem.Ellipse ||
                        logic.GetDrawingItem() == DrawingItem.Triangle)
                    {
                        Point lastPoint = logic.getLastPoint();
                        int x = Math.Min(lastPoint.X, e.X),
                            y = Math.Min(lastPoint.Y, e.Y);
                        picture.setRectangle(
                            new Rectangle(x, y, Math.Abs(e.X - lastPoint.X), Math.Abs(e.Y - lastPoint.Y)),
                            logic.GetDrawingItem());
                        picture.setPen(logic.getPen());
                        picture.Invalidate();
                    }
                    else
                    {
                        logic.draw(e);
                        picture.Refresh();
                    }

                }
                catch (Exception)
                {
                }
            }
        }
        /// <summary>
        /// Обарботка Mouse up на Picture
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>/// <param name="sender"></param>
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                picture.Image = logic.finishDrawing(e);
                drawing = false;
                picture.setRectangle(new Rectangle(0, 0, 0, 0),logic.GetDrawingItem());
                picture.setPen(logic.getPen());
                picture.Invalidate();
            }
        }
        /// <summary>
        /// Обарботка изменения размера
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>
        private void Form1_ResizeEnd(object sender, System.EventArgs e)
        {
            picture.Size = new Size(Size.Width - 90, Size.Height - 137);
            picture.Image = logic.onResizeEnd(e, picture.Size);
        }


        /// <summary>
        /// Обработка выбора пера
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>/// <param name="sender"></param>
        private void penBox_MouseUp(object sender, MouseEventArgs e)
        {
            penBox.Image = imageList1.Images[3];
            logic.choosePen();
            brushBox.Image = imageList1.Images[0];
            eraserBox.Image = imageList1.Images[12];
        }
        /// <summary>
        /// Обработка выбора кисти
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>
        private void brushBox_MouseUp(object sender, MouseEventArgs e)
        {
            penBox.Image = imageList1.Images[2];
            logic.chooseBrush();
            brushBox.Image = imageList1.Images[1];
            eraserBox.Image = imageList1.Images[12];
        }
        /// <summary>
        /// Обработка выбора цвета
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>
        private void colors_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            logic.chooseColor(e);
        }
        /// <summary>
        /// Обработка выбора ластика
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>
        private void eraser_MouseUp(object sender, MouseEventArgs e)
        {
            penBox.Image = imageList1.Images[2];
            logic.chooseEraser();
            brushBox.Image = imageList1.Images[0];
            eraserBox.Image = imageList1.Images[13];
        }
        /// <summary>
        /// Обработка изменения ширины
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>
        private void width_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                int width = Int32.Parse(((TextBox) sender).Text);
                logic.onWidthChanged(width);
            }
            catch (Exception exc)
            {
            }
        }
        /// <summary>
        /// Обработка изменения значения красного цвета
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>
        private void red_TextChanged(object sender, EventArgs e)
        {
            try
            {
                logic.onChangeRedPart(sender);
            }
            catch (Exception exc)
            {
            }
        }
        /// <summary>
        /// Обработка изменения значения зеленого цвета
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>
        private void green_TextChanged(object sender, EventArgs e)
        {
            try
            {
                logic.onChangeGreenPart(sender);
            }
            catch (Exception exc)
            {
            }
        }
        /// <summary>
        /// Обработка изменения Синего цвета
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>
        private void blue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                logic.onChangeBluePart(sender);
            }
            catch (Exception exc)
            {
            }
        }
        /// <summary>
        /// Обработка изменения размера формы
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState != LastState)
            {
                picture.Size = new Size(Size.Width - 90, Size.Height - 137);
                picture.Image = logic.onResize(picture.Size);
                LastState = WindowState;
            }
        }
        /// <summary>
        /// Сохранение изображения
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>
        private void saveFile(object sender, EventArgs e)
        {
            logic.saveBMP();
        }
        /// <summary>
        /// Открытие изображения
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>
        private void openFile(object sender, EventArgs e)
        {
            try
            {
                picture.Image = logic.openBMP();
                picture.Size = picture.Image.Size;
                Size = new Size(picture.Width + 90, picture.Height + 137);
            }
            catch (Exception exc)
            {
            }
        }
        /// <summary>
        /// Выбор прямоугольника
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры</param>
        private void rectangle_Click(object sender, EventArgs e)
        {
            logic.chooseRectangle();
        }
        /// <summary>
        /// Выбор эллипса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ellipse_Click(object sender, EventArgs e)
        {
            logic.chooseEllipse();
        }
        /// <summary>
        /// Выбор треугольника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void triangle_Click(object sender, EventArgs e)
        {
            logic.chooseTriangle();
        }
        /// <summary>
        /// Обработка сочетаний клавиш
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="keys">Клавиши</param>
        /// <returns>Результат обработки</returns>
        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {

            switch (keys)
            {
                case Keys.Control | Keys.Z:
                {
                    picture.Image = logic.getPrevious();
                    picture.Refresh();
                    Size = new Size(picture.Image.Width + 90, picture.Image.Height + 137);
                    picture.Size = picture.Image.Size;
                    return true;
                }
            }
            return base.ProcessCmdKey(ref message, keys);
        }
 
    }
}
