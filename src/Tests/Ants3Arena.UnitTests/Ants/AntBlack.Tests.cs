using Ant_3_Arena.Ants;
using System.Drawing;
using Xunit;

namespace Ants3Arena.UnitTests.Ants
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
