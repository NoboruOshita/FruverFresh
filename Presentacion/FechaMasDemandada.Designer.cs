
namespace Presentacion
{
    partial class FechaMasDemandada
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
            this.chartDistritos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartDistritos)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDistritos
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDistritos.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDistritos.Legends.Add(legend1);
            this.chartDistritos.Location = new System.Drawing.Point(118, 82);
            this.chartDistritos.Name = "chartDistritos";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDistritos.Series.Add(series1);
            this.chartDistritos.Size = new System.Drawing.Size(561, 338);
            this.chartDistritos.TabIndex = 0;
            this.chartDistritos.Text = "chart1";
            this.chartDistritos.Click += new System.EventHandler(this.chart1_Click);
            // 
            // FechaMasDemandada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartDistritos);
            this.Name = "FechaMasDemandada";
            this.Text = "Fecha Mas Demandada";
            this.Load += new System.EventHandler(this.DistritoMayorDemanda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDistritos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDistritos;
    }
}