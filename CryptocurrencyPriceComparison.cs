using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class CryptoPriceComparison
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task Main(string[] args)
    {
        Console.WriteLine("Enter the cryptocurrency symbol (e.g., BTC, ETH): ");
        string cryptoSymbol = Console.ReadLine().ToUpper();

        Console.WriteLine($"Fetching prices for {cryptoSymbol}...\n");

        // Get prices from different exchanges
        var binancePrice = await GetBinancePrice(cryptoSymbol);
        var krakenPrice = await GetKrakenPrice(cryptoSymbol);
        var coinbasePrice = await GetCoinbasePrice(cryptoSymbol);

        // Display the results
        Console.WriteLine($"Binance: {binancePrice} USD");
        Console.WriteLine($"Kraken: {krakenPrice} USD");
        Console.WriteLine($"Coinbase: {coinbasePrice} USD");

        // Find the best price
        var bestPrice = Math.Min(binancePrice, Math.Min(krakenPrice, coinbasePrice));
        Console.WriteLine($"\nBest price for {cryptoSymbol} is {bestPrice} USD.");
    }

    // Binance API to fetch cryptocurrency price
    private static async Task<decimal> GetBinancePrice(string symbol)
    {
        var response = await client.GetStringAsync($"https://api.binance.com/api/v3/ticker/price?symbol={symbol}USDT");
        var jsonResponse = JObject.Parse(response);
        return decimal.Parse(jsonResponse["price"].ToString());
    }

    // Kraken API to fetch cryptocurrency price
    private static async Task<decimal> GetKrakenPrice(string symbol)
    {
        var response = await client.GetStringAsync($"https://api.kraken.com/0/public/Ticker?pair={symbol}USD");
        var jsonResponse = JObject.Parse(response);
        return decimal.Parse(jsonResponse["result"][symbol + "USD"]["c"][0].ToString());
    }

    // Coinbase API to fetch cryptocurrency price
    private static async Task<decimal> GetCoinbasePrice(string symbol)
    {
        var response = await client.GetStringAsync($"https://api.coinbase.com/v2/prices/{symbol}-USD/spot");
        var jsonResponse = JObject.Parse(response);
        return decimal.Parse(jsonResponse["data"]["amount"].ToString());
    }
}
