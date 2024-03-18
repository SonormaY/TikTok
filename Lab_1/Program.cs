double GetEntrop1D(double[] p)
{
    double entrop = 0;
    for (int i = 0; i < p.Length; i++)
    {
        entrop += p[i] * Math.Log(p[i], 2);
    }
    return -Math.Round(entrop, 3);
}

double GetEntrop2D(double[,] p)
{
    double entrop = 0;
    for (int i = 0; i < p.GetLength(0); i++)
    {
        for (int j = 0; j < p.GetLength(1); j++)
        {
            if (p[i, j] == 0)
                continue;
            entrop += p[i, j] * Math.Log(p[i, j], 2);
        }
    }
    return -Math.Round(entrop, 3);
}

double GetNadl(double[] p)
{
    double result = 1 - GetEntrop1D(p) / Math.Log(p.Length, 2);
    return Math.Round(result, 3);
}


void Task1(){
    Console.Clear();
    System.Console.WriteLine("Enter number of p's: ");
    int n = int.Parse(System.Console.ReadLine());
    double[] array = new double[n];
    for (int i = 0; i < n; i++)
    {
        System.Console.WriteLine("Enter p" + (i + 1) + ": ");
        array[i] = double.Parse(System.Console.ReadLine());
    }
    if (array.Sum() != 1)
    {
        System.Console.WriteLine("Sum of p's must be equal to 1");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return;
    }

    System.Console.WriteLine("Entrop: " + GetEntrop1D(array));
    System.Console.WriteLine("Nadl: " + GetNadl(array));
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

void Task2(){
    Console.Clear();
    System.Console.WriteLine("Enter number of n: ");
    int table = int.Parse(System.Console.ReadLine());
    double[,] array2D = new double[table, table];
    for (int i = 0; i < table; i++)
    {
        for (int j = 0; j < table; j++)
        {
            System.Console.WriteLine("Enter p" + (i + 1) + (j + 1) + ": ");
            array2D[i, j] = double.Parse(System.Console.ReadLine());
        }
    }
    if (array2D.Cast<double>().Sum() != 1)
    {
        System.Console.WriteLine("Sum of p's must be equal to 1");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return;
    }

    double[] x = new double[table];
    double[] y = new double[table];
    for (int i = 0; i < table; i++)
    {
        for (int j = 0; j < table; j++)
        {
            x[i] += array2D[i, j];
        }
    }
    for (int i = 0; i < table; i++)
    {
        for (int j = 0; j < table; j++)
        {
            y[i] += array2D[j, i];
        }
    }
    Console.Clear();
    System.Console.WriteLine("H(X,Y): " + GetEntrop2D(array2D));
    System.Console.WriteLine("H(X): " + GetEntrop1D(x));
    System.Console.WriteLine("H(Y): " + GetEntrop1D(y));
    System.Console.WriteLine("p(X): " + GetNadl(x) + "\np(Y)" + GetNadl(y));

    System.Console.WriteLine("H(Y|X): " + Math.Round(GetEntrop2D(array2D) - GetEntrop1D(x), 3));
    System.Console.WriteLine("H(X|Y): " + Math.Round(GetEntrop2D(array2D) - GetEntrop1D(y), 3));
    System.Console.WriteLine("I(X;Y): " + Math.Round(GetEntrop1D(x) + GetEntrop1D(y) - GetEntrop2D(array2D), 3));
    if (GetNadl(x) > GetNadl(y))
    {
        System.Console.WriteLine("X має більшу надлишковість");
    }
    else
    {
        System.Console.WriteLine("Y має більшу надлишковість");
    }
    if (GetEntrop1D(x) + GetEntrop1D(y) - GetEntrop2D(array2D) == 0)
    {
        System.Console.WriteLine("X та Y незалежні");
    }
    else
    {
        System.Console.WriteLine("X та Y залежні");
    }
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

void Task3()
{
    Console.Clear();
    System.Console.WriteLine("Enter number of x: ");
    int nx = int.Parse(System.Console.ReadLine());
    double[] px = new double[nx];
    for (int i = 0; i < nx; i++)
    {
        System.Console.WriteLine("Enter p" + (i + 1) + ": ");
        px[i] = double.Parse(System.Console.ReadLine());
    }

    if (px.Sum() != 1)
    {
        System.Console.WriteLine("Sum of p's must be equal to 1");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return;
    }
    
    System.Console.WriteLine("Enter matrix:");
    double[,] array2D = new double[nx, nx];
    for (int i = 0; i < nx; i++)
    {
        for (int j = 0; j < nx; j++)
        {
            System.Console.WriteLine("Enter p" + (i + 1) + (j + 1) + ": ");
            array2D[i, j] = double.Parse(System.Console.ReadLine());
        }
    }
    for (int i = 0; i < nx; i++)
    {
        for (int j = 0; j < nx; j++)
        {
            array2D[i, j] = Math.Round(array2D[i, j] * px[i], 3);
        }
    }
    

    if (Math.Round(array2D.Cast<double>().Sum(), 3) != 1)
    {
        System.Console.WriteLine("Sum of p's must be equal to 1");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return;
    }
    Console.Clear();
    for (int i = 0; i < nx; i++)
    {
        for (int j = 0; j < nx; j++)
        {
            System.Console.Write(array2D[i, j] + " ");
        }
        System.Console.WriteLine();
    }

    
    double[] y = new double[nx];
    for (int i = 0; i < nx; i++)
    {
        for (int j = 0; j < nx; j++)
        {
            y[i] += array2D[j, i];
        }
    }
    System.Console.WriteLine("H(X,Y): " + GetEntrop2D(array2D));
    System.Console.WriteLine("H(X): " + GetEntrop1D(px));
    System.Console.WriteLine("p(X): " + GetNadl(px));
    System.Console.WriteLine("H(Y): " + GetEntrop1D(y));
    System.Console.WriteLine("p(Y): " + GetNadl(y));
    System.Console.WriteLine("H(Y|X): " + Math.Round(GetEntrop2D(array2D) - GetEntrop1D(px), 3));
    System.Console.WriteLine("H(X|Y): " + Math.Round(GetEntrop2D(array2D) - GetEntrop1D(y), 3));
    System.Console.WriteLine("I(X;Y): " + Math.Round(GetEntrop1D(px) + GetEntrop1D(y) - GetEntrop2D(array2D), 3));
    if (GetNadl(px) > GetNadl(y))
    {
        System.Console.WriteLine("X має більшу надлишковість");
    }
    else
    {
        System.Console.WriteLine("Y має більшу надлишковість");
    }
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

Task1();
Task2();
Task3();