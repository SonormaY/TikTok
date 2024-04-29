namespace Lab_2
{
    public static class Task2
    {
        public static double Bandwidth(double v, double q, double pb)
        {
            return Math.Round(v * ((1 - q - pb) * Math.Log2(1 - q - pb) + q * Math.Log2(q) + (1 - pb) * (1 - Math.Log2(1 - pb))), 3);
        }
        public static double GetEntropYX(double p, double q, double pb)
        {
            return -Math.Round(p * Math.Log2(p) + pb * Math.Log2(pb) + q * Math.Log2(q), 3);
        }
        public static double BandwidthCheck(double p, double q, double pb, double v)
        {
            double x = 0.5;
            double y1 = x * (p + q);
            double y2 = x * 2 * pb;
            double HmaxY = -Math.Round(y1 * Math.Log2(y1) * 2 + y2 * Math.Log2(y2), 3);
            return Math.Round(v * (HmaxY - GetEntropYX(p, q, pb)), 3);
        }
         public static void ExecuteTask2()
        {
            Console.Clear();
            Console.WriteLine("Task 2");
            Console.WriteLine("Press Enter to Execute or Esc to skip...");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                return;
            }
            Console.Clear();
            Console.WriteLine("Task 2");
            Console.Write("Enter the p: ");
            double p = double.Parse(Console.ReadLine());
            Console.Write("Enter the q: ");
            double q = double.Parse(Console.ReadLine());
            Console.Write("Enter the pb: ");
            double pb = double.Parse(Console.ReadLine());
            Console.Write("Enter the v: ");
            double v = double.Parse(Console.ReadLine());
            
            Console.Clear();
            Console.WriteLine($"Bandwidth: {Bandwidth(v, q, pb)}");
            Console.WriteLine($"Bandwidth check: {BandwidthCheck(p, q, pb, v)}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}