using Microsoft.EntityFrameworkCore;
using Profit.Data;
using Profit.Models;
using Profit.Models.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Profit
{
    public partial class ClientesForm : Form
    {
        int ableToEdit = 0;
        string cpf;
        Connection Database = new Connection();
        public ClientesForm()
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
        public static string GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
        }
        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cpf = dgvClientes.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception)
            {

            }
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() != string.Empty && tbCpf.Text.Trim() != string.Empty && tbNumber.Text.Trim() != string.Empty)
                await Insert();
            else
                AutoClosingMessageBox.Show("Há campos vazios!\nCampos com '*' são necessários.", "ERRO", 2000);
        }
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                await Delete();
                tbSearch.Clear();
            }
            else
                AutoClosingMessageBox.Show("Selecione uma linha para deletar", "ERRO", 2000);
        }
        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                if (ableToEdit <= 0)
                {
                    dgvClientes.Enabled = false;
                    btnSave.Enabled = false;
                    btnSave.Text = "";
                    btnEdit.Text = "SALVAR";

                    tbCpf.Text = dgvClientes.SelectedRows[0].Cells[0].Value.ToString();
                    tbName.Text = dgvClientes.SelectedRows[0].Cells[1].Value.ToString();
                    tbNumber.Text = dgvClientes.SelectedRows[0].Cells[2].Value.ToString();
                    tbStreet.Text = dgvClientes.SelectedRows[0].Cells[3].Value.ToString();
                    tbBairro.Text = dgvClientes.SelectedRows[0].Cells[4].Value.ToString();
                    tbStNumber.Text = dgvClientes.SelectedRows[0].Cells[5].Value.ToString();
                    rtbReference.Text = dgvClientes.SelectedRows[0].Cells[6].Value.ToString();
                }

                ableToEdit++;

                if (ableToEdit > 1)
                {
                    await Update();

                    dgvClientes.Enabled = true;
                    btnSave.Enabled = true;
                    btnBack.Enabled = true;
                    btnSave.Text = "Salvar Novo Cliente";
                    btnEdit.Text = "Editar";

                    tbCpf.Clear();
                    tbName.Clear();
                    tbNumber.Clear();
                    tbStreet.Clear();
                    tbBairro.Clear();
                    tbStNumber.Clear();
                    rtbReference.Clear();

                    ableToEdit = 0;
                }
            }
            else
                AutoClosingMessageBox.Show("Selecione uma linha para editar", "ERRO", 2000);
        }
        private async new Task Update()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    Cliente newClient = new Cliente
                    {
                        Cpf = tbCpf.Text.Trim(),
                        Nome = tbName.Text.Trim().ToUpper(),
                        Tel = tbNumber.Text.Trim(),
                        Rua = tbStreet.Text.Trim(),
                        Bairro = tbBairro.Text.Trim().ToUpper(),
                        Num_residencia = Convert.ToInt32(tbStNumber.Text.Trim()),
                        Referencia = rtbReference.Text.Trim().ToUpper()
                    };

                    db.Cliente.Update(newClient);
                    await db.SaveChangesAsync();
                    await FillGrid();
                }
                AutoClosingMessageBox.Show("Dados atualizados com sucesso!", "SUCESSO", 500);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Update -> Clients\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatColumns()
        {
            try
            {
                dgvClientes.Columns[3].Visible = false;
                dgvClientes.Columns[5].Visible = false;
                dgvClientes.Columns[6].Visible = false;

                dgvClientes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvClientes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvClientes.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvClientes.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvClientes.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvClientes.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvClientes.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvClientes.Columns[0].HeaderText = "CPF";
                dgvClientes.Columns[1].HeaderText = "Nome";
                dgvClientes.Columns[2].HeaderText = "Telefone";
                dgvClientes.Columns[3].HeaderText = "Rua";
                dgvClientes.Columns[4].HeaderText = "Bairro";
                dgvClientes.Columns[5].HeaderText = "Nº";
                dgvClientes.Columns[6].HeaderText = "Referência";

                for (int i = 0; i < dgvClientes.RowCount; i++)
                    if (i % 2 == 0)
                        dgvClientes.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                    else
                        dgvClientes.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;

                dgvClientes.ClearSelection();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função FormatColumns -> Clients\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task FillGrid()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    dgvClientes.DataSource = await db.Cliente.ToListAsync();
                    FormatColumns();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função FillGrid -> Clients\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task Insert()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    Cliente newClient = new Cliente
                    {
                        Cpf = tbCpf.Text.Trim(),
                        Nome = tbName.Text.Trim().ToUpper(),
                        Tel = tbNumber.Text.Trim(),
                        Rua = tbStreet.Text.Trim(),
                        Bairro = tbBairro.Text.Trim().ToUpper(),
                        Num_residencia = Convert.ToInt32(tbStNumber.Text.Trim()),
                        Referencia = rtbReference.Text.Trim().ToUpper()
                    };

                    db.Cliente.Add(newClient);

                    await db.SaveChangesAsync();
                    await FillGrid();

                    AutoClosingMessageBox.Show("Dados salvos com sucesso!", "Sucesso", 500);
                    tbName.Focus();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Insert -> Clients\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<List<Cliente>> GetClientsByCPF(string cpf)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    return await db.Cliente.Where(x => x.Cpf == cpf).ToListAsync();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função GetClientsByCPF -> Clients\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private async Task Delete()
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Deseja realmente excluir esse registro?", "Excluindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    var clients = await GetClientsByCPF(cpf);

                    using (var db = new ApplicationDbContext())
                    {
                        if (clients != null)
                        {
                            if (clients.Count <= 0)
                            {
                                db.Cliente.Remove(db.Cliente.Find(cpf));
                            }
                            else if (clients.Count > 0 && DialogResult.Yes == MessageBox.Show("Há " + clients.Count + " vendas cadastradas para este cliente. Deseja realmente remover o cliente e todos seus registros de venda?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                clients.ForEach(client => db.Venda.RemoveRange(db.Venda.Where(x => x.Id_Cliente == client.Cpf)));
                                db.Cliente.Remove(db.Cliente.Find(cpf));
                            }

                            await db.SaveChangesAsync();
                            await FillGrid();

                            AutoClosingMessageBox.Show("Dados deletados com sucesso", "Sucesso", 500);
                        }
                    }

                    Database.CloseConnection();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função Delete -> Clients\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Database.CloseConnection();
            }
        }
        private async void Clients_Load(object sender, EventArgs e)
        {
            animOpen.Start();
            await FillGrid();
        }
        private void RbCPF_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCPF.Checked)
            {
                tbSearch.TextAlign = HorizontalAlignment.Left;
                tbSearch.Text = string.Empty;
                tbSearch.ForeColor = Color.Black;
                tbSearch.Enabled = true;
                tbSearch.Focus();
            }
        }
        private void RbName_CheckedChanged(object sender, EventArgs e)
        {
            if (rbName.Checked)
            {
                tbSearch.TextAlign = HorizontalAlignment.Left;
                tbSearch.Text = string.Empty;
                tbSearch.ForeColor = Color.Black;
                tbSearch.Enabled = true;
                tbSearch.Focus();
            }
        }
        private async void TbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                if (rbCPF.Checked)
                {
                    try
                    {
                        dgvClientes.DataSource = await (from i in db.Cliente where EF.Functions.Like(i.Cpf, $"%{tbSearch.Text.Trim()}%") select i).ToListAsync();
                        FormatColumns();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro no evento Search(CPF) -> Clients\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (rbName.Checked)
                {
                    try
                    {

                        dgvClientes.DataSource = await (from i in db.Cliente where EF.Functions.Like(i.Nome, $"%{tbSearch.Text.Trim()}%") select i).ToListAsync();
                        FormatColumns();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro no evento Search(Nome) -> Clients\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (rbTel.Checked)
                {
                    try
                    {
                        dgvClientes.DataSource = await (from i in db.Cliente where EF.Functions.Like(i.Tel, $"%{tbSearch.Text.Trim()}%") select i).ToListAsync();
                        FormatColumns();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro no evento Search(Telefone) -> Clients\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void PbGenerate_Click(object sender, EventArgs e)
        {
            tbCpf.Text = GerarCpf();
        }
        private void AnimGone_Tick(object sender, EventArgs e)
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
        private void AnimOpen_Tick(object sender, EventArgs e)
        {
            if (animGone.Enabled)
                animGone.Stop();

            if (Opacity < 1)
                Opacity += 0.1;
            else
                animOpen.Stop();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                btnBack.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DgvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja abrir um pedido para o cliente selecionado?", "Abrindo pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Shortcut shortcut = new Shortcut()
                {
                    cpf = dgvClientes.SelectedRows[0].Cells[0].Value.ToString(),
                    nomeCliente = dgvClientes.SelectedRows[0].Cells[1].Value.ToString(),
                    telefone = dgvClientes.SelectedRows[0].Cells[2].Value.ToString(),
                    rua = dgvClientes.SelectedRows[0].Cells[3].Value.ToString(),
                    bairro = dgvClientes.SelectedRows[0].Cells[4].Value.ToString(),
                    number = dgvClientes.SelectedRows[0].Cells[5].Value.ToString(),
                    referencia = dgvClientes.SelectedRows[0].Cells[6].Value.ToString(),
                };

                VendasForm venda = new VendasForm(shortcut, true);

                Hide();
                venda.ShowDialog();
                Close();
            }
        }

        private void rbTel_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTel.Checked)
            {
                tbSearch.TextAlign = HorizontalAlignment.Left;
                tbSearch.Text = string.Empty;
                tbSearch.ForeColor = Color.Black;
                tbSearch.Enabled = true;
                tbSearch.Focus();
            }
        }
    }
}