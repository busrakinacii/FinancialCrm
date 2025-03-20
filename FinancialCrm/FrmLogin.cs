using FinancialCrm.Models;
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var query = from x in db.Users where x.UserName == txtUserName.Text && x.UserPassword == txtPassword.Text select x;
            if (query.Any())
            {
                MessageBox.Show("Giriş Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmDashboard fr = new FrmDashboard();
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Giriş HATALI!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
