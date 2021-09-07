namespace rubiks_cube
{
    public static class CubeExtensions
    {
        readonly static int front = 0;
        readonly static int right = 1;
        readonly static int back = 2;
        readonly static int left = 3;
        readonly static int down = 4;
        readonly static int up = 5;


        readonly static int tLeft = 0;
        readonly static int tMiddle = 1;
        readonly static int tRight = 2;
        readonly static int mLeft = 3;
        readonly static int mMiddle = 4;
        readonly static int mRight = 5;
        readonly static int bLeft = 6;
        readonly static int bMiddle = 7;
        readonly static int bRight = 8;



        private static void ClockwiseTurn(this Cube cube, int face)
        {
            var BlockBuffer = new Block[6];
            var blocks = cube.Blocks;

            // top - right
            BlockBuffer[0] = blocks[face, bRight];
            BlockBuffer[1] = blocks[face, mRight];
            BlockBuffer[2] = blocks[face, tRight];

            blocks[face, bRight] = blocks[face, tRight];
            blocks[face, mRight] = blocks[face, tMiddle];
            blocks[face, tRight] = blocks[face, tLeft];

            // right - bottom
            BlockBuffer[3] = blocks[face, bRight];
            BlockBuffer[4] = blocks[face, bMiddle];
            BlockBuffer[5] = blocks[face, bLeft];

            blocks[face, bMiddle] = BlockBuffer[1];
            blocks[face, bLeft] = BlockBuffer[2];

            // bottom - left
            BlockBuffer[0] = blocks[face, tLeft];
            BlockBuffer[1] = blocks[face, mLeft];
            BlockBuffer[2] = blocks[face, bLeft];

            blocks[face, tLeft] = BlockBuffer[3];
            blocks[face, mLeft] = BlockBuffer[4];
            blocks[face, bLeft] = BlockBuffer[5];

            // left - top
            // No need to buffer
            blocks[face, tRight] = BlockBuffer[0];
            blocks[face, tMiddle] = BlockBuffer[1];
            blocks[face, tLeft] = BlockBuffer[2];
        }

        private static void CounterClockwiseTurn(this Cube cube, int face)
        {
            var BlockBuffer = new Block[6];
            var blocks = cube.Blocks;

            // right - top
            BlockBuffer[0] = blocks[face, tRight];
            BlockBuffer[1] = blocks[face, tMiddle];
            BlockBuffer[2] = blocks[face, tLeft];

            blocks[face, tRight] = blocks[face, bRight];
            blocks[face, tMiddle] = blocks[face, mRight];
            blocks[face, tLeft] = blocks[face, bRight];

            // top - left
            BlockBuffer[3] = blocks[face, tLeft];
            BlockBuffer[4] = blocks[face, mLeft];
            BlockBuffer[5] = blocks[face, bLeft];

            blocks[face, tLeft] = BlockBuffer[0];
            blocks[face, mLeft] = BlockBuffer[1];
            blocks[face, bLeft] = BlockBuffer[2];

            //left - bottom
            BlockBuffer[3] = blocks[face, tLeft];
            BlockBuffer[4] = blocks[face, mLeft];
            BlockBuffer[5] = blocks[face, bLeft];

            blocks[face, bLeft] = BlockBuffer[3];
            blocks[face, bMiddle] = BlockBuffer[4];
            blocks[face, bRight] = BlockBuffer[5];

            // bottom - right
            blocks[face, tRight] = BlockBuffer[0];
            blocks[face, mRight] = BlockBuffer[1];
            blocks[face, bRight] = BlockBuffer[2];
        }


        public static void FrontTurn(this Cube cube, bool clockwise)
        {
            var BlockBuffer = new Block[6];
            var blocks = cube.Blocks;

            if (clockwise)
            {
                ClockwiseTurn(cube, front);

                // up - right
                BlockBuffer[0] = blocks[right, tLeft];
                BlockBuffer[1] = blocks[right, mLeft];
                BlockBuffer[2] = blocks[right, bLeft];

                blocks[right, tLeft] = blocks[up, bLeft];
                blocks[right, mLeft] = blocks[up, bMiddle];
                blocks[right, bLeft] = blocks[up, bRight];

                // right - down
                BlockBuffer[3] = blocks[down, tLeft];
                BlockBuffer[4] = blocks[down, tMiddle];
                BlockBuffer[5] = blocks[down, tRight];

                blocks[down, tLeft] = BlockBuffer[0];
                blocks[down, tMiddle] = BlockBuffer[1];
                blocks[down, tRight] = BlockBuffer[2];

                // down - left
                BlockBuffer[0] = blocks[left, tRight];
                BlockBuffer[1] = blocks[left, mRight];
                BlockBuffer[2] = blocks[left, bRight];

                blocks[left, tRight] = BlockBuffer[3];
                blocks[left, mRight] = BlockBuffer[4];
                blocks[left, bRight] = BlockBuffer[5];

                // left - up
                // No need to buffer
                blocks[up, bLeft] = BlockBuffer[0];
                blocks[up, bMiddle] = BlockBuffer[1];
                blocks[up, bRight] = BlockBuffer[2];
            }
            else
            {
                CounterClockwiseTurn(cube, front);

                // right - up
                BlockBuffer[0] = blocks[up, bLeft];
                BlockBuffer[1] = blocks[up, bMiddle];
                BlockBuffer[2] = blocks[up, bRight];

                blocks[up, bLeft] = blocks[right, tLeft];
                blocks[up, bMiddle] = blocks[right, mLeft];
                blocks[up, bRight] = blocks[right, bLeft];

                // up - left
                // No need to buffer
                BlockBuffer[3] = blocks[left, tRight];
                BlockBuffer[4] = blocks[left, mRight];
                BlockBuffer[5] = blocks[left, bRight];

                blocks[left, tRight] = BlockBuffer[0];
                blocks[left, mRight] = BlockBuffer[1];
                blocks[left, bRight] = BlockBuffer[2];

                // left - down
                BlockBuffer[0] = blocks[down, tLeft];
                BlockBuffer[1] = blocks[down, tMiddle];
                BlockBuffer[2] = blocks[down, tRight];

                blocks[down, tLeft] = BlockBuffer[3];
                blocks[down, tMiddle] = BlockBuffer[4];
                blocks[down, tRight] = BlockBuffer[5];

                // down - right
                blocks[right, tLeft] = BlockBuffer[0];
                blocks[right, mLeft] = BlockBuffer[1];
                blocks[right, bLeft] = BlockBuffer[2];

            }
        }

        public static void BackTurn(this Cube cube, bool clockwise)
        {
            var BlockBuffer = new Block[6];
            var blocks = cube.Blocks;

            if (clockwise)
            {
                ClockwiseTurn(cube, back);

                // right - up
                BlockBuffer[0] = blocks[up, tLeft];
                BlockBuffer[1] = blocks[up, tMiddle];
                BlockBuffer[2] = blocks[up, tRight];

                blocks[up, tLeft] = blocks[right, tRight];
                blocks[up, tMiddle] = blocks[right, mRight];
                blocks[up, tRight] = blocks[right, bRight];

                // up - left
                BlockBuffer[3] = blocks[left, bLeft];
                BlockBuffer[4] = blocks[left, mLeft];
                BlockBuffer[5] = blocks[left, tLeft];

                blocks[left, bLeft] = BlockBuffer[0];
                blocks[left, mLeft] = BlockBuffer[1];
                blocks[left, tLeft] = BlockBuffer[2];

                // left - down
                BlockBuffer[0] = blocks[down, bRight];
                BlockBuffer[1] = blocks[down, bMiddle];
                BlockBuffer[2] = blocks[down, bLeft];

                blocks[down, bRight] = BlockBuffer[3];
                blocks[down, bMiddle] = BlockBuffer[4];
                blocks[down, bLeft] = BlockBuffer[5];

                // down - right
                blocks[right, tRight] = BlockBuffer[0];
                blocks[right, mRight] = BlockBuffer[1];
                blocks[right, bRight] = BlockBuffer[2];

            }
            else
            {
                CounterClockwiseTurn(cube, back);
             
                // up - right
                BlockBuffer[0] = blocks[right, tRight];
                BlockBuffer[1] = blocks[right, mRight];
                BlockBuffer[2] = blocks[right, bRight];

                blocks[right, tRight] = blocks[up, tLeft];
                blocks[right, mRight] = blocks[up, tMiddle];
                blocks[right, bRight] = blocks[up, tRight];

                // right - down
                BlockBuffer[3] = blocks[down, bLeft];
                BlockBuffer[4] = blocks[down, bMiddle];
                BlockBuffer[5] = blocks[down, bRight];

                blocks[down, bLeft] = BlockBuffer[0];
                blocks[down, bMiddle] = BlockBuffer[1];
                blocks[down, bRight] = BlockBuffer[2];

                // down - left
                BlockBuffer[0] = blocks[left, tLeft];
                BlockBuffer[1] = blocks[left, mLeft];
                BlockBuffer[2] = blocks[left, bLeft];

                blocks[left, tLeft] = BlockBuffer[3];
                blocks[left, mLeft] = BlockBuffer[4];
                blocks[left, bLeft] = BlockBuffer[5];

                // left - up
                blocks[up, tRight] = BlockBuffer[0];
                blocks[up, tMiddle] = BlockBuffer[1];
                blocks[up, tLeft] = BlockBuffer[2];
            }
        }

        public static void DownTurn(this Cube cube, bool clockwise)
        {

        }

        public static void UpTurn(this Cube cube, bool clockwise)
        {

        }

        public static void RightTurn(this Cube cube, bool clockwise)
        {

        }

        public static void LeftTurn(this Cube cube, bool clockwise)
        {

        }
    }
}
