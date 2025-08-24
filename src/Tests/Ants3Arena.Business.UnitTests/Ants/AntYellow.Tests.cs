using Ant3Arena.Business.Ants;
using System.Drawing;
using System.Runtime.Versioning;
using Xunit;

namespace Ants3Arena.Business.UnitTests.Ants
{
    [SupportedOSPlatform("Windows")]
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
                    if (pixelColor.A == 0 || (pixelColor.R == 0 && pixelColor.G == 0 && pixelColor.B == 0))
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

        // Extend with al cases, just to give an idea how to handle a single unittest with multiple data sets.
        [Theory]
        [InlineData(0, 0, "LeftUp", "RightDown")]
        [InlineData(0, 225, "LeftUp", "RightUp")]
        [InlineData(400, 0, "LeftUp", "LeftDown")]
        [InlineData(800, 0, "RightUp", "LeftDown")]
        [InlineData(0, 450, "LeftDown", "RightUp")]
        [InlineData(800, 450, "RightDown", "LeftUp")]
        public static void AntYellow_Top_Bounces_To_Correct_Direction(int x, int y, string origin, string target)
        {
            // Arrange
            var borders = new Size(800, 450);
            var antYellow = new AntYellow(borders)
            {
                X = x,
                Y = y,
                Direction = origin
            };
            // Act
            antYellow.Move(borders);
            // Assert
            Assert.Equal(target, antYellow.Direction);
        }
    }
}
