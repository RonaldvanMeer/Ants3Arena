using System.Drawing;
using System.Runtime.InteropServices;

namespace Ant3Arena.Business.Helpers
{
    public static class ScreenHelper
    {
        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;

        public static Size GetScreenSize()
        {
            return new Size(GetSystemMetrics(SM_CXSCREEN), GetSystemMetrics(SM_CYSCREEN));
        }
    }
}
