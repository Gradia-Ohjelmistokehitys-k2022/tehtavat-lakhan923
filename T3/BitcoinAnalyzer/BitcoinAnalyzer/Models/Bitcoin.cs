using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinAnalyzer.Models
{
    /// <summary>
    /// Bitcoin-malli, joka sisältää yhteen Bitcoin-merkintään liittyvät tiedot
    /// Bitcoin model that holds the data related to a single Bitcoin entry (price, market cap, Total_volume etc.)
    /// </summary>
    public class Bitcoin
    {
        public int Id { get; set; } // Unique identifier for the Bitcoin data entry
        public DateTime DateTime { get; set; } // Date and time of the Bitcoin data entry
        public decimal Prices { get; set; }  // Bitcoin price at that specific time
        public decimal Market_caps { get; set; } // Bitcoin market cap at that specific time
        public decimal Total_volumes { get; set; } // Bitcoin total volume traded at that specific time
    }
}
