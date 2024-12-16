using BitcoinAnalyzer.Controllers;
using BitcoinAnalyzer.Models;
using BitcoinAnalyzer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BitcoinAnalyzer
{
    /// <summary>
    /// Form for displaying and interacting with Bitcoin analysis data
    /// </summary>
    public partial class Form1 : Form
    {
        // Controller responsible for handling Bitcoin data fetching and processing
        private BitcoinController bitcoinController;

        // Constructor for initializing the form and the controller
        public Form1()
        {
            InitializeComponent();
            bitcoinController = new BitcoinController();
        }

        /// <summary>
        ///  the method Trigger when the "Analyze" button is clicked
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Analyze_Button_Click(object sender, EventArgs e)
        {
            // Get the selected date range from the user input (Start and End Date)
            DateTime startDate = Start_DatePicker.Value;
            DateTime endDate = End_DatePicker.Value;

            Result_Label.Text = "Fetching data..."; // Show loading message while fetching data

            // Pass the date range to the controller and perform analysis and chart update
            bitcoinController.AnalyzeBitcoinData(startDate, endDate, DisplayResults, UpdateChart);
        }


        /// <summary>
        /// Callback method to display results in the label after analysis
        /// </summary>
        /// <param name="highestPrice">The highest Bitcoin price in the selected date range.</param>
        /// <param name="lowestPrice">The lowest Bitcoin price in the selected date range.</param>
        /// <param name="longestBullish">The longest bullish trend duration in days.</param>
        /// <param name="longestBearish">The longest bearish trend duration in days.</param>
        /// <param name="bestBuy">The best day to buy Bitcoin.</param>
        /// <param name="bestSell">The best day to sell Bitcoin.</param>
        /// <param name="maxProfit">The maximum profit in EUR from buying and selling Bitcoin.</param>
        private void DisplayResults(
            string highestPrice,
            string lowestPrice,
            string longestBullish,
            string longestBearish,
            string bestBuy,
            string bestSell,
            string maxProfit)
        {
            // Update the result label with the analysis results
            Result_Label.Text = $"Highest Price: {highestPrice}\n\n" +
                                $"Lowest Price: {lowestPrice}\n\n" +
                                $"Longest Bullish Trend: {longestBullish}\n\n" +
                                $"Longest Bearish Trend: {longestBearish}\n\n" +
                                $"Best Buy Day: {bestBuy}\n\n" +
                                $"Best Sell Day: {bestSell}\n\n" +
                                $"Max Profit: €{maxProfit}\n\n";
        }


        /// <summary>
        /// Callback method to update the chart with Bitcoin data
        /// </summary>
        /// <param name="bitcoinList">A list of Bitcoin objects containing price data.</param>
        private void UpdateChart(List<Bitcoin> bitcoinList)
        {
            BitcoinChart.Series.Clear(); // Clear any previous chart series

            // Create a new series for the Bitcoin price data (Line chart type)
            var series = new Series("Bitcoin Prices")
            {
                ChartType = SeriesChartType.Line, // Line chart for showing price over time
                BorderWidth = 3
            };

            // Add each Bitcoin data point (Date and Price) to the chart
            foreach (var bitcoin in bitcoinList)
            {
                series.Points.AddXY(bitcoin.DateTime, bitcoin.Prices);// Add Date and Price to chart
            }

            BitcoinChart.Series.Add(series);// Add the series to the chart

            // Dynamically adjust the X-axis based on the date range
            BitcoinChart.ChartAreas[0].AxisX.Minimum = bitcoinList.Min(b => b.DateTime).ToOADate();
            BitcoinChart.ChartAreas[0].AxisX.Maximum = bitcoinList.Max(b => b.DateTime).ToOADate();
            BitcoinChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;// Set X-Axis interval to Days
        }
    }
}
