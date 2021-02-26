using Newtonsoft.Json;
using Profit.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Profit
{
    public partial class ProductivityForm : Form
    {
        Connection Database = new Connection();
        bool locked = true;
        decimal maxLucro = 0;
        decimal minValue = 0;
        SeriesChartType graphic = SeriesChartType.Column;
        ChartArea chart;
        Point? prevPosition = null;
        public ProductivityForm()
        {
            InitializeComponent();
            cbIntervalo.SelectedIndex = 2;
        }
        #region FormMovement
        private bool mouseDown;
        private System.Drawing.Point lastLocation;
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new System.Drawing.Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion
        private List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (Exception excpt)
            {
                MessageBox.Show("Erro na função DirSearch -> Productivity\n" + excpt.Message);
            }

            return files;
        }
        
        void BuildChart()
        {
            try
            {                
                maxLucro = 0;
                minValue = 0;
                chart = chart1.ChartAreas[0];
                List<DayResults> dayResults = new List<DayResults>();
                List<string> dias = new List<string>();

                Database.OpenConnection();
                string query = "select count(*) as sales, data, sum(lucro) as lucro, sum(gasto) as gasto, sum(total) as total from VENDA WHERE data BETWEEN '" + datePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + datePicker2.Value.ToString("yyyy-MM-dd") + "' AND status='CONCLUÍDO' group by data";
                SQLiteCommand cmd = new SQLiteCommand(query, Database.con);
                SQLiteDataAdapter da = null;
                DataTable dt = new DataTable();
                da = new SQLiteDataAdapter(cmd.CommandText, Database.con);
                da.Fill(dt);
                Database.CloseConnection();

                if (dt.Rows.Count > 0)
                {
                    for (int a = 0; a < dt.Rows.Count; a++)
                    {
                        dayResults.Add(new DayResults
                        {
                            vendas = Convert.ToInt32(dt.Rows[a]["sales"]) ,
                            liquido = Convert.ToDecimal(dt.Rows[a]["total"]) - Convert.ToDecimal(dt.Rows[a]["gasto"]),
                            dia = Convert.ToDateTime(dt.Rows[a]["data"]).ToString("yyy-MM-dd")
                        });
                    }

                    maxLucro = dayResults.Max(x => x.liquido);
                    minValue = dayResults.Min(x => x.liquido);

                    chart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
                    chart.AxisX.LabelStyle.Format = "c";
                    chart.AxisY.LabelStyle.Format = "c";
                    chart.AxisY.LabelStyle.IsEndLabelVisible = true;

                    chart.AxisX.Minimum = 1;

                    if (dayResults.Count > 10)
                    {
                        chart.AxisX.Maximum = Math.Round((double)(dayResults.Count / 2), 0);
                    }
                    else
                    {
                        chart.AxisX.Maximum = dayResults.Count;
                    }

                    chart.AxisY.Minimum = 0;
                    chart.AxisY.Maximum = (double)maxLucro + 10;

                    chart.AxisX.Interval = 1;
                    chart.AxisY.Interval = (double)maxLucro / Convert.ToInt32(cbIntervalo.SelectedItem);

                    if (chart1.Series.Count <= 0)
                    {
                        chart1.Series.Add("Lucro Líquido");
                        chart1.Series.Add("Vendas");
                    }

                    chart1.Series["Lucro Líquido"].ChartType = graphic;
                    chart1.Series["Lucro Líquido"].Points.Clear();
                    chart1.Series["Vendas"].ChartType = graphic;
                    chart1.Series["Vendas"].Points.Clear();

                    for (int i = 0; i < dayResults.Count; i++)
                    {
                        chart1.Series["Lucro Líquido"].Points.AddXY(dayResults[i].dia.ToString(), dayResults[i].liquido);
                        chart1.Series["Vendas"].Points.AddXY(dayResults[i].dia.ToString(), dayResults[i].vendas);
                    }

                    chart1.Series["Lucro Líquido"].Color = Color.Red;
                    chart1.Series["Vendas"].Color = Color.Blue;
                }
                else
                {
                    MessageBox.Show("Não há relatórios no período indicado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na função BuildChart -> Productivity\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                  
        }

        private void RbLine_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLine.Checked)
            {
                graphic = SeriesChartType.Spline;
                BuildChart();
            }                
        }

        private void RbBar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBar.Checked)
            {
                graphic = SeriesChartType.Column;
                BuildChart();
            }                
        }

        private void CbIntervalo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!locked)
            {
                BuildChart();
                chart.AxisY.Interval = (double)maxLucro / Convert.ToInt32(cbIntervalo.SelectedItem);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AnimOpen_Tick(object sender, EventArgs e)
        {
            if (animGone.Enabled)
                animGone.Stop();

            if (Opacity < 1)
                Opacity += 0.1;
            else
                animOpen.Stop();
        }

        private void Productivity_Load(object sender, EventArgs e)
        {
            animOpen.Start();

            var today = DateTime.Today;            
            var yesterday = today.AddDays(-1);

            datePicker1.Value = yesterday;
            datePicker2.Value = today;

            locked = false;
        }

        private void Chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;

            if (prevPosition.HasValue && pos == prevPosition.Value)
            {
                return;
            }                

            tooltip1.RemoveAll();

            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);

            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        tooltip1.Show("Valor = " + prop.YValues[0], this.chart1, pos.X, pos.Y - 15);
                    }
                }
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(datePicker2.Value, datePicker1.Value) > 0)
            {
                BuildChart();
            }
            else
            {
                MessageBox.Show("A data final precisa ser maior que a data de início", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }               
        }
    }  
}