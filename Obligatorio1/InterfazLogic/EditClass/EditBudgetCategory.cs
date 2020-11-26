using BusinessLogic;
using System;
using System.Drawing;
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
            MaximumSize = new Size(380, 200);
            MinimumSize = new Size(380, 200);
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            currentBudgetCategory.Amount = (double)numericAmount.Value;
            originForm.Refresh();
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
