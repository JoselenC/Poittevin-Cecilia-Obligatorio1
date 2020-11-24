using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Repository;

namespace InterfazLogic
{
    public partial class RegisterExpense : UserControl
    {
        private ExpenseController expenseController;
        public RegisterExpense(IManageRepository vRepository)
        {
            InitializeComponent();
            expenseController = new ExpenseController(vRepository);
            MaximumSize = new Size(890, 890);
            MinimumSize = new Size(890, 890);
            tbDescription.Clear();
            lstCategories.Items.Clear();
            AreCategories();
            Completecurrency();
            lstcurrency.SelectedIndex = 0;
        }

        private void AreCategories()
        {
            if(expenseController.GetCategories().Count == 0)
            {
                MessageBox.Show("There are no categories registered in the system");
                Visible = false;
            }
        }
        private void CompleteCategories(string description)
        {            
            try
            {
                Category category = expenseController.FindCategoryByDescription(description);
                lstCategories.Items.Add(category);
            }
            catch (NoAsignCategoryByDescriptionExpense)
            {
                foreach (Category vCategory in expenseController.GetCategories())
                {
                    lstCategories.Items.Add(vCategory);
                }
            }
        }

        private void SetMessage(string messsage, Label lblToSetMessage)
        {
            if (lblToSetMessage != lblAmount)
                lblAmount.Text = "";
            if (lblToSetMessage != lblCategories)
                lblCategories.Text = "";
            if (lblToSetMessage != lblDate)
                lblDate.Text = ""; 
            lblToSetMessage.Text = messsage;
            lblToSetMessage.ForeColor = Color.Red;
        }

        private void Completecurrency()
        {
            foreach (Currency vcurrency in expenseController.GetCurrencies())
            {
                lstcurrency.Items.Add(vcurrency);
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            lstCategories.Items.Clear();
            string description = tbDescription.Text;
            CompleteCategories(description);
        }

        private void TryRegisterExpense()
        {
            if (lstCategories.SelectedIndex >= 0)
            {
                string description = tbDescription.Text;
                double amount = decimal.ToDouble(nAmount.Value);
                DateTime creationDate = dateTime.Value;
                string nameCategory = lstCategories.SelectedItem.ToString();
                Category category = (Category)lstCategories.SelectedItem;
                Currency currency = (Currency)lstcurrency.SelectedItem;
                expenseController.SetExpense(amount, creationDate, description, category, currency);
                MessageBox.Show("The expense was recorded successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Visible = false;
            }
            else
            {
                SetMessage("You must select a category", lblCategories);
            }
        }

        private void BtnRegistrExpense_Click(object sender, EventArgs e)
        {
            try
            {
                TryRegisterExpense();
            }
            catch (ExcepcionInvalidDescriptionLengthExpense)
            {
                SetMessage("The description must be between 3 and 20 characters long.", lbDescription);
            }
            catch (ExcepcionNegativeAmountExpense)
            {
                SetMessage("The amount must be positive", lblAmount);
            }
            catch (ExcepcionInvalidAmountExpense)
            {
                SetMessage("The amount cannot have more than two decimal places", lblAmount);
            }
            catch (ExcepcionInvalidYearExpense)
            {
                SetMessage("The year must be between 2018 and 2030.", lblDate);
            }
            catch (ExcepcionExpenseWithEmptyCategory)
            {
                SetMessage("The category should not be empty ", lblCategories);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
