using Ant3Arena.Business.Interfaces;
using System.Drawing;
using System.Runtime.Versioning;

namespace Ant3Arena.Business.Ants
{
    /// <summary>
    /// White ant is boxed between top of the window and height of 500px.
	/// Has a Horizontal velocity of 6 and Vertical velocity of 2
    /// </summary>
    [SupportedOSPlatform("Windows")]
    public class AntWhite : IAnt
	{
		public int X { get; set; }
		public int Y { get; set; }
		public string Direction { get; internal set; }
		private int Verticalvelocity = 2;
		private int Horizontalvelocity = 6;
		private readonly string color = "#FFFFFF";
		private readonly Bitmap antImage;

		public Bitmap AntImage { get { return antImage; } }

		public AntWhite(Size borders)
		{
			Direction = "LeftDown";
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

			Random random = new Random();
			X = random.Next(0, borders.Width);
			Y = random.Next(0, borders.Height);
		}

		public void Move(Size borders){
			switch (Direction)
			{
				case "LeftUp":
					X = X - Horizontalvelocity;
					Y = Y - Verticalvelocity;

					if (X < 0 && Y < 0)
						Direction = "RightDown";
					else if (X < 0)
						Direction = "RightUp";
					else if (Y < 0)
						Direction = "LeftDown";
					break;
				case "LeftDown":
					X = X - Horizontalvelocity;
					Y = Y + Verticalvelocity;

					if (X < 0 && Y > 500)
						Direction = "RightUp";
					else if (X < 0)
						Direction = "RightDown";
					else if (Y > 500)
						Direction = "LeftUp";
					break;
				case "RightUp":
					X = X + Horizontalvelocity;
					Y = Y - Verticalvelocity;

					if (X > borders.Width && Y < 0)
						Direction = "LeftDown";
					else if (X > borders.Width)
						Direction = "LeftUp";
					else if (Y < 0)
						Direction = "RightDown";
					break;
				case "RightDown":
					X = X + Horizontalvelocity;
					Y = Y + Verticalvelocity;

					if (X > borders.Width && Y > 500)
						Direction = "LeftUp";
					else if (X > borders.Width)
						Direction = "LeftDown";
					else if (Y > 500)
						Direction = "RightUp";
					break;
			}
		}
	}
}