using PicPay;
using PicPay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Profit
{
    public partial class PicPayForm : Form
    {
        PicPayClient PP = new PicPayClient("870dd39a-ae0e-43e0-99b0-16a740f64a80");
        public PicPayForm()
        {
            InitializeComponent();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            RequestPayment();
        }
        async void RequestPayment()
        {
            PaymentRequest body = new PaymentRequest
            {
                ReferenceId = "102031",
                CallbackUrl = "https://localhost:44377/profit/",
                ReturnUrl = "https://localhost:44377/profit/",
                Value = 0.1,
                Buyer = new Buyer
                {
                    FirstName = "Igor",
                    LastName = "Henriques",
                    Document = "06162747778",
                    Email = "henriquesigor@yahoo.com.br",
                    Phone = "+55 28 999218073"
                }
            };

            var result = await PP.Payment.Create(body);
        }
        async void RequestStatus()
        {
            using (var client = new System.Net.WebClient())
            {
                //client.UploadData(address, "PUT", data);
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            RequestStatus();
        }
    }    
}
