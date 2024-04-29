namespace Lab_2
{
    static class Task3
    {
        public static double[] CalculatePy(double[,] PYX, double[] px)
        {
            double[] py = new double[PYX.GetLength(0)];
            for (int i = 0; i < PYX.GetLength(0); i++)
            {
                for (int j = 0; j < PYX.GetLength(1); j++)
                {
                    py[i] += px[j] * PYX[j, i];
                    
                }
            }
            return py;
        }
        public static double[] CalculateHYx(double[,] PYX)
        {
            double[] HYx = new double[PYX.GetLength(0)];
            for (int i = 0; i < PYX.GetLength(0); i++)
            {
                for (int j = 0; j < PYX.GetLength(1); j++)
                {
                    HYx[i] += -PYX[i, j] * Math.Log2(PYX[i, j]);
                }
            }
            return HYx;
        }
        public static double CalculateHYX(double[,] PYX, double[] px)
        {
            double HYX = 0;
            double[] HYx = CalculateHYx(PYX);
            for (int i = 0; i < PYX.GetLength(0); i++)
            {
                HYX += px[i] * HYx[i];
            }
            return HYX;
        }
        public static double CalculateBandwidth(double[,] PYX, double T, double[] px)
        {
            double HYX = CalculateHYX(PYX, px);
            double HY = Task1.GetEntrop1D(CalculatePy(PYX, px), true);
            return Math.Pow(T, -1) * (HY - HYX);
        }
        public static void MaxBandwidth(double[,] PYX, double T, double start, double end, double step)
        {
            double pxOfMaxBandwidth = 0;
            double maxBandwidth = 0;
            double[] px = { start, 1 - start };
            Console.Clear();
            Console.WriteLine("p(x1) | p(y1) | H(Y) | H(Y|X) | Bandwidth");
            while (px[0] <= end)
            {
                Console.WriteLine($"{px[0]} | {Math.Round(CalculatePy(PYX, px)[0], 3)} | {Math.Round(Task1.GetEntrop1D(CalculatePy(PYX, px), true), 9)} | {Math.Round(CalculateHYX(PYX, px), 9)} | {Math.Round(CalculateBandwidth(PYX, T, px), 7)}");
                double bandwidth = CalculateBandwidth(PYX, T, px);
                if (bandwidth > maxBandwidth)
                {
                    maxBandwidth = bandwidth;
                    pxOfMaxBandwidth = px[0];
                }
                px[0] += step;
                px[0] = Math.Round(px[0], 3);
                px[1] = Math.Round(1 - px[0], 3);
            }
            Console.WriteLine($"\nMax bandwidth: {maxBandwidth} at p(x1) = {pxOfMaxBandwidth}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            switch (step)
            {
                case 0.05:
                    MaxBandwidth(PYX, T, pxOfMaxBandwidth - step, pxOfMaxBandwidth + step, 0.01);
                    break;
                case 0.001:
                    break;
                default:
                    MaxBandwidth(PYX, T, pxOfMaxBandwidth - step, pxOfMaxBandwidth + step, step / 10);
                    break;
            }
        }
        public static void ExecuteTask3()
        {
            Console.Clear();
            Console.WriteLine("Task 3");
            Console.WriteLine("Press Enter to Execute or Esc to skip...");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                return;
            }
            Console.Clear();
            double[,] PYX = new double[2, 2];
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Task 3");
                Console.WriteLine("Enter the matrix p:");
                try
                {
                    PYX = Task1.ReadMatrix(2, true);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            double T;
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Enter the T:");
                    T = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    if (T < 0)
                    {
                        throw new Exception();
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }

            MaxBandwidth(PYX, T, 0.3, 0.8, 0.05);
        }
    }
}