using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using WinFormsProject.Logic;

namespace WinFormsProject
{
    public partial class Form1 : Form
    {
        private bool drawing = false;
       
        private FormWindowState LastState;
        private BMPLogic logic;
        private List<Image> bitmaps = new List<Image>();
        private int count = 0;
        private Point point = new Point(-1,-1);
        private ImageBox pictureBox1;
        public Form1()
        {
            pictureBox1 = new ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(74, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(321, 296);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            this.Controls.Add(this.pictureBox1);
            InitializeComponent();
            
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Height = 15;
            dataGridView1.Rows[1].Height = 15;
            dataGridView1.Rows[0].Cells[0].Value = imageList1.Images[4];
            dataGridView1.Rows[0].Cells[1].Value = imageList1.Images[5];
            dataGridView1.Rows[0].Cells[2].Value = imageList1.Images[6];
            dataGridView1.Rows[0].Cells[3].Value = imageList1.Images[7];
            dataGridView1.Rows[1].Cells[0].Value = imageList1.Images[8];
            dataGridView1.Rows[1].Cells[1].Value = imageList1.Images[9];
            dataGridView1.Rows[1].Cells[2].Value = imageList1.Images[10];
            dataGridView1.Rows[1].Cells[3].Value = imageList1.Images[11];
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            red.Text = "0";
            green.Text = "0";
            blue.Text = "0";
            LastState = WindowState;
            logic = new BMPLogic(pictureBox1.Width,pictureBox1.Height);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            pictureBox1.Image = logic.startDrawing(e);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                try
                {
                    if (logic.GetDrawingItem() == DrawingItem.Rectangle)
                    {
                        using (Graphics graphics = pictureBox1.CreateGraphics())
                        {
                                point.X = e.X;
                                point.Y = e.Y;
                                Point lastPoint = logic.getLastPoint();
                                int x = Math.Min(lastPoint.X, e.X),
                                    y = Math.Min(lastPoint.Y, e.Y);
                                pictureBox1.setRectangle(new Rectangle(x,y, Math.Abs(e.X - lastPoint.X), Math.Abs(e.Y - lastPoint.Y)));
                            pictureBox1.setPen(logic.getPen());
                                pictureBox1.Invalidate();
                               
                                
                                //graphics.DrawRectangle(logic.getPen(), x, y, Math.Abs(e.X - lastPoint.X),
                                   // Math.Abs(e.Y - lastPoint.Y));
          
                        }
                       // logic.draw(e);
                       // pictureBox1.Refresh();
                    }
                    else
                    {
                        logic.draw(e);
                        pictureBox1.Refresh();
                    }
                    
                }
                catch (Exception exc)
                {
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                pictureBox1.Image = logic.finishDrawing(e);
                drawing = false;
            }
            
            Thread.Sleep(20);
            bitmaps.Clear();
        }

        private void Form1_ResizeEnd(object sender, System.EventArgs e)
        {
            pictureBox1.Size = new Size(Size.Width - 90, Size.Height - 137);
            pictureBox1.Image = logic.onResizeEnd(e,pictureBox1.Size);
        }

        

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            penBox.Image = imageList1.Images[3];
            logic.choosePen();
            brushBox.Image = imageList1.Images[0];
            eraserBox.Image = imageList1.Images[12];
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            penBox.Image = imageList1.Images[2];
            logic.chooseBrush();
            brushBox.Image = imageList1.Images[1];
            eraserBox.Image = imageList1.Images[12];
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //DataGridView view = (DataGridView) sender;
            logic.chooseColor(e);
            

        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            penBox.Image = imageList1.Images[2];
            logic.chooseEraser();
            brushBox.Image = imageList1.Images[0];
            eraserBox.Image = imageList1.Images[13];
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                int width = Int32.Parse(((TextBox)sender).Text);
                logic.onWidthChanged(width);
            }
            catch (Exception exc)
            {
            }
        }

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

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState != LastState)
            {
                pictureBox1.Size = new Size(Size.Width - 90, Size.Height - 137);
                pictureBox1.Image = logic.onResize(pictureBox1.Size);
                LastState = WindowState;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.saveBMP();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = logic.openBMP();
                pictureBox1.Size = pictureBox1.Image.Size;
                Size = new Size(pictureBox1.Width + 90,pictureBox1.Height + 137);
            }
            catch (Exception exc)
            {
            }
        }

        private void rectangle_Click(object sender, EventArgs e)
        {
            logic.chooseRectangle();
        }

        private void ellipse_Click(object sender, EventArgs e)
        {
            logic.chooseEllipse();
        }

        private void triangle_Click(object sender, EventArgs e)
        {
            logic.chooseTriangle();
        }

        
    }
}
