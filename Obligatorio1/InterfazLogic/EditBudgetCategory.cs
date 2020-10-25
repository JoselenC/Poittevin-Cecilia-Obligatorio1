using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace InterfazLogic
{
    public partial class EditBudgetCategory : Form
    {
        private BudgetCategory currentBudgetCategory { get; set; }
        private AddAndEditBudget originForm { get; set; }
        public EditBudgetCategory(BudgetCategory budgetCategory, AddAndEditBudget vOriginForm)
        {
            InitializeComponent();
            originForm = vOriginForm;
            currentBudgetCategory = budgetCategory;
            numericAmount.Value = (decimal) budgetCategory.Amount;
            this.MaximumSize = new Size(380, 200);
            this.MinimumSize = new Size(380, 200);
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            currentBudgetCategory.Amount = (double)numericAmount.Value;
            originForm.Refresh();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
