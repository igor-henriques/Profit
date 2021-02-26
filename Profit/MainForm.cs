using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Linq;
using Profit.Models;
using Profit.Data;
using Microsoft.EntityFrameworkCore;
using Profit.Models.Db.Enums;

namespace Profit
{
    public partial class MainForm : Form
    {
        public string globalkey = string.Empty;
        RelatorioForm relatorios = new RelatorioForm();
        public int lineCount = 0, selectedTask = 0;
        Status currentState = Status.Pendente;
        decimal lucroTotal = 0, gastoTotal = 0;
        string data, modalidade, cliente, id_cliente, total, lucro, desconto, taxa, telefone, endereco, numResidencia, bairro, referencia, conteudo, observacao, troco, forma, hora;
        string hwid;
        public MainForm(string key, string hwid, int remainingDays)
        {
            InitializeComponent();
            globalkey = key;
            this.hwid = hwid;

            lblRemainingDays.Visible = remainingDays < 7 ? true : false;
            lblRemainingDays.Text = "Dias para expirar licença: " + remainingDays;
        }
        #region FormMovement
        private bool mouseDown;
        private Point lastLocation;
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void LblExit_MouseEnter(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.Red;
        }
        private void LblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.Black;
        }
        private void LblMinimize_MouseEnter(object sender, EventArgs e)
        {
            lblMinimize.ForeColor = Color.Red;
        }
        private void LblMinimize_MouseLeave(object sender, EventArgs e)
        {
            lblMinimize.ForeColor = Color.Black;
        }
        private void LblExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja mesmo sair?", "Saindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                Application.Exit();
        }
        private void LblMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void BtnIngCad_Click(object sender, EventArgs e)
        {
            IngredienteForm ing = new IngredienteForm();
            AnimateForms(ing);
            animOpen.Start();
            Hide();
            Show();
            GC.Collect();
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"Dados\"))
                Directory.CreateDirectory(@"Dados\");

            if (!Directory.Exists(@"Dados\Temporario"))
                Directory.CreateDirectory(@"Dados\Temporario");

            if (!Directory.Exists(@"Dados\Backup"))
                Directory.CreateDirectory(@"Dados\Backup");

            animOpen.Start();

            BuildGrid();
            await CatchSpents();
            CalculateProfit();
        }
        private void CalculateProfit()
        {
            try
            {
                lucroTotal = 0;

                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                {
                    if (dgvDetails[12, i].Value.Equals(Status.Concluido))
                        lucroTotal += Convert.ToDecimal(dgvDetails[10, i].Value.ToString().Replace("R$ ", ""));
                }

                lblLucro.Text = (lucroTotal - Convert.ToDecimal(lblDividendos.Text.Replace("R$ ", ""))).ToString("c");
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função CalculateProfit -> MainForm\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void BuildGrid()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var todaySellings = await db.Venda.Include(z => z.Cliente).Where(x => x.Data.Date == DateTime.Today.Date).OrderByDescending(c => c.Hora).ToListAsync();

                    if (todaySellings != null)
                    {
                        if (todaySellings.Count > 0)
                        {
                            dgvDetails.DataSource = todaySellings;
                            FormatColumns();
                            FixClientName();
                        }
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("Erro na função BuildGruid -> MainForm\n" + f.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FixClientName()
        {
            try
            {
                for (int i = 0; i < dgvDetails.Columns.Count; i++)
                {
                    for (int j = 0; j < dgvDetails.Rows.Count; j++)
                    {

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função FixClientName -> MainForm\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnRecCad_Click(object sender, EventArgs e)
        {
            ReceitasForm receita = new ReceitasForm();
            AnimateForms(receita);
            animOpen.Start();
            this.Focus();
            GC.Collect();
        }
        private void BtnProdCad_Click(object sender, EventArgs e)
        {
            ProdutosForm produto = new ProdutosForm();
            AnimateForms(produto);
            animOpen.Start();
            this.Focus();
            GC.Collect();
        }
        #endregion
        private async Task CatchSpents()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var costs = await db.Gasto.Select(x => x.Cost).ToListAsync();
                    lblDividendos.Text = (costs.Sum() / 30).ToString("c");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função CatchSpents -> MainForm\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void BtnSell_Click(object sender, EventArgs e)
        {
            Shortcut shortcut = new Shortcut();
            lineCount = dgvDetails.Rows.Count;
            VendasForm venda = new VendasForm(shortcut, false);
            AnimateForms(venda);
            animOpen.Start();
            this.Focus();

            await RefreshGridAsync();
            GC.Collect();
        }
        private async Task RefreshGridAsync()
        {
            if (dgvDetails.Rows.Count >= 0)
            {
                BuildGrid();
                await CatchSpents();
                CalculateProfit();
            }
        }
        private void BtnGastos_Click(object sender, EventArgs e)
        {
            GastosForm gasto = new GastosForm();
            AnimateForms(gasto);
            RefreshGridAsync();

            animOpen.Start();
            this.Focus();
            GC.Collect();
        }
        private void BtnClients_Click(object sender, EventArgs e)
        {
            ClientesForm client = new ClientesForm();
            AnimateForms(client);
            animOpen.Start();
            this.Focus();
            GC.Collect();
        }
        public void Anim_Tick(object sender, EventArgs e)
        {
            if (animGone.Enabled)
                animGone.Stop();

            if (Opacity < 1)
                Opacity += 0.125;
            else
            {
                animOpen.Stop();
                this.Show();
                this.Focus();
            }
        }
        private void AnimGone_Tick(object sender, EventArgs e)
        {
            if (animOpen.Enabled)
                animOpen.Stop();

            if (Opacity > 0.0)
                Opacity -= 0.075;
            else
                animGone.Stop();
        }
        public void AnimateForms(Form form)
        {
            animGone.Start();
            form.ShowDialog();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                btnIngCad.PerformClick();
                return true;
            }
            else if (keyData == Keys.F6)
            {
                btnRecCad.PerformClick();
                return true;
            }
            else if (keyData == Keys.F7)
            {
                btnProdCad.PerformClick();
                return true;
            }
            else if (keyData == Keys.F8)
            {
                btnGastos.PerformClick();
                return true;
            }
            else if (keyData == Keys.F1)
            {
                btnSell.PerformClick();
                return true;
            }
            else if (keyData == Keys.F2)
            {
                btnClients.PerformClick();
                return true;
            }
            else if (keyData == Keys.F3)
            {
                btnGenerateReport.PerformClick();
                return true;
            }
            else if (keyData == Keys.F4)
            {
                btnData.PerformClick();
                return true;
            }
            else if (keyData == Keys.Delete)
            {
                DeleteRecord();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void DgvDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                try
                {
                    selectedTask = Convert.ToInt32(dgvDetails.SelectedRows[0].Cells[0].Value);
                    currentState = (Status)dgvDetails.SelectedRows[0].Cells[12].Value;
                }
                catch (Exception)
                {

                }
            }
        }
        private async Task FillDetailedData()
        {
            try
            {
                conteudo = "";
                selectedTask = Convert.ToInt32(dgvDetails.SelectedRows[0].Cells[0].Value.ToString());
                data = Convert.ToDateTime(dgvDetails.SelectedRows[0].Cells[3].Value).ToString("dd/MM/yyyy");
                modalidade = dgvDetails.SelectedRows[0].Cells[6].Value.ToString();
                cliente = dgvDetails.SelectedRows[0].Cells[2].Value.ToString();
                total = dgvDetails.SelectedRows[0].Cells[7].Value.ToString();
                lucro = dgvDetails.SelectedRows[0].Cells[9].Value.ToString();
                desconto = dgvDetails.SelectedRows[0].Cells[5].Value.ToString();
                taxa = dgvDetails.SelectedRows[0].Cells[4].Value.ToString();
                id_cliente = dgvDetails.SelectedRows[0].Cells[1].Value.ToString();
                observacao = dgvDetails.SelectedRows[0].Cells[10].Value.ToString();
                troco = dgvDetails.SelectedRows[0].Cells[8].Value.ToString();
                forma = dgvDetails.SelectedRows[0].Cells[12].Value.ToString();
                hora = dgvDetails.SelectedRows[0].Cells[14].Value.ToString();
                gastoTotal = Convert.ToDecimal(dgvDetails.SelectedRows[0].Cells[13].Value.ToString().Replace("R$", "").Trim()) + Convert.ToDecimal(dgvDetails.SelectedRows[0].Cells[5].Value.ToString().Replace("R$", "").Trim());

                using (var db = new ApplicationDbContext())
                {
                    var clients = db.Cliente.Where(x => x.Cpf == id_cliente).FirstOrDefault();

                    if (clients != null)
                    {
                        telefone = clients.Tel;
                        endereco = clients.Rua;
                        numResidencia = clients.Num_residencia.ToString();
                        bairro = clients.Bairro;
                        referencia = clients.Referencia;
                    }
                    else
                    {
                        telefone = "";
                        endereco = "";
                        numResidencia = "";
                        bairro = "";
                        referencia = "";
                    }

                    var productsBought = await db.Venda_Produto.Where(x => x.Id_Venda == selectedTask).Select(x => x.Nome_Produto).ToListAsync();
                    productsBought.ForEach(x => conteudo += $"{x}\n");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função FillDetailedData -> MainForm\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void DgvDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDetails.Rows.Count > 0)
                {
                    selectedTask = Convert.ToInt32(dgvDetails.SelectedRows[0].Cells[0].Value);
                    currentState = (Status)dgvDetails.SelectedRows[0].Cells[12].Value;
                    await FillDetailedData();

                    DetalhesForm detalhe = new DetalhesForm(selectedTask, data, modalidade, cliente, total, lucro, desconto, taxa, telefone, endereco, numResidencia, bairro, referencia, conteudo, observacao, troco, forma, gastoTotal.ToString("c"), hora);
                    animGone.Start();
                    detalhe.ShowDialog();
                    animOpen.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no evento DoubleClick -> MainForm\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                try
                {
                    selectedTask = Convert.ToInt32(dgvDetails.SelectedRows[0].Cells[0].Value);
                    currentState = (Status)dgvDetails.SelectedRows[0].Cells[12].Value;
                }
                catch (Exception)
                {

                }
            }
        }
        private void Panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.WhiteSmoke;
            mainLabel.BackColor = Color.WhiteSmoke;
        }
        private void Panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            mainLabel.BackColor = Color.White;
        }
        private async void RefreshTime_Tick(object sender, EventArgs e)
        {
            if (await CheckLicense() is false)
            {
                GC.Collect();

                Close();
            }
        }
        private async Task DeleteRecord()
        {
            try
            {
                if (selectedTask != 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Deseja realmente excluir esse(s) registro(s)?", "Excluindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        using (var db = new ApplicationDbContext())
                        {
                            for (int i = 0; i < dgvDetails.SelectedRows.Count; i++)
                            {
                                db.Venda_Produto.Remove(db.Venda_Produto.Find(Convert.ToInt32(dgvDetails.Rows[i].Cells[0].Value)));
                                db.Venda.Remove(db.Venda.Find(Convert.ToInt32(dgvDetails.Rows[i].Cells[0].Value)));
                            }

                            await db.SaveChangesAsync();
                        }

                        await RefreshGridAsync();

                        AutoClosingMessageBox.Show("Venda removida do banco de dados", "Sucesso", 2000);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na função DeleteRecord -> MainForm\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteRecord();
        }
        private void BtnHelp_Click(object sender, EventArgs e)
        {
            InformationsForm info = new InformationsForm();
            animGone.Start();
            info.ShowDialog();
            animOpen.Start();
        }
        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                AnimateForms(relatorios);
                animOpen.Start();

                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no evento GenerateReport -> MainForm\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnData_Click(object sender, EventArgs e)
        {
            ProductivityForm produtividade = new ProductivityForm();
            AnimateForms(produtividade);
            animOpen.Start();
            Hide();
            Show();

            GC.Collect();
        }
        public void FormatColumns()
        {
            dgvDetails.Columns[0].Visible = false;
            dgvDetails.Columns[1].Visible = false;
            dgvDetails.Columns[2].Visible = false;
            dgvDetails.Columns[4].Visible = false;
            dgvDetails.Columns[5].Visible = false;
            dgvDetails.Columns[6].Visible = false;
            dgvDetails.Columns[10].Visible = false;
            dgvDetails.Columns[14].Visible = false;

            dgvDetails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDetails.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDetails.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvDetails.Columns[8].DefaultCellStyle.Format = "c";
            dgvDetails.Columns[9].DefaultCellStyle.Format = "c";
            dgvDetails.Columns[15].DefaultCellStyle.Format = "HH:mm";
            dgvDetails.ColumnHeadersDefaultCellStyle.Font = new Font("CaviarDreams", 12F, FontStyle.Bold);

            dgvDetails.Columns[3].HeaderText = "NOME";
            dgvDetails.Columns[15].HeaderText = "HORA";
            dgvDetails.Columns[7].HeaderText = "MODALIDADE";
            dgvDetails.Columns[8].HeaderText = "TOTAL";
            dgvDetails.Columns[9].HeaderText = "TROCO";
            dgvDetails.Columns[11].HeaderText = "OBSERVAÇÃO";
            dgvDetails.Columns[12].HeaderText = "STATUS";
            dgvDetails.Columns[13].HeaderText = "FORMA";

            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                if (dgvDetails.Rows[i].Cells[12].Value.Equals(Status.Pendente))
                {
                    dgvDetails.Rows[i].Cells[12].Style.BackColor = Color.Orange;
                }
                else if (dgvDetails.Rows[i].Cells[12].Value.Equals(Status.Concluido))
                {
                    dgvDetails.Rows[i].Cells[12].Style.BackColor = Color.Green;
                }
                else if (dgvDetails.Rows[i].Cells[12].Value.Equals(Status.Cancelado))
                {
                    dgvDetails.Rows[i].Cells[12].Style.BackColor = Color.Red;
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
                dgvDetails.Visible = true;
        }
        private void BtnBackup_MouseEnter(object sender, EventArgs e)
        {
            btnBackup.BackColor = Color.Gainsboro;
        }
        private void BtnBackup_MouseLeave(object sender, EventArgs e)
        {
            btnBackup.BackColor = Color.White;
        }
        private void BtnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\Dados\Backup\" + DateTime.Now.ToString().Replace("/", "-").Replace(":", ".")))
                {
                    var dir = Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Dados\Backup\" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "."));
                    File.Copy(Directory.GetCurrentDirectory() + @"\database.db", dir.FullName + @"\database.db");

                    MessageBox.Show("Database salva com sucesso na pasta\n Dados/Backup/" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "."), "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Passou-se pouco tempo desde o último backup. Tente novamente em instantes", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no evento Backup -> MainForm\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pbUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() =>
                {
                    string URL = "http://" + File.ReadLines("pid").Skip(1).Take(1).First() + "/data/data.zip";
                    string client_version = File.ReadLines("pid").Skip(3).Take(1).First();

                    WebClient wc = new WebClient();
                    string query = "http://" + File.ReadAllLines("pid").Skip(1).Take(1).First() + "/pid.txt";
                    string server_version = wc.DownloadString("http://" + File.ReadAllLines("pid").Skip(1).Take(1).First() + "/pid.txt");

                    if (client_version != server_version)
                    {
                        if (DialogResult.Yes == MessageBox.Show("A atualização " + server_version + " está disponível. Deseja atualizar agora?", "Atualização Disponível", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            Process.Start(Directory.GetCurrentDirectory() + @"\Atualizador.exe");

                            GC.Collect();

                            Process p = Process.GetCurrentProcess();
                            p.Kill();
                        }
                    }
                    else
                    {
                        MessageBox.Show("O software está atualizado.", "Tudo certo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no evento Update -> MainForm\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pbUpdate_MouseEnter(object sender, EventArgs e)
        {
            pbUpdate.BackColor = Color.Gainsboro;
        }
        private void pbUpdate_MouseLeave(object sender, EventArgs e)
        {
            pbUpdate.BackColor = Color.White;
        }
        private void dgvDetails_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hti = dgvDetails.HitTest(e.X, e.Y);
                    dgvDetails.ClearSelection();
                    dgvDetails.Rows[hti.RowIndex <= -1 ? 0 : hti.RowIndex].Selected = true;

                    Point here = new Point((dgvDetails.Location.X - lastLocation.X) + e.X, (dgvDetails.Location.Y - lastLocation.Y) + e.Y);
                    selectedTask = Convert.ToInt32(dgvDetails.SelectedRows[0].Cells[0].Value);
                    ctxMenu.Show(this, here);
                }
            }
            catch (Exception)
            {

            }
        }
        private void ctxDetail_Click(object sender, EventArgs e)
        {
            DgvDetails_CellDoubleClick(null, null);
        }
        private async void ctxPrint_Click(object sender, EventArgs e)
        {
            await FillDetailedData();
            DetalhesForm prepare = new DetalhesForm(selectedTask, data, modalidade, cliente, total, lucro, desconto, taxa, telefone, endereco, numResidencia, bairro, referencia, conteudo, observacao, troco, forma, gastoTotal.ToString("c"), hora);

            prepare.Printing();
        }

        private async void ctxSituation_Click(object sender, EventArgs e)
        {
            selectedTask = Convert.ToInt32(dgvDetails.SelectedRows[0].Cells[0].Value);
            currentState = (Status)Convert.ToInt32(dgvDetails.SelectedRows[0].Cells[12].Value);

            SelectState state = new SelectState(currentState, selectedTask);
            state.ShowDialog();

            CalculateProfit();

            await RefreshGridAsync();

            GC.Collect();
        }

        private async void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (tbSearch.Text.Trim() != string.Empty)
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var search = from i in db.Venda where EF.Functions.Like(i.Name, $"%{tbSearch.Text.Trim()}%") select i;

                        if (search.Count() > 0)
                        {
                            rbTodos.Checked = false;
                            dgvDetails.DataSource = await search.OrderByDescending(x => x.Hora).ToListAsync();
                            dgvDetails.Rows[dgvDetails.Rows.Count - 1].Selected = true;
                            FormatColumns();
                        }
                        else
                        {
                            rbTodos.Checked = true;
                        }
                    }
                }
                else
                {
                    Refresh();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            tbSearch.ForeColor = Color.Black;
            tbSearch.Clear();
            tbSearch.Focus();
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            tbSearch.ForeColor = Color.Gray;
            if (tbSearch.Text.Trim() == string.Empty)
                tbSearch.Text = "ex.: ''Fulano da Silva''";
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshGridAsync();
        }

        private async void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodos.Checked)
                await RefreshGridAsync();
        }

        private void rbPendentes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPendentes.Checked)
            {
                try
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var pendingSellings = db.Venda.Where(x => x.Status == Status.Pendente).ToList();

                        dgvDetails.DataSource = pendingSellings.OrderByDescending(x => x.Hora).ToList();

                        if (dgvDetails.Rows.Count > 0)
                            dgvDetails.Rows[dgvDetails.Rows.Count - 1].Selected = true;

                        FormatColumns();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro no evento PendentesCheckedChange -> MainForm\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rbCancelados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCancelados.Checked)
            {
                try
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var pendingSellings = db.Venda.Where(x => x.Status == Status.Cancelado).ToList();

                        dgvDetails.DataSource = pendingSellings.OrderByDescending(x => x.Hora).ToList();

                        if (dgvDetails.Rows.Count > 0)
                            dgvDetails.Rows[dgvDetails.Rows.Count - 1].Selected = true;

                        FormatColumns();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro no evento CanceladosCheckedChange -> MainForm\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rbConcluidos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConcluidos.Checked)
            {
                try
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var pendingSellings = db.Venda.Where(x => x.Status == Status.Concluido).ToList();

                        dgvDetails.DataSource = pendingSellings.OrderByDescending(x => x.Hora).ToList();

                        if (dgvDetails.Rows.Count > 0)
                            dgvDetails.Rows[dgvDetails.Rows.Count - 1].Selected = true;

                        FormatColumns();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro no evento ConcluidosCheckedChange -> MainForm\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ctxDelete_Click(object sender, EventArgs e)
        {
            await DeleteRecord();
        }
        public Task<bool> CheckLicense()
        {
            try
            {
                AuthenticationForm auth = new AuthenticationForm();
                string query = "SELECT active FROM profit WHERE licensekey=@licensekey";
                MySqlCommand cmd = new MySqlCommand(query, auth.conn);
                cmd.Parameters.AddWithValue("licensekey", globalkey);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows && dr[0].ToString() == "1")
                {
                    return Task.FromResult(true);
                }
                else
                {
                    AutoClosingMessageBox.Show("Sua licença está inativa. Entre em contato com o administrador.", "ERRO", 10000);
                    Process p = Process.GetCurrentProcess();
                    p.Kill();
                    Application.Exit();
                    return Task.FromResult(false);
                }
            }
            catch (Exception)
            {
                AutoClosingMessageBox.Show("Erro de verificação de licença. Verifique sua conexão e tente novamente.", "ERRO", 10000);
                Process p = Process.GetCurrentProcess();
                p.Kill();
                Close();
                return Task.FromResult(false);
            }
        }
    }
}