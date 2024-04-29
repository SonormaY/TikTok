using System.Text;

namespace Lab_4;

class Program
{
    static void Task2()
    {
        string code = "CCDBCCBDDCADDCBBDCDDCBBBBCDBBD";
        Dictionary<char, double> dictionary = new Dictionary<char, double>(){
            {'A', 0.03},
            {'B', 0.38},
            {'C', 0.33},
            {'D', 0.26}
        };
        Dictionary<char, string> dictionarycode = new Dictionary<char, string>();
        foreach (var item in dictionary)
        {
            Console.Write("Enter code for {0}: ", item.Key);
            dictionarycode.Add(item.Key, Console.ReadLine());
        }
        Console.WriteLine("Coded message: ");
        string coded = "";
        foreach (var item in code)
        {
            coded += dictionarycode[item];
        }
        //write coded with space every 4 symbols
        for (int i = 0; i < coded.Length; i++)
        {
            if (i % 4 == 0 && i != 0)
            {
                Console.Write(" ");
            }
            Console.Write(coded[i]);
        }
        Console.WriteLine("\n" + coded.Length);
        Console.WriteLine();

        Dictionary<string, double> dictionary2 = new Dictionary<string, double>();

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                string key = dictionary.ElementAt(i).Key.ToString() + dictionary.ElementAt(j).Key.ToString();
                double value = dictionary.ElementAt(i).Value * dictionary.ElementAt(j).Value;
                dictionary2.Add(key, Math.Round(value, 4));
            }
        }
        Console.WriteLine("Sorted dictionary");
        //sort by value
        var sortedDict = from entry in dictionary2 orderby entry.Value descending select entry;
        double sum = 0;
        foreach (var item in sortedDict)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
            sum += item.Value;
        }
        Console.WriteLine($"Sum: {Math.Round(sum, 3)}");

        Dictionary<string, double> temp = new Dictionary<string, double>();
        foreach (var item in sortedDict)
        {
            Console.Write($"Enter fot {item.Key}:");
            int ask = int.Parse(Console.ReadLine());
            temp.Add(item.Key, Math.Round(ask * item.Value, 4));
        }
        foreach (var item in temp)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }
        double lser = temp.Select(x => x.Value).Sum() / 2;
        Console.WriteLine($"Lser: {lser}");

        Dictionary<string, string> tempcode2 = new Dictionary<string, string>();
        foreach (var item in temp)
        {
            Console.Write($"Enter fot {item.Key}:");
            tempcode2.Add(item.Key, Console.ReadLine());
        }
        Console.WriteLine("Coded message: ");
        coded = "";
        for (int i = 0; i < code.Length; i = i + 2)
        {
            coded += tempcode2[code[i].ToString() + code[i + 1].ToString()];
        }
        //write coded with space every 4 symbols
        for (int i = 0; i < coded.Length; i++)
        {
            if (i % 4 == 0 && i != 0)
            {
                Console.Write(" ");
            }
            Console.Write(coded[i]);
        }
        Console.WriteLine("\n" + coded.Length);
    }
    static void Main(string[] args)
    {
        Task3();
    }
    static void Task3()
    {
        Console.Clear();
        // Task2();
        Dictionary<string, string> dictionary = new Dictionary<string, string>(){
            {"A", "01"},
            {"B", "00"},
            {"C", "1"}
        };
        string code = "AACBBAABCAAAAAACCCCC";
        string coded = "";
        foreach (var item in code)
        {
            coded += dictionary[item.ToString()];
        }
        //write coded with space every 4 symbols
        for (int i = 0; i < coded.Length; i++)
        {
            if (i % 4 == 0 && i != 0)
            {
                Console.Write(" ");
            }
            Console.Write(coded[i]);
        }
        Console.WriteLine("\n" + coded.Length);

        Dictionary<char, double> dictionary2 = new Dictionary<char, double>(){
            {'A', 0.31743},
            {'B', 0.25285},
            {'C', 0.42972}
        };
        Dictionary<string, double> dictionary3 = new Dictionary<string, double>(){
            {"AA", 0.55},
            {"AB", 0.2},
            {"AC", 0.25},
            {"BA", 0.31},
            {"BB", 0.46},
            {"BC", 0.23},
            {"CA", 0.15},
            {"CB", 0.17},
            {"CC", 0.68}
        };
        Dictionary<string, double> dictionary4 = new();
        foreach (var item in dictionary3)
        {
            dictionary4.Add(item.Key, Math.Round(dictionary2[item.Key[0]] * item.Value, 3));
        }
        //sort by value
        var sortedDict = from entry in dictionary4 orderby entry.Value descending select entry;
        double sum = 0;
        foreach (var item in sortedDict)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
            sum += item.Value;
        }
        Console.WriteLine($"Sum: {Math.Round(sum, 6)}");

        Dictionary<string, string> tempcode2 = new Dictionary<string, string>();
        foreach (var item in sortedDict)
        {
            Console.Write($"Enter fot {item.Key}:");
            tempcode2.Add(item.Key, Console.ReadLine());
        }
        double Lser = tempcode2.Select(x => x.Value.Length * dictionary4[x.Key]).Sum() / 2;
        Console.WriteLine($"Lser: {Lser}");
        coded = "";
        for (int i = 0; i < code.Length; i = i + 2)
        {
            coded += tempcode2[code[i].ToString() + code[i + 1].ToString()];
        }
        //write coded with space every 4 symbols
        for (int i = 0; i < coded.Length; i++)
        {
            if (i % 4 == 0 && i != 0)
            {
                Console.Write(" ");
            }
            Console.Write(coded[i]);
        }
        Console.WriteLine("\n" + coded.Length);

        Dictionary<char, Dictionary<char, string>> dictionary5 = new (){
            {'A', new Dictionary<char, string>(){
                {'A', "1"},
                {'B', "00"},
                {'C', "01"}
            }},
            {'B', new Dictionary<char, string>(){
                {'A', "01"},
                {'B', "1"},
                {'C', "00"}
            }},
            {'C', new Dictionary<char, string>(){
                {'A', "00"},
                {'B', "01"},
                {'C', "1"}
            }}
        };
        coded = "00";
        for (int i = 1; i < code.Length; i++)
        {
            coded += dictionary5[code[i-1]][code[i]];
        }
        //write coded with space every 4 symbols
        for (int i = 0; i < coded.Length; i++)
        {
            if (i % 4 == 0 && i != 0)
            {
                Console.Write(" ");
            }
            Console.Write(coded[i]);
        }
        Console.WriteLine("\n" + coded.Length);

    }
}