using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Converters;
using Profit.Models;

namespace Profit
{
    public partial class RelatorioForm : Form
    {
        Microsoft.Office.Interop.Excel.Application XcelApp;
        Connection Database = new Connection();
        string globalQuery = "id,";
        public RelatorioForm()
        {
            InitializeComponent();
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
        void QuitExcel()
        {
            XcelApp.Quit();

            Process[] p = Process.GetProcessesByName("Excel");

            foreach (var process in p)
            {
                process.Kill();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            QuitExcel();
            animGone.Start();
        }

        private void animGone_Tick(object sender, EventArgs e)
        {
            if (animOpen.Enabled)
                animOpen.Stop();

            if (Opacity > 0)
                Opacity -= 0.125;
            else
            {
                animGone.Stop();
                Close();
            }
        }

        private void animOpen_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1)
                Opacity += 0.1;
            else
                animOpen.Stop();
        }
        public void FormatColumns()
        {
            try
            {
                for (int i = 0; i < dgvDetails.Columns.Count; i++)
                {
                    dgvDetails.Columns[i].HeaderText = dgvDetails.Columns[i].HeaderText.ToUpper();
                    dgvDetails.Columns[i].HeaderText = dgvDetails.Columns[i].HeaderText == "NAME" ? "NOME" : dgvDetails.Columns[i].HeaderText;
                    dgvDetails.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvDetails.Columns[i].DefaultCellStyle.Format = 
                        (
                        dgvDetails.Columns[i].HeaderText.Contains("LUCRO")|| 
                        dgvDetails.Columns[i].HeaderText.Contains("GASTO") ||
                        dgvDetails.Columns[i].HeaderText.Contains("DESCONTO") ||
                        dgvDetails.Columns[i].HeaderText.Contains("LUCRO") ||
                        dgvDetails.Columns[i].HeaderText.Contains("TAXA") ||
                        dgvDetails.Columns[i].HeaderText.Contains("TROCO") ||
                        dgvDetails.Columns[i].HeaderText.Contains("TOTAL")
                        ) ? "c" : "";

                    dgvDetails.Columns[i].Visible = dgvDetails.Columns[i].HeaderText.ToLower().Contains("id") ? false : true;

                }


                /*dgvDetails.Columns[0].Visible = false;
                dgvDetails.Columns[1].Visible = false;
                dgvDetails.Columns[4].Visible = false;
                dgvDetails.Columns[5].Visible = false;
                dgvDetails.Columns[9].Visible = false;

                dgvDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDetails.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDetails.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDetails.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvDetails.Columns[7].DefaultCellStyle.Format = "c";
                dgvDetails.Columns[8].DefaultCellStyle.Format = "c";
                dgvDetails.Columns[9].DefaultCellStyle.Format = "c";
                dgvDetails.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("CaviarDreams", 12F, FontStyle.Bold);

                dgvDetails.Sort(dgvDetails.Columns["data"], ListSortDirection.Descending);

                dgvDetails.Columns[2].HeaderText = "NOME";
                dgvDetails.Columns[3].HeaderText = "HORA";
                dgvDetails.Columns[6].HeaderText = "MODALIDADE";
                dgvDetails.Columns[7].HeaderText = "TOTAL";
                dgvDetails.Columns[8].HeaderText = "TROCO";
                dgvDetails.Columns[10].HeaderText = "OBSERVAÇÃO";
                dgvDetails.Columns[11].HeaderText = "STATUS";
                dgvDetails.Columns[12].HeaderText = "FORMA";

                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                {
                    if (dgvDetails.Rows[i].Cells[11].Value.ToString().Contains("PENDENTE"))
                    {
                        dgvDetails.Rows[i].Cells[11].Style.BackColor = Color.Orange;
                    }
                    else if (dgvDetails.Rows[i].Cells[11].Value.ToString().Contains("CONCLUÍDO"))
                    {
                        dgvDetails.Rows[i].Cells[11].Style.BackColor = Color.Green;
                    }
                    else if (dgvDetails.Rows[i].Cells[11].Value.ToString().Contains("CANCELADO"))
                    {
                        dgvDetails.Rows[i].Cells[11].Style.BackColor = Color.Red;
                    }
                }

                for (int i = 0; i < dgvDetails.RowCount; i++)
                {
                    if (i % 2 == 0)
                        dgvDetails.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                    else
                        dgvDetails.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }

                dgvDetails.ClearSelection();

                if (dgvDetails.Rows.Count <= 0)
                    dgvDetails.Visible = false;
                else
                    dgvDetails.Visible = true;*/
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função FormatColumns -> Relatorio\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void BuildGrid()
        {
            try
            {
                Database.OpenConnection();
                string query = "SELECT * FROM VENDA";
                SQLiteCommand cmd = new SQLiteCommand(query, Database.con);
                SQLiteDataAdapter da = null;
                System.Data.DataTable dt = new System.Data.DataTable();
                da = new SQLiteDataAdapter(cmd.CommandText, Database.con);
                da.Fill(dt);
                Database.CloseConnection();

                dgvDetails.DataSource = dt;

                FormatColumns();
            }
            catch (Exception f)
            {
                MessageBox.Show("Erro na função BuildGrid -> Relatorio\n" + f.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Relatorio_Load(object sender, EventArgs e)
        {
            XcelApp = new Microsoft.Office.Interop.Excel.Application();
            animOpen.Start();

            var today = DateTime.Today;
            var yesterday = today.AddDays(-1);

            datePicker1.Value = yesterday;
            datePicker2.Value = today;

            Task.Run(() => LoadProducts());
        }
        async void LoadProducts()
        {
            try
            {
                List<string> productsName = new List<string>();
                List<string> clientsName = new List<string>();
                List<string> cpfCliente = new List<string>();               

                Database.OpenConnection();
                string query = "SELECT name,price,profit FROM PRODUTO";
                SQLiteCommand cmd = new SQLiteCommand(query, Database.con);
                SQLiteDataAdapter da = null;
                System.Data.DataTable dt = new System.Data.DataTable();
                da = new SQLiteDataAdapter(cmd.CommandText, Database.con);
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    productsName.Add(dt.Rows[i]["name"].ToString());
                }

                BeginInvoke((MethodInvoker)delegate
                {
                    comboBoxProduto.DataSource = productsName;
                    productsName.Clear();
                });

                query = "SELECT cpf,nome FROM CLIENTE";
                cmd = new SQLiteCommand(query, Database.con);
                da = null;
                dt = new System.Data.DataTable();
                da = new SQLiteDataAdapter(cmd.CommandText, Database.con);
                da.Fill(dt);
                Database.CloseConnection();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clientsName.Add(dt.Rows[i]["nome"].ToString());
                    cpfCliente.Add(dt.Rows[i]["cpf"].ToString());
                }

                BeginInvoke((MethodInvoker)delegate
                {
                    comboBoxCliente.Items.Add("TODOS");
                    comboBoxCliente.SelectedIndex = 0;

                    foreach (var client in cpfCliente)
                    {
                        comboBoxCliente.Items.Add(client);
                    }
                });
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função LoadProducts -> Relatorio\n" + e.Message, "ERRO");
                Database.CloseConnection();
            }
        }
        string SalesByProductName(string name)
        {
            string res = "id =";
            
            string query = "SELECT id_VENDA FROM VENDA_PRODUTO WHERE name_PRODUTO='" + name + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, Database.con);
            SQLiteDataAdapter da = null;
            System.Data.DataTable dt = new System.Data.DataTable();
            da = new SQLiteDataAdapter(cmd.CommandText, Database.con);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    res += i == dt.Rows.Count - 1 ? dt.Rows[i]["id_VENDA"].ToString() + " AND " : dt.Rows[i]["id_VENDA"].ToString() + " OR id=";
                }
            }
            else
            {
                res = string.Empty;
            }

            return res;
        }
        bool CheckConditions()
        {
            bool permission = false;

            if (cbCliente.Checked)
                permission = true;
            else if (cbForma.Checked)
                permission = true;
            else if (cbGasto.Checked)
                permission = true;
            else if (cbLucro.Checked)
                permission = true;
            else if (cbProduto.Checked)
                permission = true;
            else if (cbEstado.Checked)
                permission = true;

            return permission;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckConditions())
                {
                    if (DateTime.Compare(datePicker2.Value, datePicker1.Value) > 0)
                    {
                        string query = string.Empty;
                        Database.OpenConnection();
                        Treatments treatments = new Treatments();

                        if (treatments.BasicQuery(cbForma, cbGasto, cbLucro, cbEstado))
                        {
                            globalQuery = globalQuery.Substring(0, globalQuery.Length - 1);
                            query = "SELECT " + globalQuery + ",data FROM VENDA WHERE data BETWEEN '" + datePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + datePicker2.Value.ToString("yyyy-MM-dd") + "'";
                        }
                        else if (treatments.DefaultName(comboBoxCliente) && cbCliente.Checked)
                        {
                            query = "SELECT * FROM VENDA WHERE name is not NULL and name != '' AND data BETWEEN '" + datePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + datePicker2.Value.ToString("yyyy-MM-dd") + "'";
                        }
                        else if (treatments.OtherName(comboBoxCliente) && cbCliente.Checked)
                        {
                            query = "SELECT * FROM VENDA WHERE id_CLIENTE ='" + comboBoxCliente.SelectedItem.ToString() + "' AND data BETWEEN '" + datePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + datePicker2.Value.ToString("yyyy-MM-dd") + "'";
                        }
                        else if (treatments.BasicQueryWithDefaultName(cbLucro, cbGasto, cbForma, cbEstado, comboBoxCliente) && cbCliente.Checked)
                        {
                            query = "SELECT " + globalQuery + ",data FROM VENDA WHERE name is not NULL and name != '' AND data BETWEEN '" + datePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + datePicker2.Value.ToString("yyyy-MM-dd") + "'";
                        }
                        else if (treatments.BasicQueryWithOtherName(cbLucro, cbGasto, cbForma, cbEstado, comboBoxCliente) && cbCliente.Checked)
                        {
                            query = "SELECT " + globalQuery + ",data FROM VENDA WHERE id_CLIENTE ='" + comboBoxCliente.SelectedItem.ToString() + "' AND data BETWEEN '" + datePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + datePicker2.Value.ToString("yyyy-MM-dd") + "'";
                        }
                        else if (treatments.OnlyProduct(cbLucro, cbGasto, cbForma, cbEstado, comboBoxProduto) && !cbCliente.Checked && !treatments.BasicQuery(cbForma, cbGasto, cbLucro, cbEstado))
                        {
                            query = "SELECT * FROM VENDA WHERE " + SalesByProductName(comboBoxProduto.SelectedItem.ToString()) + "data BETWEEN '" + datePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + datePicker2.Value.ToString("yyyy-MM-dd") + "'";
                        }
                        else if (treatments.ProductToThisClient(cbForma, cbGasto, cbLucro, cbEstado ,comboBoxProduto, comboBoxCliente) && cbProduto.Checked && cbCliente.Checked)
                        {
                            query = "SELECT * FROM VENDA WHERE " + SalesByProductName(comboBoxProduto.SelectedItem.ToString()) + " AND id_CLIENTE ='" + comboBoxCliente.SelectedItem.ToString() + "' AND data BETWEEN '" + datePicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + datePicker2.Value.ToString("yyyy-MM-dd") + "'";
                        }

                        SQLiteCommand cmd = new SQLiteCommand(query, Database.con);
                        SQLiteDataAdapter da = null;
                        System.Data.DataTable dt = new System.Data.DataTable();
                        da = new SQLiteDataAdapter(cmd.CommandText, Database.con);
                        da.Fill(dt);
                        Database.CloseConnection();

                        if (dt.Rows.Count > 0)
                        {
                            dgvDetails.DataSource = dt;
                            FormatColumns();
                        }
                        else
                        {
                            MessageBox.Show("Sem resultados. Selecione outro método de pesquisa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        cbForma.Checked = false;
                        cbGasto.Checked = false;
                        cbLucro.Checked = false;
                        cbCliente.Checked = false;
                        cbProduto.Checked = false;
                        cbEstado.Checked = false;
                        comboBoxCliente.SelectedIndex = 0;
                        comboBoxProduto.SelectedIndex = 0;
                        globalQuery = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("A data final precisa ser maior que a data de início", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione algum dos parâmetros à esquerda para gerar relatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no evento btnCalculate -> Relatorio\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool CheckExistingExcel()
        {
            bool permission = false;

            var p = Process.GetProcessesByName("Excel");

            if (p.Length > 0)
                permission = true;

            return permission;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {     
                if (!CheckExistingExcel())
                {
                    try
                    {
                        XcelApp.Application.Workbooks.Add(Type.Missing);
                        for (int i = 1; i < dgvDetails.Columns.Count + 1; i++)
                        {
                            XcelApp.Cells[1, i] = dgvDetails.Columns[i - 1].HeaderText;
                        }

                        for (int i = 0; i < dgvDetails.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvDetails.Columns.Count; j++)
                            {
                                XcelApp.Cells[i + 2, j + 1] = dgvDetails.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        XcelApp.Columns.AutoFit();
                        XcelApp.Visible = true;
                        MessageBox.Show("SALVE SEU RELATÓRIO!\nAO SAIR DA TELA DE RELATÓRIOS, TODOS EXCEL SERÃO FECHADOS.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro no evento btnGerente_Click -> Relatorio\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        QuitExcel();
                    }
                }
                else
                {
                    MessageBox.Show("Feche todas as planilhas do Excel ativas para gerar um novo relatório.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Parâmetros insuficientes para gerar relatório", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCliente.Checked)
            {
                comboBoxCliente.Enabled = true;
            }
            else
            {
                comboBoxCliente.Enabled = false;
            }
        }

        private void rbProduto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProduto.Checked)
            {
                comboBoxProduto.Enabled = true;
            }
            else
            {
                comboBoxProduto.Enabled = false;
            }
        }

        private void rbLucro_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLucro.Checked)
            {
                globalQuery += "lucro,";
            }
            else
            {
                globalQuery.Replace("lucro,", string.Empty);
            }
        }

        private void rbGasto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGasto.Checked)
            {
                globalQuery += "gasto,";
            }
            else
            {
                globalQuery.Replace("gasto,", string.Empty);
            }
        }

        private void rbForma_CheckedChanged(object sender, EventArgs e)
        {
            if (cbForma.Checked)
            {
                globalQuery += "forma,";
            }
            else
            {
                globalQuery.Replace("forma,", string.Empty);
            }

        }

        private void cbEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEstado.Checked)
            {
                globalQuery += "status,";
            }
            else
            {
                globalQuery.Replace("status,", string.Empty);
            }
        }
    }
}
