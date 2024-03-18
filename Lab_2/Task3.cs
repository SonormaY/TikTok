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
                    py[i] += px[j] * PYX[i, j];
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
                HYx[i] = Math.Round(HYx[i], 3);
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
            return Math.Round(HYX, 3);
        }
        public static void ExecuteTask3()
        {
            int n;
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Enter the number of elements in the array:");
                    n = int.Parse(Console.ReadLine());
                    if (n < 2)
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
            double[,] PYX = new double[n, n];
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Task 1");
                Console.WriteLine("Enter the matrix p:");
                try
                {
                    PYX = Task1.ReadMatrix(n);
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
                    T = double.Parse(Console.ReadLine());
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
            double[] px = new double[n];
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Enter the p1:");
                    px[0] = double.Parse(Console.ReadLine());
                    if (px[0] < 0 || px[0] > 1)
                    {
                        throw new Exception();
                    }
                    if (n > 2)
                    {
                        for (int i = 1; i < n; i++)
                        {
                            Console.WriteLine($"Enter the p{i + 1}:");
                            px[i] = double.Parse(Console.ReadLine());
                            if (px[i] < 0 || px[i] > 1)
                            {
                                throw new Exception();
                            }
                        }
                    } else
                    {
                        px[1] = 1 - px[0];
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            
            double[] py = CalculatePy(PYX, px);
            double[] HYx = CalculateHYx(PYX);
            double HY = Task1.GetEntrop1D(py);
            double HYX = CalculateHYX(PYX, px);
        }
    }
}