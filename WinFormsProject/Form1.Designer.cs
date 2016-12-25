namespace WinFormsProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.red = new System.Windows.Forms.TextBox();
            this.green = new System.Windows.Forms.TextBox();
            this.blue = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.triangle = new System.Windows.Forms.PictureBox();
            this.ellipse = new System.Windows.Forms.PictureBox();
            this.rectangle = new System.Windows.Forms.PictureBox();
            this.eraserBox = new System.Windows.Forms.PictureBox();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.penBox = new System.Windows.Forms.PictureBox();
            this.brushBox = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.triangle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ellipse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eraserBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.penBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brushBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "brush.png");
            this.imageList1.Images.SetKeyName(1, "brush2.png");
            this.imageList1.Images.SetKeyName(2, "pen1.jpg");
            this.imageList1.Images.SetKeyName(3, "pen2.jpg");
            this.imageList1.Images.SetKeyName(4, "black.png");
            this.imageList1.Images.SetKeyName(5, "blue.png");
            this.imageList1.Images.SetKeyName(6, "green.png");
            this.imageList1.Images.SetKeyName(7, "greenBlue.png");
            this.imageList1.Images.SetKeyName(8, "red.png");
            this.imageList1.Images.SetKeyName(9, "RedBlue.png");
            this.imageList1.Images.SetKeyName(10, "white.png");
            this.imageList1.Images.SetKeyName(11, "yellow.png");
            this.imageList1.Images.SetKeyName(12, "eraser.png");
            this.imageList1.Images.SetKeyName(13, "eraser2.png");
            this.imageList1.Images.SetKeyName(14, "triangle.png");
            this.imageList1.Images.SetKeyName(15, "ellipse.png");
            this.imageList1.Images.SetKeyName(16, "rectangle.png");
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(136, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.Size = new System.Drawing.Size(90, 60);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 15;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Width = 15;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.Width = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(14, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Толщина";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(17, 228);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(50, 20);
            this.widthTextBox.TabIndex = 8;
            this.widthTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "RGB цвет";
            // 
            // red
            // 
            this.red.Location = new System.Drawing.Point(15, 117);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(53, 20);
            this.red.TabIndex = 10;
            this.red.TextChanged += new System.EventHandler(this.red_TextChanged);
            // 
            // green
            // 
            this.green.Location = new System.Drawing.Point(15, 143);
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(53, 20);
            this.green.TabIndex = 11;
            this.green.TextChanged += new System.EventHandler(this.green_TextChanged);
            // 
            // blue
            // 
            this.blue.Location = new System.Drawing.Point(15, 169);
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(53, 20);
            this.blue.TabIndex = 12;
            this.blue.TextChanged += new System.EventHandler(this.blue_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(395, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.Frozen = true;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::WinFormsProject.Properties.Resources.brush;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.Width = 15;
            // 
            // triangle
            // 
            this.triangle.Image = global::WinFormsProject.Properties.Resources.triangle;
            this.triangle.Location = new System.Drawing.Point(270, 32);
            this.triangle.Name = "triangle";
            this.triangle.Size = new System.Drawing.Size(25, 25);
            this.triangle.TabIndex = 16;
            this.triangle.TabStop = false;
            this.triangle.Click += new System.EventHandler(this.triangle_Click);
            // 
            // ellipse
            // 
            this.ellipse.Image = global::WinFormsProject.Properties.Resources.ellipse;
            this.ellipse.Location = new System.Drawing.Point(245, 32);
            this.ellipse.Name = "ellipse";
            this.ellipse.Size = new System.Drawing.Size(25, 25);
            this.ellipse.TabIndex = 15;
            this.ellipse.TabStop = false;
            this.ellipse.Click += new System.EventHandler(this.ellipse_Click);
            // 
            // rectangle
            // 
            this.rectangle.Image = global::WinFormsProject.Properties.Resources.rectangle;
            this.rectangle.Location = new System.Drawing.Point(220, 32);
            this.rectangle.Name = "rectangle";
            this.rectangle.Size = new System.Drawing.Size(25, 25);
            this.rectangle.TabIndex = 14;
            this.rectangle.TabStop = false;
            this.rectangle.Click += new System.EventHandler(this.rectangle_Click);
            // 
            // eraserBox
            // 
            this.eraserBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eraserBox.Image = global::WinFormsProject.Properties.Resources.eraser;
            this.eraserBox.Location = new System.Drawing.Point(67, 31);
            this.eraserBox.Name = "eraserBox";
            this.eraserBox.Size = new System.Drawing.Size(25, 25);
            this.eraserBox.TabIndex = 6;
            this.eraserBox.TabStop = false;
            this.eraserBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox4_MouseUp);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "";
            this.Column1.Image = global::WinFormsProject.Properties.Resources.brush;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 15;
            // 
            // penBox
            // 
            this.penBox.Image = global::WinFormsProject.Properties.Resources.pen;
            this.penBox.Location = new System.Drawing.Point(43, 31);
            this.penBox.Name = "penBox";
            this.penBox.Size = new System.Drawing.Size(25, 25);
            this.penBox.TabIndex = 4;
            this.penBox.TabStop = false;
            this.penBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseUp);
            // 
            // brushBox
            // 
            this.brushBox.Image = global::WinFormsProject.Properties.Resources.brush;
            this.brushBox.Location = new System.Drawing.Point(17, 31);
            this.brushBox.Name = "brushBox";
            this.brushBox.Size = new System.Drawing.Size(25, 25);
            this.brushBox.TabIndex = 3;
            this.brushBox.TabStop = false;
            this.brushBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 273);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 20);
            this.textBox1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 394);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.triangle);
            this.Controls.Add(this.ellipse);
            this.Controls.Add(this.rectangle);
            this.Controls.Add(this.blue);
            this.Controls.Add(this.green);
            this.Controls.Add(this.red);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eraserBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.penBox);
            this.Controls.Add(this.brushBox);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.triangle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ellipse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eraserBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.penBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brushBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox brushBox;
        private System.Windows.Forms.PictureBox penBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn Column4;
        private System.Windows.Forms.PictureBox eraserBox;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox red;
        private System.Windows.Forms.TextBox green;
        private System.Windows.Forms.TextBox blue;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.PictureBox rectangle;
        private System.Windows.Forms.PictureBox ellipse;
        private System.Windows.Forms.PictureBox triangle;
        private System.Windows.Forms.TextBox textBox1;
    }
}

