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
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmCategories_Load(object sender, EventArgs e)
        {
            var categoryList = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName,
            }).ToList();
            dataGridView1.DataSource = categoryList;
        }

        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            //Category List Process
            //
            var categoryList = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName,
            }).ToList();
            dataGridView1.DataSource = categoryList;
        }
    }
}
