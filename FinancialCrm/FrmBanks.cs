﻿using System;
using System.Linq;
using System.Windows.Forms;
using FinancialCrm.Models;


namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            //Banka Bakiyeleri

            var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var isBankBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var vakifBankBalance = db.Banks.Where(x => x.BankTitle == "Vakıf Bankası").Select(y => y.BankBalance).FirstOrDefault();

            lblZiraatBankBalance.Text = ziraatBankBalance.ToString() + " ₺";
            lblIsBankBalance.Text = isBankBalance.ToString() + " ₺";
            lblVakifBankBalance.Text = vakifBankBalance.ToString() + " ₺";

            //Banka Hareketleri

            var bankProcess1 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Take(1).FirstOrDefault();

            lblBankProcess1.Text = bankProcess1.Description + " / " + bankProcess1.Amount + " ₺ / " + bankProcess1.ProcessDate;
            //***********************************************
            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Skip(1).FirstOrDefault();

            lblBankProcess2.Text = bankProcess2.Description + " / " + bankProcess2.Amount + " ₺ / " + bankProcess2.ProcessDate;
            //***********************************************

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Skip(2).FirstOrDefault();

            lblBankProcess3.Text = bankProcess3.Description + " / " + bankProcess3.Amount + " ₺ / " + bankProcess3.ProcessDate;
            //***********************************************

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Skip(3).FirstOrDefault();

            lblBankProcess4.Text = bankProcess4.Description + " / " + bankProcess4.Amount + " ₺ / " + bankProcess4.ProcessDate;
            //***********************************************

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Skip(4).FirstOrDefault();

            lblBankProcess5.Text = bankProcess5.Description + " / " + bankProcess5.Amount + " ₺ / " + bankProcess5.ProcessDate;
            //***********************************************
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.Show();
        }
        private void btnBill_Click(object sender, EventArgs e)
        {
            FrmBilling fr = new FrmBilling();
            fr.Show();
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard fr = new FrmDashboard();
            fr.Show();
        }

        private void btnBankForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
        }

        private void btnSpending_Click(object sender, EventArgs e)
        {
            FrmSpendings fr = new FrmSpendings();
            fr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmSetting frm = new FrmSetting();
            frm.Show();
        }
    }
}
