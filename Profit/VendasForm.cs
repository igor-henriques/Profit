using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Data.SQLite;
using Org.BouncyCastle.Cms;
using Microsoft.EntityFrameworkCore;
using Profit.Data;
using Profit.Models;
using Profit.Models.Db;
using System.Linq;
using Profit.Models.Db.Enums;

namespace Profit
{
    public partial class VendasForm : Form
    {
        Shortcut shortCut;
        MainForm main;
        Quantify quantify = new Quantify();
        Cliente curClient;

        decimal lucro, total;
        Pagamento formaPagamento = 0;
        private bool autofill;

        #region DESIGN_INFO
        private Point lastLocation;
        private bool mouseDown;

        Size openedForm = new Size(570, 697);
        Point _btnPedido = new Point(0, 582);
        Point _deliveryBox = new Point(7, 362);
        Point _btnBack = new Point(0, 655);

        Size closedForm = new Size(570, 483);
        Point btnPedido = new Point(0, 365);
        Point btnBack = new Point(0, 439);
        Point deliveryBox = new Point(7, 166);
        #endregion

        public VendasForm(Shortcut shortcut, bool autoFill)
        {
            InitializeComponent();
            AuthenticationForm auth = new AuthenticationForm();
            shortCut = shortcut;
            autofill = autoFill;
            main = new MainForm(auth.key, auth.hwid, 4);
        }
        private void DeliveryBox()
        {
            if (cbDelivery.Checked)
            {
                Size = openedForm;
                btnConfirm.Location = _btnPedido;
                btnClose.Location = _btnBack;
                gbDelivery.Location = _deliveryBox;
                gbDelivery.Visible = true;
                gbDelivery.Enabled = true;
                CenterToScreen();
                tbNomeCliente.Focus();
            }
            else
            {
                gbDelivery.Visible = false;
                gbDelivery.Enabled = false;
                gbDelivery.Location = deliveryBox;
                btnConfirm.Location = btnPedido;
                btnClose.Location = btnBack;
                Size = closedForm;
                CenterToScreen();
            }
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbPedido.SelectedIndex > -1)
                {
                    decimal total = 0;
                    int index = lbPedido.SelectedIndex;
                    lbPedido.Items.RemoveAt(index);

                    if (lbPedido.Items.Count > 0)
                    {
                        for (int i = 0; i < lbPedido.Items.Count; i++)
                        {
                            if (lbPedido.Items[i].ToString().Contains("*"))
                            {
                                var lines = File.ReadAllLines(@"Dados\Temporario\OrderN" + i + ".txt");
                                decimal taxa = 0, desconto = 0;

                                for (int k = 0; k < lines.Length; k++)
                                {
                                    if (lines[k].Contains("taxa:"))
                                    {
                                        taxa = Convert.ToDecimal(lines[k].Replace("taxa:", "").Replace("R$ ", "").Trim());
                                    }
                                    else if (lines[k].Contains("desconto:"))
                                    {
                                        if (lines[k].Contains("R$"))
                                        {
                                            desconto = Convert.ToDecimal(lines[k].Replace("desconto:", "").Replace("R$ ", "").Trim());
                                        }
                                    }
                                }

                                total += GetPrice(lbPedido.Items[i].ToString()) + taxa + desconto;
                            }
                            else
                            {
                                total += GetPrice(lbPedido.Items[i].ToString());
                            }
                        }
                    }

                    lblPrice.Text = total.ToString("c");
                }
                else
                {
                    AutoClosingMessageBox.Show("Não há linha selecionada na lista!", "ERRO", 2000, MessageBoxButtons.OK);
                }
            }
            catch (Exception f)
            {
                AutoClosingMessageBox.Show("Erro no evento btnExcluir -> Vendas\n" + f.Message, "ERRO", 2000);
            }
        }
        private void BtnClean_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja limpar a lista de pedido?", "Limpando...", MessageBoxButtons.YesNo))
            {
                lbPedido.Items.Clear();
                lblPrice.Text = 0.ToString("c");
            }
        }
        private async void Vendas_Load(object sender, EventArgs e)
        {
            await Task.Run(() => LoadProducts());

            if (autofill)
            {
                btnDelivery.PerformClick();

                tbNomeCliente.Text = shortCut.nomeCliente;
                tbNumber.Text = shortCut.telefone;
                tbAddress.Text = shortCut.rua;
                tbStNumber.Text = shortCut.number;
                tbReference.Text = shortCut.referencia;
                tbBairro.Text = shortCut.bairro;
            }
        }
        private async Task LoadProducts()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    AutoCompleteStringCollection dadosLista = new AutoCompleteStringCollection();
                    List<Produto> produtos = await db.Produto.ToListAsync();

                    produtos.ForEach(produto => dadosLista.Add(produto.Name));

                    BeginInvoke((MethodInvoker)delegate
                    {
                        comboBox.DataSource = produtos.Select(x => x.Name).ToList();
                        comboBox.AutoCompleteCustomSource = dadosLista;
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função LoadProducts -> \n" + e.Message, "ERRO");
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex >= 0)
            {
                try
                {
                    total = 0;
                    quantify.ShowDialog();

                    for (int i = 0; i < lbPedido.Items.Count; i++)
                    {
                        if (lbPedido.Items[i].ToString().Contains("*"))
                        {
                            var lines = File.ReadAllLines(@"Dados\Temporario\OrderN" + i + ".txt");
                            decimal taxa = 0, desconto = 0;

                            for (int k = 0; k < lines.Length; k++)
                            {
                                if (lines[k].Contains("taxa:"))
                                {
                                    taxa = Convert.ToDecimal(lines[k].Replace("taxa:", "").Replace("R$ ", "").Trim());
                                }
                                else if (lines[k].Contains("desconto:"))
                                {
                                    if (lines[k].Contains("R$"))
                                    {
                                        desconto = Convert.ToDecimal(lines[k].Replace("desconto:", "").Replace("R$ ", "").Trim());
                                    }
                                }
                            }

                            total += GetPrice(lbPedido.Items[i].ToString()) + taxa + desconto;
                        }
                        else
                        {
                            total += GetPrice(lbPedido.Items[i].ToString());
                        }
                    }

                    for (int i = 0; i < quantify.quantidadeUtilizada; i++)
                    {
                        lbPedido.Items.Add(comboBox.SelectedItem.ToString());
                        lucro += GetProfit(comboBox.SelectedItem.ToString());
                        total += GetPrice(comboBox.SelectedItem.ToString());
                    }

                    lbPedido.SelectedIndex = lbPedido.Items.Count - 1;

                    lblPrice.Text = total.ToString("c");
                }
                catch (Exception g)
                {
                    MessageBox.Show("Erro no evento btnAdd -> Vendas\n" + g.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private decimal GetPrice(string productName)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Produto.Where(x => x.Name == productName.Replace("*", default)).FirstOrDefault().Price;
            }
        }
        private decimal GetProfit(string productName)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Produto.Where(x => x.Name == productName.Replace("*", default)).FirstOrDefault().Profit;
            }
        }
        private void RbCard_CheckedChanged(object sender, EventArgs e)
        {
            tbTroco.Text = string.Empty;
            tbTroco.Enabled = false;
            tbTroco.BackColor = Color.LightGray;
            tbTotalRecebido.Text = string.Empty;
            tbTotalRecebido.Enabled = false;
            tbTotalRecebido.BackColor = Color.LightGray;

            formaPagamento = Pagamento.Cartao;
        }
        private void RbDinheiro_CheckedChanged(object sender, EventArgs e)
        {
            tbTroco.Enabled = true;
            tbTroco.BackColor = Color.WhiteSmoke;
            tbTotalRecebido.Enabled = true;
            tbTotalRecebido.BackColor = Color.WhiteSmoke;

            formaPagamento = Pagamento.Dinheiro;
        }
        private void ComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd.PerformClick();
        }
        private async void TbNomeCliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    AutoCompleteStringCollection dadosCliente = new AutoCompleteStringCollection();

                    var search = await (from i in db.Cliente where EF.Functions.Like(i.Nome, $"%{tbNomeCliente.Text.Trim()}%") select i).Where(x => x != null).ToListAsync();

                    search.ForEach(client => dadosCliente.Add(client.Nome));

                    tbNomeCliente.AutoCompleteCustomSource = dadosCliente;
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("Erro no evento NomeClienteKeyUp -> Vendas\n" + f.Message, "ERRO");
            }
        }
        private void TbNomeCliente_Leave(object sender, EventArgs e)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var client = db.Cliente.Where(x => x.Nome == tbNomeCliente.Text).FirstOrDefault();

                    if (client != null)
                    {
                        tbNumber.Text = client.Tel;
                        tbAddress.Text = client.Rua;
                        tbBairro.Text = client.Bairro;
                        tbStNumber.Text = client.Num_residencia.ToString();
                        tbReference.Text = client.Referencia;

                        curClient = client;
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("Erro no evento NomeClienteLeave -> Vendas\n" + f.Message, "ERRO");
            }
        }
        private void Label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
        }
        private void Label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }
        private void Label3_Click(object sender, EventArgs e)
        {
            GetTextboxes().ForEach(control => control.Text = default);
        }
        private List<Control> GetTextboxes() => new List<Control> { tbNomeCliente, tbAddress, tbStNumber, tbTotalRecebido, tbReference, tbBairro, tbTroco, tbNumber };

        private void TbTotalRecebido_Leave(object sender, EventArgs e)
        {
            if (tbTotalRecebido.Text.Trim() != string.Empty)
            {
                decimal totalPreço = Convert.ToDecimal(lblPrice.Text.Replace("R$", "").Trim());
                decimal totalRecebido = Convert.ToDecimal(tbTotalRecebido.Text);

                tbTroco.Text = (totalRecebido - totalPreço).ToString("c");
                tbTotalRecebido.Text = Convert.ToDecimal(tbTotalRecebido.Text).ToString("c");
            }
        }
        private void TbTotalRecebido_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            decimal x;

            if (ch == (char)Keys.Back)
                e.Handled = false;
            else if (!char.IsDigit(ch) && ch != ',' || !Decimal.TryParse(tbTotalRecebido.Text + ch, out x))
                e.Handled = true;
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            animGone.Start();
        }
        private decimal ConvertText(string text) => Convert.ToDecimal(text.Replace("R$", "").Trim());
        
        private void BtnObs_Click(object sender, EventArgs e)
        {
            if (lbPedido.SelectedIndex >= 0)
            {
                ObservationsForm obs = new ObservationsForm(lbPedido.SelectedItem.ToString(), lbPedido.SelectedIndex);
                Opacity = 0;
                Hide();
                obs.ShowDialog();
                Show();
                animOpen.Start();
                lucro += obs.sum;

                if (tbTroco.Text != string.Empty)
                {
                    tbTroco.Text = (ConvertText(lblPrice.Text) - ConvertText(tbTotalRecebido.Text)).ToString("c");
                }

                lblPrice.Text = total.ToString("c");

                if (obs.desconto != 0 || obs.taxa != 0)
                {
                    lblPrice.Text = (ConvertText(lblPrice.Text) + obs.desconto + obs.taxa).ToString("c");

                    if (obs.desconto != 0 && obs.taxa != 0)
                        toolTip1.SetToolTip(lblPrice, "Valor de taxa: " + obs.taxa.ToString("c"));
                    else if (obs.desconto != 0)
                        toolTip1.SetToolTip(lblPrice, "Valor de desconto: " + obs.desconto.ToString("c"));
                    else if (obs.taxa != 0)
                        toolTip1.SetToolTip(lblPrice, "Valor de desconto: " + obs.desconto.ToString("c") + "\nValor de taxa: " + obs.taxa.ToString("c"));
                }

                if (obs.houveAlteracao)
                {
                    lbPedido.Items[lbPedido.SelectedIndex] = lbPedido.SelectedItem + "*";
                }
                else if (!obs.houveAlteracao)
                {
                    lbPedido.Items[lbPedido.SelectedIndex] = lbPedido.SelectedItem.ToString().Replace("*", "");
                }
            }
            else
                MessageBox.Show("Selecione uma linha na lista para adicionar observações!", "ERRO");
        }
        private void AnimGone_Tick(object sender, EventArgs e)
        {
            if (animOpen.Enabled)
                animOpen.Stop();

            if (Opacity > 0)
            {
                Opacity -= 0.125;
            }
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
                btnClose.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D))
            {
                btnDelivery.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Enter))
            {
                btnConfirm.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.O))
            {
                btnObs.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.A))
            {
                btnAdd.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Delete))
            {
                btnExcluir.PerformClick();
                return true;
            }
            else if (keyData == ((Keys.Shift | Keys.LShiftKey) | Keys.Delete))
            {
                btnClean.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Tab) && tbNomeCliente.Focused)
            {
                tbTotalRecebido.Focus();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D1))
            {
                lbPedido.SelectedIndex = 0;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D2))
            {
                lbPedido.SelectedIndex = 1;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D3))
            {
                lbPedido.SelectedIndex = 2;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D4))
            {
                lbPedido.SelectedIndex = 3;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D5))
            {
                lbPedido.SelectedIndex = 4;
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D9))
            {
                lbPedido.SelectedIndex = lbPedido.Items.Count - 1;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }      
        private int GetIdByProductName(string productName)
        {
            using (var db = new ApplicationDbContext())
            {
                var response = db.Produto.Include(z => z.Receita).Where(x => x.Name == productName.Replace("*", default)).FirstOrDefault().Id_Receita;
                return response;
            }
        }
        private Produto GetProductByName(string productName)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Produto.Where(x => x.Name == productName.Replace("*", "")).FirstOrDefault();
            }
        }
        private decimal GetTotalCost()
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    decimal fullCost = 0;

                    foreach (var item in lbPedido.Items)
                    {
                        var recipe = db.Receita.Where(x => x.Id == GetIdByProductName(item.ToString())).FirstOrDefault();

                        if (recipe != null)
                            fullCost += recipe.Cost;
                    }

                    return fullCost;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Erro na função GetTotalCost -> Vendas\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private async Task<Venda> InsertSale(decimal taxa, decimal desconto, Modalidade modalidade, decimal total, decimal troco, decimal lucro, string obs, Pagamento forma)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {                    
                    Venda newSale = new Venda
                    {             
                        Id_Cliente = curClient is null ? "0" : curClient.Cpf,
                        Cliente = curClient,
                        Name = tbNomeCliente.Text.ToUpper().Trim(),
                        Data = DateTime.Now.Date,
                        Taxa = taxa,
                        Desconto = desconto,
                        Modalidade = modalidade,
                        Total = total + taxa,
                        Troco = troco,
                        Lucro = lucro,
                        Observation = obs,
                        Forma = forma,
                        Gasto = GetTotalCost() + desconto,
                        Hora = DateTime.Now,
                        Status = Status.Pendente
                    };

                    db.Venda.Add(newSale);
                    await db.SaveChangesAsync();

                    return newSale;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função InsertSale -> Vendas\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private async Task InsertProductsToSale(Venda venda, Produto produto)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    Produto insertProduct = db.Produto.Where(x => x.Id == produto.Id).FirstOrDefault();
                    Venda insertSelling = db.Venda.Where(x => x.Id == venda.Id).FirstOrDefault();

                    Venda_Produto newProductSale = new Venda_Produto
                    {
                        Id_Produto = insertProduct.Id,
                        Produto = insertProduct,
                        Nome_Produto = insertProduct.Name,
                        Venda = insertSelling,
                        Id_Venda = insertSelling.Id
                    };

                    db.Venda_Produto.Add(newProductSale);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função InsertProductsToSale -> Vendas\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void BtnConfirm_Click(object sender, EventArgs e)
        {
            decimal taxa = 0, desconto = 0;
            string observacao = rtbObservations.Text.Trim().ToUpper();

            try
            {
                for (int i = 0; i < lbPedido.Items.Count; i++)
                {
                    if (lbPedido.Items[i].ToString().Contains("*"))
                    {
                        try
                        {
                            var lines = File.ReadAllLines(@"Dados\Temporario\OrderN" + i + ".txt");

                            for (int k = 0; k < lines.Length; k++)
                            {
                                if (lines[k].Contains("taxa:"))
                                {
                                    taxa = Convert.ToDecimal(lines[k].Replace("taxa:", "").Replace("R$ ", "").Trim());
                                }
                                else if (lines[k].Contains("desconto:"))
                                {
                                    if (lines[k].Contains("R$"))
                                    {
                                        desconto = Convert.ToDecimal(lines[k].Replace("desconto:", "").Replace("R$ ", "").Trim());
                                    }
                                }
                            }
                        }
                        catch (Exception f)
                        {
                            MessageBox.Show("Erro no 1º estágio do evento btnConfirm -> Vendas\n" + f.Message, "ERRO", MessageBoxButtons.OK);
                        }
                    }
                }

                if (lbPedido.Items.Count > 0)
                {
                    if (cbDelivery.Checked)
                    {
                        if (rbDinheiro.Checked || rbCard.Checked)
                        {
                            if ((rbDinheiro.Checked && tbTotalRecebido.Text != string.Empty) || rbCard.Checked)
                            {
                                Venda venda = await InsertSale(taxa, desconto, Modalidade.Delivery, total, tbTroco.Text.Length > 0 ? Convert.ToDecimal(tbTroco.Text.Replace("R$", "").Trim()) : 0, lucro, observacao, formaPagamento);

                                foreach (var item in lbPedido.Items)
                                {
                                    await InsertProductsToSale(venda, GetProductByName(item.ToString()));
                                }

                                Close();
                            }
                            else
                            {
                                AutoClosingMessageBox.Show("Preencha o valor que será recebido pelo cliente no momento da entrega!", "ERRO", 2000);
                            }
                        }
                        else
                        {
                            AutoClosingMessageBox.Show("Por favor, marque a forma de pagamento!", "ERRO", 2000);
                        }
                    }
                    else
                    {
                        Venda venda = await InsertSale(taxa, desconto, Modalidade.Mesa, total, tbTroco.Text.Length > 0 ? Convert.ToDecimal(tbTroco.Text.Replace("R$", "").Trim()) : 0, lucro, observacao, formaPagamento);

                        foreach (var item in lbPedido.Items)
                        {
                            await InsertProductsToSale(venda, GetProductByName(item.ToString()));
                        }

                        DirectoryInfo di = new DirectoryInfo(@"Dados\Temporario");

                        foreach (FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }

                        Close();
                    }
                }
                else
                {
                    AutoClosingMessageBox.Show("Por favor, selecione algum produto antes de finalizar!", "ERRO", 2000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no 2º estágio do evento BtnConfirm -> Vendas\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnDelivery_Click(object sender, EventArgs e)
        {
            cbDelivery.Checked = cbDelivery.Checked ? false : true;

            DeliveryBox();
        }
        #region FormMovement
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion
    }
}