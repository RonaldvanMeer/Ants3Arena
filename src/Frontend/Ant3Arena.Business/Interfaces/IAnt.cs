using System.Drawing;

namespace Ant3Arena.Business.Interfaces
{
    public interface IAnt
    {
        int X { get; set; }
        int Y { get; set; }
        Bitmap AntImage { get; }

        void Move(Size borders);
    }
}
