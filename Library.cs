using SmugMacros.Windows;
using System.Runtime.InteropServices;

namespace SmugMacros
{
    internal static class Library
    {
        [DllImport("user32.dll")]
        internal static extern short GetAsyncKeyState(ushort virtualKeyCode);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern uint SendInput(uint nInputs, Windows.Input[] pInputs, int cbSize);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern nint GetMessageExtraInfo();
    }
}
