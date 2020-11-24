using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Repository;

namespace InterfazLogic
{
    public partial class EditExpense : UserControl
    {
        private ExpenseController expenseController;
        private int indexToEdit;
        private bool edit;
        private bool selectExpense;
        private Expense expenseToEdit;

        public EditExpense(IManageRepository vRepository)
        {
            InitializeComponent();
            expenseController = new ExpenseController(vRepository);
            MaximumSize = new Size(800, 850);
            MinimumSize = new Size(800, 850);
            lstCategories.Visible = false;
            indexToEdit = -1;            
            edit = false;
            selectExpense = false;
            CompleteExpenses();
            tbDescription.Enabled = false;
            nAmount.Enabled = false;
            dateTime.Enabled = false;
            lstCategories.Enabled = false;
            CompleteCurrency();

        }

        private void CompleteCurrency()
        {
            foreach (Currency vCurrency in expenseController.GetCurrencies())
            {
                lstCurrency.Items.Add(vCurrency);
            }
        }

        private void CompleteExpenses()
        {
            if (expenseController.GetExpenses().Count > 0)
            {
                foreach (Expense expense in expenseController.GetExpenses()) {
                    lstExpenses.Items.Add(expense);
                }
            }
            else
            {
                MessageBox.Show("There are no expenses registered in the system");
                Visible = false;
            }
        }

        private void SetMessage(string messsage, Label lblToSetMessage)
        {
            if (lblToSetMessage != lblAmount)
                lblAmount.Text = "";
            if (lblToSetMessage != lblCategories)
                lblCategories.Text = "";
            if (lblToSetMessage != lblCategory)
                lblCategory.Text = "";
            if (lblToSetMessage != lblDate)
                lblDate.Text = "";
            if (lblToSetMessage != lblExpenses)
                lblExpenses.Text = "";
            lblToSetMessage.Text = messsage;
            lblToSetMessage.ForeColor = Color.Red;
        }

        private void CompleteExpenseToEdit()
        {
            expenseToEdit = expenseController.FindExpense((Expense)lstExpenses.SelectedItem);
            tbDescription.Text = expenseToEdit.Description;
            nAmount.Value = (decimal)(expenseToEdit.Amount);
            dateTime.Value = expenseToEdit.CreationDate;
            lblCategory.Text = expenseToEdit.Category.ToString();
            lstCurrency.SelectedIndex=0;
            indexToEdit = lstExpenses.SelectedIndex;
            selectExpense = true;
            BtnDelete.Enabled = false;
            tbDescription.Enabled = true;
            nAmount.Enabled = true;
            dateTime.Enabled = true;
            lstCategories.Enabled = true;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstExpenses.SelectedIndex >= 0)
                {
                    CompleteExpenseToEdit();
                }
                else if (expenseController.GetExpenses().Count == 0)
                {
                    SetMessage("There are no more expenses to edit", lblExpenses);
                }
                else
                {
                    SetMessage("Select expense to edit", lblExpenses);
                }
            }
            catch (NoFindEqualsExpense)
            {

            }
        }

        private void DeleteExpense()
        {
            tbDescription.Clear();
            nAmount.Value = 1;
            lstCategories.Items.Clear();
            expenseController.DeleteExpense((Expense)lstExpenses.SelectedItem);
            int index = lstExpenses.SelectedIndex;
            lstExpenses.Items.RemoveAt(index);
            lblExpenses.Text = "";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstExpenses.SelectedIndex >= 0)
            {
                DeleteExpense();
            }
            else if (expenseController.GetExpenses().Count == 0)
            {
                SetMessage("There are no more expenses to delete", lblExpenses);
            }
            else
            {
                SetMessage("Select expense to delete", lblExpenses);
            }
        }

        private void NewExpense(Category category)
        {
            string description = tbDescription.Text;
            double amount = decimal.ToDouble(nAmount.Value);
            DateTime creationDate = dateTime.Value;
            Currency Currency = expenseController.FindCurrencyByName(lstCurrency.SelectedItem.ToString());
            expenseController.SetExpense(amount, creationDate, description, category, Currency);
            MessageBox.Show("The expense was edited successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Visible = false;
            if (indexToEdit >= 0)
            {
                lstExpenses.Items.RemoveAt(indexToEdit);
                expenseController.DeleteExpense(expenseToEdit);
            }
        }

        private void TryRegisterNewExpense()
        {
            Category category = new Category();
            if (lstCategories.SelectedIndex < 0 && edit)
            {
                SetMessage("You must select a category", lblCategories);
            }
            else if (lstCategories.SelectedIndex >= 0 && edit)
            {
                string nameCategory = lstCategories.SelectedItem.ToString();
                category = expenseController.FindCategoryByName(nameCategory);
                NewExpense(category);
            }
            else
            {
                if (expenseToEdit != null)
                {
                    category = expenseToEdit.Category;
                    NewExpense(category);
                }
                else
                {
                    Visible = false;
                }
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                BtnDelete.Enabled = true;
                TryRegisterNewExpense();
            }
            catch (ExcepcionInvalidDescriptionLengthExpense)
            {
                SetMessage("The name must be between 3 and 20 characters long.", lbDescription);
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

        private void CompleteCategories()
        {
            lstCategories.Visible = true;
            try
            {
                Category category = expenseController.FindCategoryByDescription(tbDescription.Text);
                lstCategories.Items.Add(category);
            }
            catch (NoAsignCategoryByDescriptionExpense)
            {
                if (expenseController.GetCategories().Count > 0)
                {
                    foreach (Category vCategory in expenseController.GetCategories())
                    {
                        lstCategories.Items.Add(vCategory.Name);
                    }
                }
            }
            edit = true;
        }

        private void BtnEditCategory_Click(object sender, EventArgs e)
        {
            if (selectExpense)
            {
                CompleteCategories();
            }
            else
            {
                SetMessage("Select a expense to edit", lblCategories);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
