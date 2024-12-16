using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BitcoinAnalyzer.Models
{
    /// <summary>
    /// Model representing the structure of the response from the CoinGecko API
    /// </summary>
    public class BitcoinJsonResponse
    {
        // Array holding Bitcoin price data where each entry contains timestamp and price
        public string[,] Prices { get; set; }

        // Array holding Bitcoin market cap data where each entry contains timestamp and market cap
        public string[,] Market_caps { get; set; }

        // Array holding Bitcoin total volume data where each entry contains timestamp and volume
        public string[,] Total_volumes { get; set; }
    }
}
