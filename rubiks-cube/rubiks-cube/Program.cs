using System;

namespace rubiks_cube
{
    class Program
    {
        public static Cube cube;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            bool exitApp = false;

            cube = new();
            cube.Print();

            while (!exitApp)
            {
                exitApp = ProcessCommand();
            }

            Console.ReadLine();
        }

        private static string GetInput()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Turn: ");
            var input = Console.ReadLine();
            Console.Clear();
            return input;
        }

        private static bool ProcessCommand()
        {
            var input = GetInput();

            switch (input)
            {
                // same layout as WASD on num pad to rotate cube
                case "8":
                    break;
                case "2":
                    break;
                case "4":
                    break;
                case "6":
                    break;


                case "L":
                    cube.LeftTurn(clockwise: true);
                    break;

                case "L'":
                    cube.LeftTurn(clockwise: false);
                    break;

                case "R":
                    cube.RightTurn(clockwise: true);
                    break;

                case "R'":
                    cube.RightTurn(clockwise: false);
                    break;

                case "U":
                    cube.UpTurn(clockwise: true);
                    break;

                case "U'":
                    cube.UpTurn(clockwise: false);
                    break;

                case "D":
                    cube.DownTurn(clockwise: true);
                    break;

                case "D'":
                    cube.DownTurn(clockwise: false);
                    break;

                case "F":
                    cube.FrontTurn(clockwise: true);
                    break;

                case "F'":
                    cube.FrontTurn(clockwise: false);
                    break;

                case "B":
                    cube.BackTurn(clockwise: true);
                    break;

                case "B'":
                    cube.BackTurn(clockwise: false);
                    break;

                case null:
                    throw new ArgumentException();


            }
            Turn(input);
            return false;
        }

        public static void Turn(string turnCode)
        {
            switch (turnCode)
            {


                //TODO: implement slice turns
            }

            cube.Print();
        }
    }
}
