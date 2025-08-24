using Ant3Arena.Business.Ants;
using System.Drawing;
using Xunit;

namespace Ants3Arena.UnitTests.Ants
{
    public class AntYellowTests
    {
        [Fact]
        public static void AntYellow_Initialization_Works()
        {
            // Arrange
            var borders = new Size(800, 450);
            // Act
            var antYellow = new AntYellow(borders);
            // Assert
            Assert.InRange(antYellow.X, 0, borders.Width);
            Assert.InRange(antYellow.Y, 0, borders.Height);
            Assert.NotNull(antYellow.AntImage);
		}

        [Fact]
        public static void AntBlack_Should_Be_Black()
        {
            // Arrange
            var borders = new Size(800, 450);

            // Act
            var antBlack = new AntBlack(borders);

            // Assert
            for (int x = 0; x < antBlack.AntImage.Width; x++)
            {
                for (int y = 0; y < antBlack.AntImage.Height; y++)
                {
                    Color pixelColor = antBlack.AntImage.GetPixel(x, y);
                    if (pixelColor.A == 0 || pixelColor.R == 0)
                    {
                        continue; // Skip transparent and black pixels (black is the outline)
                    }
                    Assert.True(pixelColor.ToString() == ColorTranslator.FromHtml("#FFFF00").ToString(), $"Not all white pixels are converted to Red. X,Y: {x},{y} has color: {pixelColor.ToString()}.");
                }
            }
        }

        [Fact]
        public static void AntYellow_Move_Works()
        {
            // Arrange
            var borders = new Size(800, 450);
            var antYellow = new AntYellow(borders);
            int initialX = antYellow.X;
            int initialY = antYellow.Y;
            // Act
            antYellow.Move(borders);
            // Assert
            Assert.InRange(antYellow.X, 0, borders.Width);
            Assert.InRange(antYellow.Y, 0, borders.Height);
            Assert.True(antYellow.X != initialX || antYellow.Y != initialY, "Ant did not move.");
        }
    }
}
