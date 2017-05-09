using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// An unhandled exceptions in wcf service, will cause the communication channel to fault and the session will be lost
// We cannot use the same instance of the proxy class anymore.
// BasicHttpBinding - When there is an unhandled exception, it only fault the server channel. The client proxy is still OK. Because BasicHttpBinding the channel is not maintaining sessions.
// wsHttpBinding - When there is an unhandled exception, it fault the server channel and client proxy also. Because wsHttpBinding the channel is maintaining secure session.

namespace CalculatorWinClient
{
    public partial class Form1 : Form
    {
        CalculatorService.CalculatorServiceClient _client;
        public Form1()
        {
            InitializeComponent();
            _client = new CalculatorService.CalculatorServiceClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int numerator = Convert.ToInt32(txtNumerator.Text);
                int denominator = Convert.ToInt32(txtDenominator.Text);
                lblStatus.Text = _client.Devide(numerator, denominator).ToString();
            }
            catch (FaultException ex)
            {
                lblStatus.Text = ex.Code.Name + ": " + ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _client = new CalculatorService.CalculatorServiceClient();
        }
    }
}
