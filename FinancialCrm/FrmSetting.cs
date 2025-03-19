using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmSetting : Form
    {
        public FrmSetting()
        {
            InitializeComponent();
        }
        double value = 0;
        string operation = "";
        bool operation_pressed = false;
        private void button_Click(object sender, EventArgs e)
        {
            if ((txtResult.Text == "0") || (operation_pressed))
                txtResult.Clear();
            Button b = (Button)sender;
            txtResult.Text = txtResult.Text + b.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            value = double.Parse(txtResult.Text);
            operation_pressed = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    txtResult.Text = (value + double.Parse(txtResult.Text)).ToString();
                    break;

                case "-":
                    txtResult.Text = (value - double.Parse(txtResult.Text)).ToString();
                    break;

                case "/":
                    txtResult.Text = (value / double.Parse(txtResult.Text)).ToString();
                    break;

                case "*":
                    txtResult.Text = (value * double.Parse(txtResult.Text)).ToString();
                    break;
            }//end
            operation_pressed = false;

        }

        private void button18_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            value = 0;
        }
    }
}
