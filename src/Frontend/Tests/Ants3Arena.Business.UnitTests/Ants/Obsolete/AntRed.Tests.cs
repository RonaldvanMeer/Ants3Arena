using Ant3Arena.Business.Ants.Obsolete;
using System.Drawing;
using System.Runtime.Versioning;
using Xunit;

namespace Ants3Arena.Business.UnitTests.Ants.Obsolete
{
    [SupportedOSPlatform("Windows")]
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
                    if (pixelColor.A == 0 || pixelColor.R == 0 && pixelColor.G == 0 && pixelColor.B == 0)
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

        // Extend with al cases, just to give an idea how to handle a single unittest with multiple data sets.
        [Theory]
        [InlineData(0, 0, "LeftUp", "RightDown")]
        [InlineData(0, 225, "LeftUp", "RightUp")]
        [InlineData(400, 0, "LeftUp", "LeftDown")]
        [InlineData(800, 0, "RightUp", "LeftDown")]
        [InlineData(0, 450, "LeftDown", "RightUp")]
        [InlineData(800, 450, "RightDown", "LeftUp")]
        public static void AntRed_Top_Bounces_To_Correct_Direction(int x, int y, string origin, string target)
        {
            // Arrange
            var borders = new Size(800, 450);
            var antRed = new AntRed(borders)
            {
                X = x,
                Y = y,
                Direction = origin
            };
            // Act
            antRed.Move(borders);
            // Assert
            Assert.Equal(target, antRed.Direction);
        }
    }
}
