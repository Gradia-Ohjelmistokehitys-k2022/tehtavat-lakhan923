using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using BitcoinAnalyzer.Models;
using Newtonsoft.Json;

namespace BitcoinAnalyzer.Services
{
    /// <summary>
    /// Service class for handling interactions with the CoinGecko API to fetch Bitcoin data
    /// </summary>
    public class BitcoinService
    {

        /// <summary>
        ///  Fetch Bitcoin data for a given date range from CoinGecko API
        /// </summary>
        /// <param name="startTimestamp">The Unix timestamp representing the start date.</param>
        /// <param name="endTimestamp">The Unix timestamp representing the end date.</param>
        /// <returns>A BitcoinJsonResponse containing price, market cap, and volume data.</returns>
        public BitcoinJsonResponse GetBitcoinsInRange(long startTimestamp, long endTimestamp)
        {
            string url = $"https://api.coingecko.com/api/v3/coins/bitcoin/market_chart/range?vs_currency=eur&from={startTimestamp}&to={endTimestamp}";
            BitcoinJsonResponse bitcoinResponse = new BitcoinJsonResponse();

            try
            {
                // Make the API request to CoinGecko
                HttpWebRequest jsonRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse jsonResponse = (HttpWebResponse)jsonRequest.GetResponse();

                string bitcoins;
                using (StreamReader JsonResponseReader = new StreamReader(jsonResponse.GetResponseStream()))
                {
                    bitcoins = JsonResponseReader.ReadToEnd();
                }

                // Deserialize the JSON response into our model
                bitcoinResponse = JsonConvert.DeserializeObject<BitcoinJsonResponse>(bitcoins);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);// Handle any errors during the API request
            }

            return bitcoinResponse;
        }


        /// <summary>
        /// Convert Unix timestamp to DateTime
        /// </summary>
        /// <param name="unixTimestamp">The Unix timestamp to convert.</param>
        /// <returns>A DateTime object representing the Unix timestamp.</returns>
        private DateTime ConvertUnixToDateTime(long unixTimestamp)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(unixTimestamp).DateTime;
        }


        /// <summary>
        /// Method to get Bitcoin data for a given date range and convert to a list of Bitcoin objects
        /// </summary>
        /// <param name="startDate">The start date for the analysis.</param>
        /// <param name="endDate">The end date for the analysis.</param>
        /// <returns>A list of Bitcoin objects containing price, market cap, and volume data.</returns>
        public List<Bitcoin> GetBitcoins(DateTime startDate, DateTime endDate)
        {
            // Convert start and end date to Unix timestamps
            long startUnixTimestamp = ((DateTimeOffset)startDate).ToUnixTimeSeconds();
            long endUnixTimestamp = ((DateTimeOffset)endDate).ToUnixTimeSeconds();

            // Fetch Bitcoin data from API
            BitcoinJsonResponse bitcoins = GetBitcoinsInRange(startUnixTimestamp, endUnixTimestamp);

            List<Bitcoin> bitcoinList = new List<Bitcoin>();

            // Parse the fetched data and convert to a list of Bitcoin objects
            if (bitcoins.Prices.Length > 0)
            {
                for (int i = 0; i < bitcoins.Prices.GetLength(0); i++)
                {
                    Bitcoin bitcoin = new Bitcoin()
                    {
                        DateTime = ConvertUnixToDateTime(long.Parse(bitcoins.Prices[i, 0])),
                        Prices = decimal.Parse(bitcoins.Prices[i, 1].Replace('.', ',')),
                        Market_caps = decimal.Parse(bitcoins.Market_caps[i, 1].Replace('.', ',')),
                        Total_volumes = decimal.Parse(bitcoins.Total_volumes[i, 1].Replace('.', ','))
                    };

                    bitcoinList.Add(bitcoin); // Add the parsed Bitcoin object to the list
                }
                return bitcoinList; // Return the list of Bitcoin data
            }

            return null; // Return null if no data found
        }
    }
}
