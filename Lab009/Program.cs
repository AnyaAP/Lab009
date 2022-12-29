using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

class Program
{
    static async Task<double> AveragePrice(string ticker)
    {
        double averagePrice;
        using var client = new HttpClient();
        string s1 = "https://query1.finance.yahoo.com/v7/finance/download/";
        string s2 = "?period1=1629072000&period2=1660608000&internal=1d&" +
            "events=history&includeAdjustedClose=true";
        string url = s1 + ticker + s2;
        string content;

        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            content = await response.Content.ReadAsStringAsync();
            List<double> averageParts = new();
            string[] parts = content.Split('\n');
            for (int i = 1; i < parts.Length; i += 7)
            {
                string[] values = parts[i].Split(',');
                for (int j = 0; j < values.Length; j++)
                {
                    values[j] = values[j].Replace(".", ",");
                }
                if ((values[2] != "null") && (values[3] != "null"))
                {
                    double val = (Convert.ToDouble(values[2]) + Convert.ToDouble(values[3])) / 2;
                    averageParts.Add(val);
                }
                else
                {
                    double val = 0;
                    averageParts.Add(val);
                }
            }
            averagePrice = averageParts.Average();
        }
        else
        {
            content = "";
            averagePrice = 0;
        }
        return averagePrice;
    }
    static async Task Main()
    {
        // Task 1
        string[] tickers = File.ReadAllLines(@"C:\Users\anyap\source\repos\Lab009\ticker.txt");
        List<double> allPrices = new();
        for (int i = 0; i < tickers.Length; i++)
        {
            allPrices.Add(await AveragePrice(tickers[i]));
        }
        //Task.WaitAll();
        using StreamWriter writer = new(@"C:\Users\anyap\source\repos\Lab009\prices.txt", false);
        for (int i = 0; i < tickers.Length; i++)
        {
            await writer.WriteLineAsync(tickers[i] + ":" + allPrices[i]);
        }
    }
}
