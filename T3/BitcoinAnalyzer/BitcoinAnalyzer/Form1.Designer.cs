namespace BitcoinAnalyzer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Start_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.Start_Date = new System.Windows.Forms.Label();
            this.End_Date = new System.Windows.Forms.Label();
            this.End_DatePicker = new System.Windows.Forms.DateTimePicker();
            this.Analyze_Button = new System.Windows.Forms.Button();
            this.Result_Label = new System.Windows.Forms.Label();
            this.BitcoinChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.BitcoinChart)).BeginInit();
            this.SuspendLayout();
            // 
            // Start_DatePicker
            // 
            this.Start_DatePicker.Location = new System.Drawing.Point(144, 24);
            this.Start_DatePicker.Name = "Start_DatePicker";
            this.Start_DatePicker.Size = new System.Drawing.Size(200, 22);
            this.Start_DatePicker.TabIndex = 0;
            // 
            // Start_Date
            // 
            this.Start_Date.AutoSize = true;
            this.Start_Date.Location = new System.Drawing.Point(37, 24);
            this.Start_Date.Name = "Start_Date";
            this.Start_Date.Size = new System.Drawing.Size(72, 16);
            this.Start_Date.TabIndex = 1;
            this.Start_Date.Text = "Start Date: ";
            // 
            // End_Date
            // 
            this.End_Date.AutoSize = true;
            this.End_Date.Location = new System.Drawing.Point(37, 92);
            this.End_Date.Name = "End_Date";
            this.End_Date.Size = new System.Drawing.Size(69, 16);
            this.End_Date.TabIndex = 2;
            this.End_Date.Text = "End Date: ";
            // 
            // End_DatePicker
            // 
            this.End_DatePicker.Location = new System.Drawing.Point(144, 92);
            this.End_DatePicker.Name = "End_DatePicker";
            this.End_DatePicker.Size = new System.Drawing.Size(200, 22);
            this.End_DatePicker.TabIndex = 3;
            // 
            // Analyze_Button
            // 
            this.Analyze_Button.BackColor = System.Drawing.Color.Lime;
            this.Analyze_Button.Location = new System.Drawing.Point(64, 148);
            this.Analyze_Button.Name = "Analyze_Button";
            this.Analyze_Button.Size = new System.Drawing.Size(222, 42);
            this.Analyze_Button.TabIndex = 4;
            this.Analyze_Button.Text = "Analyze Bitcoin Data";
            this.Analyze_Button.UseVisualStyleBackColor = false;
            this.Analyze_Button.Click += new System.EventHandler(this.Analyze_Button_Click);
            // 
            // Result_Label
            // 
            this.Result_Label.AutoSize = true;
            this.Result_Label.Location = new System.Drawing.Point(37, 227);
            this.Result_Label.Name = "Result_Label";
            this.Result_Label.Size = new System.Drawing.Size(58, 16);
            this.Result_Label.TabIndex = 5;
            this.Result_Label.Text = "Results: ";
            // 
            // BitcoinChart
            // 
            chartArea1.Name = "ChartArea1";
            this.BitcoinChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.BitcoinChart.Legends.Add(legend1);
            this.BitcoinChart.Location = new System.Drawing.Point(506, 24);
            this.BitcoinChart.Name = "BitcoinChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.BitcoinChart.Series.Add(series1);
            this.BitcoinChart.Size = new System.Drawing.Size(656, 383);
            this.BitcoinChart.TabIndex = 10;
            this.BitcoinChart.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 450);
            this.Controls.Add(this.BitcoinChart);
            this.Controls.Add(this.Result_Label);
            this.Controls.Add(this.Analyze_Button);
            this.Controls.Add(this.End_DatePicker);
            this.Controls.Add(this.End_Date);
            this.Controls.Add(this.Start_Date);
            this.Controls.Add(this.Start_DatePicker);
            this.Name = "Form1";
            this.Text = "Bitcoin Data Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.BitcoinChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Start_DatePicker;
        private System.Windows.Forms.Label Start_Date;
        private System.Windows.Forms.Label End_Date;
        private System.Windows.Forms.DateTimePicker End_DatePicker;
        private System.Windows.Forms.Button Analyze_Button;
        private System.Windows.Forms.Label Result_Label;
        private System.Windows.Forms.DataVisualization.Charting.Chart BitcoinChart;
    }
}

