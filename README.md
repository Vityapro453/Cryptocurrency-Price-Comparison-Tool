Explanation:
HttpClient: Used to make asynchronous API requests to the exchanges.
GetBinancePrice, GetKrakenPrice, GetCoinbasePrice: These methods fetch the latest price of a given cryptocurrency (e.g., BTC, ETH) from the respective exchange using their public APIs.
JSON Parsing: The response is parsed using Newtonsoft.Json (JSON.NET), which converts the JSON data into C# objects for easy extraction of the price values.
Price Comparison: The program fetches prices from Binance, Kraken, and Coinbase and displays them, then calculates and shows the best price for the user.

Example Output:

Enter the cryptocurrency symbol (e.g., BTC, ETH):
BTC
Fetching prices for BTC...

Binance: 25000.75 USD
Kraken: 24995.60 USD
Coinbase: 25010.50 USD

Best price for BTC is 24995.60 USD.
