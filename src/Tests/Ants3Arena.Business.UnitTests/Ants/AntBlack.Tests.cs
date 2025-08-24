using Ant3Arena.Business.Ants;
using System.Drawing;
using Xunit;

namespace Ants3Arena.Busines.UnitTests.Ants
{
    public class AntBlackTests
    {
        [Fact]
        public static void AntBlack_Initialization_Works()
        {
            // Arrange
            var borders = new Size(800, 450);
            // Act
            var antBlack = new AntBlack(borders);
            // Assert
            Assert.InRange(antBlack.X, 0, borders.Width);
            Assert.InRange(antBlack.Y, 0, borders.Height);
            Assert.NotNull(antBlack.AntImage);
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
                    if( pixelColor.A == 0)
                    {
                        continue; // Skip transparent pixels
                    }
                    Assert.True(pixelColor.ToString() == ColorTranslator.FromHtml("#000000").ToString(), $"Not all white pixels are converted black. X,Y: {x},{y} has color: {pixelColor.ToString()}.");
                }
            }
        }

        [Fact]
        public static void AntBlack_Move_Works()
        {
            // Arrange
            var borders = new Size(800, 450);
            var antBlack = new AntBlack(borders);
            int initialX = antBlack.X;
            int initialY = antBlack.Y;
            // Act
            antBlack.Move(borders);
            // Assert
            Assert.InRange(antBlack.X, 0, borders.Width);
            Assert.InRange(antBlack.Y, 0, borders.Height);
            Assert.True(antBlack.X != initialX || antBlack.Y != initialY, "Ant did not move.");
        }
    }
}
