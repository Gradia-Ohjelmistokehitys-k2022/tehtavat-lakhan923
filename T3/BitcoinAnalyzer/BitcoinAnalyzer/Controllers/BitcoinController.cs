using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinAnalyzer.Models;
using BitcoinAnalyzer.Services;

namespace BitcoinAnalyzer.Controllers
{

    /// <summary>
    /// Controller class responsible for analyzing Bitcoin data and preparing results for UI
    /// </summary>
    public class BitcoinController
    {
        private BitcoinService _bitcoinService;

        /// <summary>
        /// Constructor to initialize the service responsible for data fetching
        /// </summary>
        public BitcoinController()
        {
            _bitcoinService = new BitcoinService();
        }

        /// <summary>
        /// Analyze Bitcoin data and invoke callback functions for UI update
        /// </summary>
        /// <param name="startDate">The start date for the analysis.</param>
        /// <param name="endDate">The end date for the analysis.</param>
        /// <param name="displayResultsCallback">The callback function for displaying results on the UI.</param>
        /// <param name="updateChartCallback">The callback function for updating the chart with Bitcoin data.</param>
        public void AnalyzeBitcoinData(
            DateTime startDate,
            DateTime endDate,
            Action<string, string, string, string, string, string, string> displayResultsCallback,
            Action<List<Bitcoin>> updateChartCallback)
        {
            // Fetch the Bitcoin data from service based on selected date range
            List<Bitcoin> bitcoinList = _bitcoinService.GetBitcoins(startDate, endDate);

            if (bitcoinList != null && bitcoinList.Count > 0)
            {
                // Get highest and lowest prices
                var highestPrice = bitcoinList.OrderByDescending(b => b.Prices).First();
                var lowestPrice = bitcoinList.OrderBy(b => b.Prices).First();

                // Get longest bullish and bearish trends
                var longestBullishTrend = GetLongestTrend(bitcoinList, true);
                var longestBearishTrend = GetLongestTrend(bitcoinList, false);

                // Get the best buy and sell days
                var (buyDay, sellDay, maxProfit) = GetBestBuyAndSellDays(bitcoinList);

                // Display results in the UI
                displayResultsCallback?.Invoke(
                    $"{highestPrice.Prices} EUR on {highestPrice.DateTime:dd-MM-yyyy HH:mm:ss}",
                    $"{lowestPrice.Prices} EUR on {lowestPrice.DateTime:dd-MM-yyyy HH:mm:ss}",
                    $"{longestBullishTrend} days",
                    $"{longestBearishTrend} days",
                    $"{buyDay.DateTime:dd-MM-yyyy} at €{buyDay.Prices:F2}",
                    $"{sellDay.DateTime:dd-MM-yyyy} at €{sellDay.Prices:F2}",
                    $"{maxProfit:F2}"  // Max profit formatted as a string
                );

                // Update the chart with Bitcoin price data
                updateChartCallback?.Invoke(bitcoinList);
            }
            else
            {
                // Handle case when no data is found
                displayResultsCallback?.Invoke("No data found.", "", "", "", "", "", "");
            }
        }


        /// <summary>
        /// Calculate the longest bullish or bearish trend
        /// </summary>
        /// <param name="bitcoinList">A list of Bitcoin data objects.</param>
        /// <param name="isBullish">A flag indicating whether to calculate the bullish (true) or bearish (false) trend.</param>
        /// <returns>The length of the longest trend in days.</returns>
        private int GetLongestTrend(List<Bitcoin> bitcoinList, bool isBullish)
        {
            int longestTrend = 0;
            int currentTrend = 0;

            // Iterate through the Bitcoin data to find the longest trend
            for (int i = 1; i < bitcoinList.Count; i++)
            {
                // Check if current trend is bullish or bearish
                if ((isBullish && bitcoinList[i].Prices > bitcoinList[i - 1].Prices) ||
                    (!isBullish && bitcoinList[i].Prices < bitcoinList[i - 1].Prices))
                {
                    currentTrend++;
                }
                else
                {
                    longestTrend = Math.Max(longestTrend, currentTrend);// Update longest trend
                    currentTrend = 0;
                }
            }

            longestTrend = Math.Max(longestTrend, currentTrend);  // Final check
            return longestTrend;
        }


        /// <summary>
        /// Method to find the best buy and sell days based on maximum profit
        /// </summary>
        /// <param name="bitcoinList">A list of Bitcoin data objects.</param>
        /// <returns>A tuple containing the best buy day, best sell day, and the maximum profit.</returns>
        private (Bitcoin buyDay, Bitcoin sellDay, decimal maxProfit) GetBestBuyAndSellDays(List<Bitcoin> bitcoinList)
        {
            Bitcoin buyDay = bitcoinList.First();
            Bitcoin sellDay = bitcoinList.First();
            decimal minPrice = buyDay.Prices;
            decimal maxProfit = 0;

            // Iterate to find the best buy and sell days
            for (int i = 1; i < bitcoinList.Count; i++)
            {
                var currentPrice = bitcoinList[i].Prices;
                var currentProfit = currentPrice - minPrice;

                // If the profit is higher than the current maxProfit, update the max profit best sell day
                if (currentProfit > maxProfit)
                {
                    maxProfit = currentProfit;
                    sellDay = bitcoinList[i];
                }

                // If we find a new minimum price, update the best buy day 
                if (currentPrice < minPrice)
                {
                    minPrice = currentPrice;
                    buyDay = bitcoinList[i];
                }
            }

            return (buyDay, sellDay, maxProfit); // Return best buy, sell, and profit
        }
    }
}
