using System.Drawing;
using System.Windows.Forms;
using WinFormsProject;
using Xunit;
using WinFormsProject.Logic;

namespace WinFormsProjectTests
{
    /// <summary>
    /// Тестирование класса BMPLogi
    /// </summary>
    public class LogicTests
    {
        /// <summary>
        /// Тестирование метода startDrawing
        /// </summary>
        [Fact]
        public void startDrawingTest()
        {
            MouseEventArgs args = new MouseEventArgs(MouseButtons.Left, 0,200,200,-1);
            BMPLogic logic = new BMPLogic(400,400);
            logic.startDrawing(args);
            Assert.Equal(Color.FromArgb(255,0,0,0), logic.getBitmap().GetPixel(200,200));
            logic.chooseEllipse();
            logic.startDrawing(new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1));
            Assert.Equal(Color.FromArgb(255, 255, 255, 255), logic.getBitmap().GetPixel(250,250));

        }
        /// <summary>
        /// Тестирование метода draw
        /// </summary>
        [Fact]
        public void DrawingTest()
        {
            MouseEventArgs args = new MouseEventArgs(MouseButtons.Left, 0, 200, 200, -1);
            BMPLogic logic = new BMPLogic(400, 400);
            logic.onWidthChanged(1);
            logic.startDrawing(args);
            logic.draw(new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(200, 200));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(250, 250));
            logic = new BMPLogic(400, 400);
            logic.chooseBrush();
            logic.startDrawing(args);
            logic.draw(new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(200, 200));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(250, 250));
            logic.chooseEraser();
            logic.startDrawing(args);
            logic.draw(new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1));
            Assert.Equal(Color.FromArgb(255, 255, 255, 255), logic.getBitmap().GetPixel(200, 200));
            Assert.Equal(Color.FromArgb(255, 255, 255, 255), logic.getBitmap().GetPixel(250, 250));
        }
        /// <summary>
        /// Тестирование метода finishDrawing
        /// </summary>
        [Fact]
        public void finishDrawingTest()
        {
            MouseEventArgs args = new MouseEventArgs(MouseButtons.Left, 0, 200, 200, -1);
            BMPLogic logic = new BMPLogic(400, 400);
            logic.startDrawing(args);
            logic.finishDrawing(new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(200, 200));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(250, 250));
            logic = new BMPLogic(400, 400);
            logic.chooseBrush();
            logic.startDrawing(args);
            logic.finishDrawing(new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(200, 200));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(250, 250));
            logic.chooseEraser();
            logic.startDrawing(args);
            logic.finishDrawing(new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1));
            Assert.Equal(Color.FromArgb(255, 255, 255, 255), logic.getBitmap().GetPixel(200, 200));
            Assert.Equal(Color.FromArgb(255, 255, 255, 255), logic.getBitmap().GetPixel(250, 250));
            logic = new BMPLogic(400, 400);
            logic.chooseRectangle();
            logic.startDrawing(args);
            logic.finishDrawing(new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1));
            for (int i = 200; i < 251; i++)
            {
                int j = 200;
                Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(i, j));
            }
            for (int i = 200; i < 251; i++)
            {
                int j = 250;
                Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(i, j));
            }
            logic = new BMPLogic(400,400);
            logic.chooseTriangle();
            logic.startDrawing(args);
            logic.finishDrawing(new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(200, 250));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(250, 250));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(224, 200));
            logic = new BMPLogic(400, 400);
            logic.chooseEllipse();
            logic.startDrawing(args);
            logic.finishDrawing(new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(200, (250 + 200)/2));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel(250, (250 + 200) / 2));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel((250 + 200) / 2, 200));
            Assert.Equal(Color.FromArgb(255, 0, 0, 0), logic.getBitmap().GetPixel((250 + 200) / 2, 250));
        }
        /// <summary>
        /// Тестирование метода onResizeEnd
        /// </summary>
        [Fact]
        public void onResizeEndTest()
        {
            BMPLogic logic = new BMPLogic(300,300);
            Bitmap bmp = logic.onResizeEnd(new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1),new Size(400,400));
            Assert.Equal(bmp.Width,400);
            Assert.Equal(bmp.Height, 400);

        }
        /// <summary>
        /// Тестирование метода choosePen
        /// </summary>
        [Fact]
        public void choosePenTest()
        {
            BMPLogic logic = new BMPLogic(200,200);
            logic.choosePen();
            Assert.Equal(DrawingItem.Pen,logic.GetDrawingItem());
        }
        /// <summary>
        /// Тестирование метода chooseColor
        /// </summary>
        [Fact]
        public void chooseColorTest()
        {
            BMPLogic logic = new BMPLogic(200,200);
            logic.chooseColor(new DataGridViewCellMouseEventArgs(0,0,0,0, new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1)));
            Assert.Equal(Color.Black,logic.getPen().Color);
            logic.chooseColor(new DataGridViewCellMouseEventArgs(1, 0, 0, 0, new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1)));
            Assert.Equal(Color.Blue, logic.getPen().Color);
            logic.chooseColor(new DataGridViewCellMouseEventArgs(2, 0, 0, 0, new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1)));
            Assert.Equal(Color.Green, logic.getPen().Color);
            logic.chooseColor(new DataGridViewCellMouseEventArgs(3, 0, 0, 0, new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1)));
            Assert.Equal(Color.Aqua, logic.getPen().Color);
            logic.chooseColor(new DataGridViewCellMouseEventArgs(0, 1, 0, 0, new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1)));
            Assert.Equal(Color.Red, logic.getPen().Color);
            logic.chooseColor(new DataGridViewCellMouseEventArgs(1, 1, 0, 0, new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1)));
            Assert.Equal(Color.Magenta, logic.getPen().Color);
            logic.chooseColor(new DataGridViewCellMouseEventArgs(2, 1, 0, 0, new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1)));
            Assert.Equal(Color.White, logic.getPen().Color);
            logic.chooseColor(new DataGridViewCellMouseEventArgs(3, 1, 0, 0, new MouseEventArgs(MouseButtons.Left, 0, 250, 250, -1)));
            Assert.Equal(Color.Yellow, logic.getPen().Color);
        }
        /// <summary>
        /// Тестирование метода onChangeColor
        /// </summary>
        [Fact]
        public void onChangeColorTest()
        {
            BMPLogic logic = new BMPLogic(200,200);
            TextBox textBox = new TextBox();
            textBox.Text = "43";
            logic.onChangeRedPart(textBox);
            Assert.Equal(43,logic.getPen().Color.R);
            textBox.Text = "27";
            logic.onChangeGreenPart(textBox);
            Assert.Equal(27, logic.getPen().Color.G);
            textBox.Text = "32";
            logic.onChangeBluePart(textBox);
            Assert.Equal(32, logic.getPen().Color.B);
            textBox.Text = "344";
            logic.onChangeRedPart(textBox);
            Assert.Equal(255, logic.getPen().Color.R);
            textBox.Text = "2337";
            logic.onChangeGreenPart(textBox);
            Assert.Equal(255, logic.getPen().Color.G);
            textBox.Text = "332";
            logic.onChangeBluePart(textBox);
            Assert.Equal(255, logic.getPen().Color.B);
            textBox.Text = "-5";
            logic.onChangeRedPart(textBox);
            Assert.Equal(0, logic.getPen().Color.R);
            textBox.Text = "-12";
            logic.onChangeGreenPart(textBox);
            Assert.Equal(0, logic.getPen().Color.G);
            textBox.Text = "-333";
            logic.onChangeBluePart(textBox);
            Assert.Equal(0, logic.getPen().Color.B);
            textBox.Text = "abc";
            logic.onChangeGreenPart(textBox);
            logic.onChangeRedPart(textBox);
            logic.onChangeBluePart(textBox);
            Assert.Equal(Color.FromArgb(255,0,0,0),logic.getPen().Color);

        }
        /// <summary>
        /// Тестирование метода onResize
        /// </summary>
        [Fact]
        public void onResizeTest()
        {
            BMPLogic logic = new BMPLogic(300, 300);
            Bitmap bmp = logic.onResize(new Size(400, 400));
            Assert.Equal(bmp.Width, 400);
            Assert.Equal(bmp.Height, 400);
        }
        /// <summary>
        /// Тестирование метода getLastPoint
        /// </summary>
        [Fact]
        public void getLastPointTest()
        {
            BMPLogic logic = new BMPLogic(200,200);
            logic.startDrawing(new MouseEventArgs(MouseButtons.Left, 0, 100, 100, -1));
            Assert.Equal(100,logic.getLastPoint().X);
            Assert.Equal(100, logic.getLastPoint().Y);
        }
        /// <summary>
        /// Тестирование метода getPreviousPoint
        /// </summary>
        [Fact]
        public void getPreviousTest()
        {
            BMPLogic logic = new BMPLogic(400,400);
            logic.startDrawing(new MouseEventArgs(MouseButtons.Left, 0, 100, 100, -1));
            logic.draw(new MouseEventArgs(MouseButtons.Left, 0, 200, 200, -1));
            logic.finishDrawing(new MouseEventArgs(MouseButtons.Left, 0, 200, 200, -1));
            Assert.NotNull(logic.getPrevious());
        }

    }
}
