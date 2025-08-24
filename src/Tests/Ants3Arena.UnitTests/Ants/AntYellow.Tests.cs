using Ant_3_Arena.Ants;
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
