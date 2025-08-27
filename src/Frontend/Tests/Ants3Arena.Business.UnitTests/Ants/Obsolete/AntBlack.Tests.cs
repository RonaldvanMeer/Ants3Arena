using Ant3Arena.Business.Ants.Obsolete;
using System.Drawing;
using System.Runtime.Versioning;
using Xunit;

namespace Ants3Arena.Business.UnitTests.Ants.Obsolete
{
    [SupportedOSPlatform("Windows")]
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

        // Black ant enters domain below y = 500 px and remains between bottom window and y = 500 px
        // Extend with al cases, just to give an idea how to handle a single unittest with multiple data sets.
        [Theory]
        [InlineData(0, 0, "LeftUp", "RightDown")]
        [InlineData(0, 500, "LeftUp", "RightDown")]
        [InlineData(400, 0, "LeftUp", "LeftDown")]
        [InlineData(800, 0, "RightUp", "LeftDown")]
        [InlineData(0, 500, "LeftDown", "RightDown")]
        [InlineData(800, 750, "RightDown", "LeftUp")]
        public static void AntBlack_Top_Bounces_To_Correct_Direction(int x, int y, string origin, string target)
        {
            // Arrange
            var borders = new Size(800, 750);
            var antBlack = new AntBlack(borders)
            {
                X = x,
                Y = y,
                Direction = origin
            };
            // Act
            antBlack.Move(borders);
            // Assert
            Assert.Equal(target, antBlack.Direction);
        }
    }
}
