using Ant3Arena.Business.Interfaces;
using System.Drawing;

namespace Ant3Arena.Business.Ants
{
    public class Ant : IAnt
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; internal set; }
        private readonly int Verticalvelocity = 6;
        private readonly int Horizontalvelocity = 2;
        private readonly Bitmap antImage;
        public Bitmap AntImage { get { return antImage; } }


        public Ant(Size borders, int verticalVelocity, int horizontalVelocity, string color, string direction, Random random)
        {
            Verticalvelocity = verticalVelocity;
            Horizontalvelocity = horizontalVelocity;
            Direction = direction;

            Color newColor = ColorTranslator.FromHtml(color);
            Color white = ColorTranslator.FromHtml("#FFFFFF");

            Bitmap bmp = new Bitmap(Properties.Resources.Ant);

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color gotColor = bmp.GetPixel(x, y);
                    if (gotColor == white)
                        bmp.SetPixel(x, y, newColor);
                }
            }

            this.antImage = bmp;

            X = random.Next(0, borders.Width);
            Y = random.Next(0, borders.Height);
        }

        public void Move(Size borders)
        {
            switch (Direction)
            {
                case "LeftUp":
                    X = X - Horizontalvelocity;
                    Y = Y - Verticalvelocity;

                    if (X < 0 && Y < 500)
                        Direction = "RightDown";
                    else if (X < 0)
                        Direction = "RightUp";
                    else if (Y < 500)
                        Direction = "LeftDown";
                    break;
                case "LeftDown":
                    X = X - Horizontalvelocity;
                    Y = Y + Verticalvelocity;

                    if (X < 0 && Y > borders.Height)
                        Direction = "RightUp";
                    else if (X < 0)
                        Direction = "RightDown";
                    else if (Y > borders.Height)
                        Direction = "LeftUp";
                    break;
                case "RightUp":
                    X = X + Horizontalvelocity;
                    Y = Y - Verticalvelocity;

                    if (X > borders.Width && Y < 500)
                        Direction = "LeftDown";
                    else if (X > borders.Width)
                        Direction = "LeftUp";
                    else if (Y < 500)
                        Direction = "RightDown";
                    break;
                case "RightDown":
                    X = X + Horizontalvelocity;
                    Y = Y + Verticalvelocity;

                    if (X > borders.Width && Y > borders.Height)
                        Direction = "LeftUp";
                    else if (X > borders.Width)
                        Direction = "LeftDown";
                    else if (Y > borders.Height)
                        Direction = "RightUp";
                    break;
            }
        }
    }
}
