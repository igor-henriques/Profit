using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Profit
{
    public partial class DetalhesForm : Form
    {
        int pedidoId;
        string currentPath = string.Empty;
        List<string> currentOrder;

        string data, modalidade, cliente, total, lucro, desconto, taxa, telefone, endereco, numResidencia, bairro, referencia, conteudo, observacao, troco, forma, custoTotal, hora;        

        public DetalhesForm(int id, string data, string modalidade, string cliente, string total, string lucro, string desconto, string taxa, string telefone, string endereco, string numResidencia, string bairro, string referencia, string conteudo, string observacao, string troco, string forma, string custoTotal, string hora)
        {
            InitializeComponent();
            pedidoId = id;
            this.data = data; this.modalidade = modalidade; this.cliente = cliente; this.total = total; this.lucro = lucro; this.desconto = desconto; this.taxa = taxa; this.telefone = telefone; this.endereco = endereco; this.numResidencia = numResidencia; this.bairro = bairro; this.referencia = referencia; this.conteudo = conteudo; this.observacao = observacao; this.troco = troco; this.forma = forma; this.custoTotal = custoTotal; this.hora = hora;            
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
        private async void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            try
            {               
                var printConfig = File.ReadAllText(Directory.GetCurrentDirectory() + @"\printconfig").Split(',');
                StringBuilder sb = new StringBuilder();

                sb.Append("• CLIENTE: " + cliente + "\n");
                sb.Append("• HORA: " + hora + "\n");
                sb.Append("• TELEFONE: " + telefone + "\n");
                sb.Append("• ENDEREÇO: " + endereco + "\n");
                sb.Append("• NÚMERO: " + numResidencia + "\n");
                sb.Append("• BAIRRO: " + bairro + "\n");
                sb.Append("• REFERÊNCIA: " + referencia + "\n");
                sb.Append("• OBSERVAÇÃO: " + observacao + "\n");
                sb.Append("• TOTAL: " + Convert.ToDouble(total).ToString("c") + "\n");
                sb.Append("• TROCO: " + Convert.ToDouble(troco).ToString("c") + "\n");
                sb.Append("• FORMA: " + forma);

                Font drawFont = new Font("Arial", Convert.ToInt32(printConfig[4]));
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                float x = (float)Convert.ToDouble(printConfig[0]);
                float y = (float)Convert.ToDouble(printConfig[1]);
                float width = (float)Convert.ToDouble(printConfig[2]);
                float height = (float)Convert.ToDouble(printConfig[3]);
                RectangleF drawRect = new RectangleF(x, y, width, height);

                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;

                ev.Graphics.DrawString(sb.ToString(), drawFont, drawBrush, drawRect, drawFormat);                
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro no evento Print -> Detalhes\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public void Printing()
        {
            try
            {                                                              
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                pd.Print();                                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na função Printing -> Detalhes\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Detalhes_Load(object sender, EventArgs e)
        {
            tbPedido.Text = pedidoId.ToString();

            try
            {
                tbBairro.Text = bairro;
                tbCliente.Text = cliente;
                tbDesconto.Text = Convert.ToDouble(desconto).ToString("c"); ;
                tbEndereco.Text = endereco;
                tbData.Text = data;
                tbHora.Text = hora;
                tbLucro.Text = Convert.ToDouble(lucro).ToString("c"); ;
                tbModalidade.Text = modalidade;
                tbPedido.Text = pedidoId.ToString();
                tbReferencia.Text = referencia;
                tbResidencia.Text = numResidencia;
                tbTaxa.Text = Convert.ToDouble(taxa).ToString("c");
                tbTelefone.Text = telefone;
                tbTotal.Text = Convert.ToDouble(total).ToString("c");
                rtbConteudo.Text = conteudo;
                tbObservation.Text = observacao;
                tbGasto.Text = custoTotal.ToString();

                btnConfirm.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no evento Load -> Detalhes\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AnimOpen_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1)
                Opacity += 0.15;
            else
                animOpen.Stop();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Task.Run(() => Printing());
        }
    }
}
