namespace Lab_2
{
    static class Task1
    {
        public static double[,] ReadMatrix(int n, bool ignoreValidation = false)
        {
            double[,] p = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Enter p[{i + 1}, {j + 1}]: ");
                    p[i, j] = double.Parse(Console.ReadLine());
                }
            }
            if (Math.Round(p.Cast<double>().Sum(), 3) != 1 && !ignoreValidation)
            {
                throw new Exception("The sum of the elements of the matrix must be equal to 1");
            }
            return p;
        }
        public static void PrintMatrix(double[,] p)
        {
            int n = p.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{p[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public static double GetEntrop1D(double[] p, bool ignoreRound = false)
        {
            double entrop = 0;
            for (int i = 0; i < p.Length; i++)
            {
                entrop += p[i] * Math.Log2(p[i]);
            }
            if (ignoreRound)
            {
                return -entrop;
            }
            return -Math.Round(entrop, 3);
        }
        public static double GetEntrop2D(double[,] p)
        {
            double entrop = 0;
            for (int i = 0; i < p.GetLength(0); i++)
            {
                for (int j = 0; j < p.GetLength(1); j++)
                {
                    if (p[i, j] == 0)
                        continue;
                    entrop += p[i, j] * Math.Log2(p[i, j]);
                }
            }
            return -Math.Round(entrop, 3);
        }
        public static double[] UnconditionalDistributionX(double[,] p)
        {
            int n = p.GetLength(0);
            double[] x = new double[n];
            for (int i = 0; i < n; i++)
            {
                x[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    x[i] += p[i, j];
                }
                x[i] = Math.Round(x[i], 2);
            }
            return x;
        }
        public static double[] UnconditionalDistributionY(double[,] p)
        {
            int n = p.GetLength(1);
            double[] y = new double[n];
            for (int j = 0; j < n; j++)
            {
                y[j] = 0;
                for (int i = 0; i < n; i++)
                {
                    y[j] += p[i, j];
                }
                y[j] = Math.Round(y[j], 2);
            }
            return y;
        }
        public static double[,] TransitionMatrixYX(double[,] p)
        {
            int n = p.GetLength(0);
            double[,] q = new double[n, n];
            double[] x = UnconditionalDistributionX(p);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    q[i, j] = Math.Round(p[i, j] / x[i], 3);
                }
            }
            return q;
        }
        public static double AverageAmountOfInformation(double[,] p)
        {
            double HY = GetEntrop1D(UnconditionalDistributionY(p));
            double[,] q = TransitionMatrixYX(p);
            double HYx1 = 0;
            for (int i = 0; i < q.GetLength(0); i++)
            {
                HYx1 += q[0, i] * Math.Log2(q[0, i]);
            }
            return Math.Round(HY + HYx1, 3);
        }
        public static double TransmisionSpeed(double v, double[,] p)
        {
            return Math.Round(v * AverageAmountOfInformation(p), 3);
        }
        public static double Bandwidth(double v, double[,] p)
        {
            double[,] q = TransitionMatrixYX(p);
            double HYx1 = 0;
            for (int i = 0; i < q.GetLength(0); i++)
            {
                HYx1 += q[0, i] * Math.Log2(q[0, i]);
            }
            return Math.Round(v * (Math.Log2(p.GetLength(0)) + HYx1), 3);
        }
        public static void ExecuteTask1()
        {
            Console.Clear();
            Console.WriteLine("Task 1");
            Console.WriteLine("Press Enter to Execute or Esc to skip...");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                return;
            }
            int n;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Task 1");
                try
                {
                    Console.Write("Enter the n: ");
                    n = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            double[,] p = new double[n, n];
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Task 1");
                Console.WriteLine("Enter the matrix p:");
                try
                {
                    p = ReadMatrix(n);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            Console.Write("Enter V: ");
            double v = double.Parse(Console.ReadLine());
            
            Console.Clear();
            Console.WriteLine("Task 1");
            Console.WriteLine($"Unconditional distribution of X: | {string.Join(" | ", UnconditionalDistributionX(p))} |");
            Console.WriteLine($"Unconditional distribution of Y: | {string.Join(" | ", UnconditionalDistributionY(p))} |");
            Console.WriteLine($"\nTransition matrix Y|X: ");
            PrintMatrix(TransitionMatrixYX(p));
            Console.WriteLine($"\nAverage amount of information: {AverageAmountOfInformation(p)}");
            Console.WriteLine($"Transmission speed: {TransmisionSpeed(v, p)}");
            Console.WriteLine($"Bandwidth: {Bandwidth(v, p)}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}