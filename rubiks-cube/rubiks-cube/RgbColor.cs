namespace rubiks_cube
{
    public class RgbColor
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public RgbColor(ColorEnum color)
        {
            switch (color)
            {
                case ColorEnum.Blue:
                    R = 31;
                    G = 81;
                    B = 255;
                    break;

                case ColorEnum.Green:
                    R = 0;
                    G = 255;
                    B = 0;
                    break;

                case ColorEnum.Orange:
                    R = 255;
                    G = 165;
                    B = 0;
                    break;

                case ColorEnum.Red:
                    R = 255;
                    G = 0;
                    B = 0;
                    break;

                case ColorEnum.White:
                    R = 255;
                    G = 255;
                    B = 255;
                    break;

                case ColorEnum.Yellow:
                    R = 255;
                    G = 255;
                    B = 0;
                    break;
            }
        }
    }
}
