using Ant_3_Arena.Ants;
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
