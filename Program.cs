// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

string inputPath = @"../../../input.csv";
int[] inputArray = new int[1];
// Read input values
using (FileStream stream = File.Open(inputPath, FileMode.Open))
{
    using (StreamReader reader = new StreamReader(stream))
    {
        while (!reader.EndOfStream)
        {
            string inputString = reader.ReadLine();
            inputArray = Array.ConvertAll(inputString.Split(','), int.Parse);
        }
    }
}

// Measure time required to compute result
Stopwatch stopwatch = Stopwatch.StartNew();

// Calculate the maximum according to linear maxsummenproblem
int n = inputArray.Length;
int xn = inputArray[n - 1];
long max = xn;
long sum = xn;
for (int i = n - 1; i > 0; i--)
{
    if (sum <= 0)
    {
        sum = inputArray[i];
    }
    else
    {
        sum = (sum + inputArray[i]);
    }
    if (sum > max)
    {
        max = sum;
    }
}
Console.WriteLine(max);

// Calaulate the maximum according to quadratic maxsummenproblem
//int n = inputArray.Length;
//long max = long.MinValue;
//long sum = 0;
//for (int i = 0; i < n; i++)
//{
//    sum = 0;
//    for (int j = i; j < n; j++)
//    {
//        sum += inputArray[j];
//        if (sum > max)
//        {
//            max = sum;
//        }
//    }
//}
//Console.WriteLine(max);

// Calaulate the maximum according to kubic maxsummenproblem
//int n = inputArray.Length;
//long max = long.MinValue;
//long sum = 0;
//for (int i = 0; i < n; i++)
//{
//    for (int j = i; j < n; j++)
//    {
//        sum = inputArray[i];
//        for (int l = i + 1; l <= j; l++)
//        {
//            sum += inputArray[l];
//        }
//        if (sum > max)
//        {
//            max = sum;
//        }
//    }
//}
//Console.WriteLine(max);

stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);