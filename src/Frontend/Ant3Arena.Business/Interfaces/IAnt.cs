using System.Drawing;

namespace Ant3Arena.Business.Interfaces
{
    public interface IAnt
    {
        string Direction { get; }
        int X { get; set; }
        int Y { get; set; }
        void Move(Size borders);
        Bitmap AntImage { get; }
    }
}
