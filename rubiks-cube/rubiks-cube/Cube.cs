using System;
using System.Collections.Generic;

namespace rubiks_cube
{
    public class Cube
    {
        public Block[,] Blocks { get; set; }

        List<RgbColor> Colors { get; set; }

        readonly int front = 0;
        readonly int right = 1;
        readonly int back = 2;
        readonly int left = 3;
        readonly int down = 4;
        readonly int up = 5;

        public Cube()
        {
            Colors = new List<RgbColor>()
            {
                new RgbColor(ColorEnum.Green),
                new RgbColor(ColorEnum.Red),
                new RgbColor(ColorEnum.Yellow),
                new RgbColor(ColorEnum.Orange),
                new RgbColor(ColorEnum.Blue),
                new RgbColor(ColorEnum.White)
            };


            CreateBlocks();
        }

        public void CreateBlocks()
        {
            Blocks = new Block[6, 9];

            for (int face = 0; face < 6; face++)
            {
                for (int square = 0; square < 9; square++)
                {
                    Blocks[face, square] = new Block(Colors[face]);
                }
            }
        }

        public void Print()
        {
            PrintTop();
            PrintMiddle();
            PrintBottom();
            Console.Write("\n\n");
        }

        private static void PrintFillerSpace()
        {
            string Space = " ";
            Console.Write($"{Space}{Space}{Space}{Space}{Space}{Space}");
        }

        private void PrintTop()
        {
            // Top Row
            PrintFillerSpace();
            Blocks[up, 0].Print();
            Blocks[up, 1].Print();
            Blocks[up, 2].Print();
            PrintFillerSpace();
            PrintFillerSpace();
            Console.WriteLine();

            // Middle Row
            PrintFillerSpace();
            Blocks[up, 3].Print();
            Blocks[up, 4].Print();
            Blocks[up, 5].Print();
            PrintFillerSpace();
            PrintFillerSpace();
            Console.WriteLine();

            // Bottom Row
            PrintFillerSpace();
            Blocks[up, 6].Print();
            Blocks[up, 7].Print();
            Blocks[up, 8].Print();
            Console.WriteLine();
        }

        private void PrintMiddle()
        {
            // Top Row
            Blocks[left, 0].Print();
            Blocks[left, 1].Print();
            Blocks[left, 2].Print();
            Blocks[front, 0].Print();
            Blocks[front, 1].Print();
            Blocks[front, 2].Print();
            Blocks[right, 0].Print();
            Blocks[right, 1].Print();
            Blocks[right, 2].Print();
            Blocks[back, 0].Print();
            Blocks[back, 1].Print();
            Blocks[back, 2].Print();
            Console.WriteLine();

            // Middle Row
            Blocks[left, 3].Print();
            Blocks[left, 4].Print();
            Blocks[left, 5].Print();
            Blocks[front, 3].Print();
            Blocks[front, 4].Print();
            Blocks[front, 5].Print();
            Blocks[right, 3].Print();
            Blocks[right, 4].Print();
            Blocks[right, 5].Print();
            Blocks[back, 3].Print();
            Blocks[back, 4].Print();
            Blocks[back, 5].Print();
            Console.WriteLine();

            // Bottom Row
            Blocks[left, 6].Print();
            Blocks[left, 7].Print();
            Blocks[left, 8].Print();
            Blocks[front, 6].Print();
            Blocks[front, 7].Print();
            Blocks[front, 8].Print();
            Blocks[right, 6].Print();
            Blocks[right, 7].Print();
            Blocks[right, 8].Print();
            Blocks[back, 6].Print();
            Blocks[back, 7].Print();
            Blocks[back, 8].Print();
            Console.WriteLine();
        }

        private void PrintBottom()
        {
            // Top Row
            PrintFillerSpace();
            Blocks[down, 0].Print();
            Blocks[down, 1].Print();
            Blocks[down, 2].Print();
            PrintFillerSpace();
            PrintFillerSpace();
            Console.WriteLine();

            // Middle Row
            PrintFillerSpace();
            Blocks[down, 3].Print();
            Blocks[down, 4].Print();
            Blocks[down, 5].Print();
            PrintFillerSpace();
            PrintFillerSpace();
            Console.WriteLine();

            // Bottom Row
            PrintFillerSpace();
            Blocks[down, 6].Print();
            Blocks[down, 7].Print();
            Blocks[down, 8].Print();
            Console.WriteLine();
        }
    }
}
