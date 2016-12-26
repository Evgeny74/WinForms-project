using System.Drawing;
using Xunit;
using WinFormsProject;
namespace WinFormsProjectTests
{
    /// <summary>
    /// Тестирование класса ImageBox
    /// </summary>
    public class ImageBoxTests
    {
        /// <summary>
        /// Тестирование прямоугольника
        /// </summary>
        [Fact]
        public void setRectangleTest()
        {
            ImageBox box = new ImageBox();
            box.setRectangle(new Rectangle(0,0,100,100), DrawingItem.Pen);
            Assert.Equal(0,box.GetRectangle().Left);
            Assert.Equal(0, box.GetRectangle().Top);
            Assert.Equal(100, box.GetRectangle().Bottom);
            Assert.Equal(100, box.GetRectangle().Right);
            Assert.Equal(DrawingItem.Pen,box.getDrawingItem());
        }
        /// <summary>
        /// Тестирование пера
        /// </summary>
        [Fact]
        public void setPenTest()
        {
            ImageBox box = new ImageBox();
            box.setPen(new Pen(Color.Red,15));
            Assert.Equal(Color.Red,box.getPen().Color);
            Assert.Equal(15,box.getPen().Width);
        }
    }
}
