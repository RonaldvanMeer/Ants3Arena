using Ant3Arena.Business.Ants;
using System.Drawing;
using System.Runtime.Versioning;
using Xunit;

namespace Ants3Arena.Business.UnitTests.Ants
{
    [SupportedOSPlatform("Windows")]
    public class AntWhiteTests
    {
        [Fact]
        public static void AntWhite_Initialization_Works()
        {
            // Arrange
            var borders = new Size(800, 450);
            // Act
            var antWhite = new AntWhite(borders);
            // Assert
            Assert.InRange(antWhite.X, 0, borders.Width);
            Assert.InRange(antWhite.Y, 0, borders.Height);
            Assert.NotNull(antWhite.AntImage);
        }

        [Fact]
        public static void AntWhite_Should_Be_White()
        {
            // Arrange
            var borders = new Size(800, 450);

            // Act
            var antWhite = new AntWhite(borders);

            // Assert
            for (int x = 0; x < antWhite.AntImage.Width; x++)
            {
                for (int y = 0; y < antWhite.AntImage.Height; y++)
                {
                    Color pixelColor = antWhite.AntImage.GetPixel(x, y);
                    if (pixelColor.A == 0 || (pixelColor.R == 0 && pixelColor.G == 0 && pixelColor.B == 0))
                    {
                        continue; // Skip transparent pixels
                    }
                    Assert.True(pixelColor.ToString() == ColorTranslator.FromHtml("#FFFFFF").ToString(), $"Not all white pixels are converted to white. X,Y: {x},{y} has color: {pixelColor.ToString()}.");
                }
            }
        }

        [Fact]
        public static void AntWhite_Move_Works()
        {
            // Arrange
            var borders = new Size(800, 450);
            var antWhite = new AntWhite(borders);
            int initialX = antWhite.X;
            int initialY = antWhite.Y;
            // Act
            antWhite.Move(borders);
            // Assert
            Assert.InRange(antWhite.X, 0, borders.Width);
            Assert.InRange(antWhite.Y, 0, borders.Height);
            Assert.True(antWhite.X != initialX || antWhite.Y != initialY, "Ant did not move.");
        }

        // White ant enters domain above y = 500 px and remains between Top window and y = 500 px
        // Extend with al cases, just to give an idea how to handle a single unittest with multiple data sets.
        [Theory]
        [InlineData(0, 0, "LeftUp", "RightDown")]
        [InlineData(0, 500, "LeftUp", "RightUp")]
        [InlineData(400, 0, "LeftUp", "LeftDown")]
        [InlineData(800, 0, "RightUp", "LeftDown")]
        [InlineData(0, 500, "LeftDown", "RightUp")]
        [InlineData(800, 750, "RightDown", "LeftUp")]
        public static void AntWhite_Top_Bounces_To_Correct_Direction(int x, int y, string origin, string target)
        {
            // Arrange
            var borders = new Size(800, 750);
            var antWhite = new AntWhite(borders)
            {
                X = x,
                Y = y,
                Direction = origin
            };
            // Act
            antWhite.Move(borders);
            // Assert
            Assert.Equal(target, antWhite.Direction);
        }
    }
}
