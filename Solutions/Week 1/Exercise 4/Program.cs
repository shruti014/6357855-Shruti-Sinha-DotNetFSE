using System;

class Program
{
    // Calculate AVG Monthly Growth Rate
    public static double CalculateAvgGrowthRate(double[] monthlyRevenue, int size)
    {
        double totalGrowth = 0.0;

        for (int i = 1; i < size; i++)
        {
            double growth = (monthlyRevenue[i] - monthlyRevenue[i - 1]) / monthlyRevenue[i - 1];
            totalGrowth += growth;
        }

        return totalGrowth / (size - 1);
    }

    // Forecast Revenue 
    public static double[] Forecast(double[] hist, int histSize, int n)
    {
        double[] forecast = new double[histSize + n];

        // Copy historical data
        for (int i = 0; i < histSize; i++)
        {
            forecast[i] = hist[i];
        }

        double avg = CalculateAvgGrowthRate(hist, histSize);
        double last = hist[histSize - 1];

        for (int i = histSize; i < histSize + n; i++)
        {
            last *= (1 + avg);
            forecast[i] = last;
        }

        return forecast;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter number of past months data: ");
        int n = int.Parse(Console.ReadLine()!);
        double[] past = new double[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter revenue for month {i + 1}: ");
            past[i] = double.Parse(Console.ReadLine()!);
        }

        Console.Write("Enter number of months to forecast: ");
        int m = int.Parse(Console.ReadLine()!);

        double[] result = Forecast(past, n, m);

        Console.WriteLine("\nHistorical Revenue Data");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\tMonth {i + 1}: Rs.{result[i]:F2}");
        }

        Console.WriteLine("\nForecasted Revenue");
        for (int i = n; i < result.Length; i++)
        {
            Console.WriteLine($"\tMonth {i + 1}: Rs.{result[i]:F2}");
        }
    }
}
