using Ant3Arena.Business.Ants;
using System.Drawing;
using Xunit;

namespace Ants3Arena.UnitTests.Ants
{
    public class AntRedTests
    {
        [Fact]
        public static void AntRed_Initialization_Works()
        {
            // Arrange
            var borders = new Size(800, 450);
            // Act
            var antRed = new AntRed(borders);
            // Assert
            Assert.InRange(antRed.X, 0, borders.Width);
            Assert.InRange(antRed.Y, 0, borders.Height);
            Assert.NotNull(antRed.AntImage);
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
                    Assert.True(pixelColor.ToString() == ColorTranslator.FromHtml("#FF0000").ToString(), $"Not all white pixels are converted to Red. X,Y: {x},{y} has color: {pixelColor.ToString()}.");
                }
            }
        }

        [Fact]
        public static void AntRed_Move_Works()
        {
            // Arrange
            var borders = new Size(800, 450);
            var antRed = new AntRed(borders);
            int initialX = antRed.X;
            int initialY = antRed.Y;
            // Act
            antRed.Move(borders);
            // Assert
            Assert.InRange(antRed.X, 0, borders.Width);
            Assert.InRange(antRed.Y, 0, borders.Height);
            Assert.True(antRed.X != initialX || antRed.Y != initialY, "Ant did not move.");
        }
    }
}
