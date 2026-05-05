using System;

namespace Colors
{
    enum ColorType
    {
        RGB
    }

    struct RGBColor
    {
        private int r;
        private int g;
        private int b;
        private ColorType type;

        public RGBColor(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            type = ColorType.RGB;
        }

        public void Input()
        {
            Console.Write("Enter R: ");
            r = int.Parse(Console.ReadLine());

            Console.Write("Enter G: ");
            g = int.Parse(Console.ReadLine());

            Console.Write("Enter B: ");
            b = int.Parse(Console.ReadLine());

            type = ColorType.RGB;
        }

        public void Output()
        {
            Console.WriteLine("Color type: " + type);
            Console.WriteLine("RGB: (" + r + ", " + g + ", " + b + ")");
        }

        public string ToHex()
        {
            return "#" + r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
        }

        public void ToHsl()
        {
            double rd = r / 255.0;
            double gd = g / 255.0;
            double bd = b / 255.0;

            double max = Math.Max(rd, Math.Max(gd, bd));
            double min = Math.Min(rd, Math.Min(gd, bd));
            double h = 0;
            double s;
            double l = (max + min) / 2;

            if (max == min)
            {
                h = 0;
                s = 0;
            }
            else
            {
                double d = max - min;

                if (l > 0.5)
                    s = d / (2.0 - max - min);
                else
                    s = d / (max + min);

                if (max == rd)
                    h = (gd - bd) / d + (gd < bd ? 6 : 0);
                else if (max == gd)
                    h = (bd - rd) / d + 2;
                else
                    h = (rd - gd) / d + 4;

                h /= 6;
            }

            Console.WriteLine("HSL: (" + (int)(h * 360) + ", " + (int)(s * 100) + "%, " + (int)(l * 100) + "%)");
        }

        public void ToCmyk()
        {
            double rd = r / 255.0;
            double gd = g / 255.0;
            double bd = b / 255.0;

            double k = 1 - Math.Max(rd, Math.Max(gd, bd));
            double c = 0;
            double m = 0;
            double y = 0;

            if (k != 1)
            {
                c = (1 - rd - k) / (1 - k);
                m = (1 - gd - k) / (1 - k);
                y = (1 - bd - k) / (1 - k);
            }

            Console.WriteLine("CMYK: (" +
                (int)(c * 100) + "%, " +
                (int)(m * 100) + "%, " +
                (int)(y * 100) + "%, " +
                (int)(k * 100) + "%)");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("===== TASK 3 =====");

        Colors.RGBColor color = new Colors.RGBColor();
        color.Input();

        Console.WriteLine();
        color.Output();

        Console.WriteLine("HEX: " + color.ToHex());
        color.ToHsl();
        color.ToCmyk();
    }
}