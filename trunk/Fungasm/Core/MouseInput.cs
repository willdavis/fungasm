using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Runtime.InteropServices;

using Tao.Platform.Windows;

namespace Fungasm.Core
{
    public class MouseInput
    {
        public Point MousePosition { get; set; }

        /// <summary>
        /// Gets mouse screen coordinates using GetCursorPos, then converts to System.Windows.Point
        /// relative to the Visual object paramater
        /// </summary>
        /// <param name="visualObject"></param>
        /// <returns></returns>
        public static Point GetPosition(Visual visualObject)
        {
            Win32Point w32MousePoint = new Win32Point();
            GetCursorPos(ref w32MousePoint);
            return visualObject.PointFromScreen(new Point(w32MousePoint.X, w32MousePoint.Y));
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public int X;
            public int Y;
        };

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);
    }
}
