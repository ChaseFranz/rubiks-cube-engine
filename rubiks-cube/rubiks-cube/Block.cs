using System;
using System.Runtime.InteropServices;

namespace rubiks_cube
{
    public class Block
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int handle);


        public RgbColor Color { get; set; }


        public Block(RgbColor color)
        {
            Color = color;
        }

        public void Print()
        {
            var handle = GetStdHandle(-11);
            GetConsoleMode(handle, out int mode);
            SetConsoleMode(handle, mode | 0x4);

            var unicodeSquare = "\u25A0 ";
            var squareColorConfig = $"\x1b[38;2;{Color.R};{Color.G};{Color.B}m";
            var block = $"{squareColorConfig}{unicodeSquare}";
            Console.Write(block);
        }
    }
}
