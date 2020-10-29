using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogic;

namespace InterfazLogic
{
    public partial class EditExpense : UserControl
    {
        private ExpenseController expenseController;
        private int indexToEdit;
        private bool edit;
        private bool selectExpense;
        private Expense expenseToEdit;

        public EditExpense(MemoryRepository vRepository)
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

        private void CompleteExpenseToEdit()
        {
            expenseToEdit = expenseController.FindExpense((Expense)lstExpenses.SelectedItem);
            tbDescription.Text = expenseToEdit.Description;
            nAmount.Value = (decimal)(expenseToEdit.Amount);
            dateTime.Value = expenseToEdit.CreationDate;
            lblCategory.Text = expenseToEdit.Category.ToString();
            indexToEdit = lstExpenses.SelectedIndex;
            selectExpense = true;
            btnDelete.Enabled = false;
            tbDescription.Enabled = true;
            nAmount.Enabled = true;
            dateTime.Enabled = true;
            lstCategories.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstExpenses.SelectedIndex >= 0)
                {
                    CompleteExpenseToEdit();
                }
                else if (expenseController.GetExpenses().Count == 0)
                {
                    lblExpenses.Text = "There are no more expenses to edit";
                    lblExpenses.ForeColor = Color.Red;
                    lblAmount.Text = "";
                    lblCategories.Text = "";
                    lbDescription.Text = "";
                    lblDate.Text = "";
                }
                else
                {
                    lblExpenses.Text = "Select expense to edit";
                    lblExpenses.ForeColor = Color.Red;
                    lblAmount.Text = "";
                    lblCategories.Text = "";
                    lbDescription.Text = "";
                    lblDate.Text = "";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstExpenses.SelectedIndex >= 0)
            {
                DeleteExpense();
            }
            else if (expenseController.GetExpenses().Count == 0)
            {
                lblExpenses.Text = "There are no more expenses to delete";
                lblExpenses.ForeColor = Color.Red;
                lblAmount.Text = "";
                lblCategories.Text = "";
                lbDescription.Text = "";
                lblDate.Text = "";
            }
            else
            {
                lblExpenses.Text = "Select expense to delete";
                lblExpenses.ForeColor = Color.Red;
                lblAmount.Text = "";
                lblCategories.Text = "";
                lbDescription.Text = "";
                lblDate.Text = "";
            }
        }      

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Enabled = true;
                TryRegisterNewExpense();
            }
            catch (ExcepcionInvalidDescriptionLengthExpense)
            {
                lbDescription.Text = "The name must be between 3 and 20 characters long.";
                lbDescription.ForeColor = Color.Red;
                lblAmount.Text = "";
                lblCategories.Text = "";
                lblExpenses.Text = "";
                lblDate.Text = "";
            }
            catch (ExcepcionNegativeAmountExpense)
            {
                lblAmount.Text = "The amount must be positive";
                lblAmount.ForeColor = Color.Red;
                lblExpenses.Text = "";
                lblCategories.Text = "";
                lbDescription.Text = "";
                lblDate.Text = "";
            }
            catch (ExcepcionInvalidAmountExpense)
            {
                lblAmount.Text = "The amount cannot have more than two decimal places";
                nAmount.Value = 1;
                lblAmount.ForeColor = Color.Red;
                lblExpenses.Text = "";
                lblCategories.Text = "";
                lbDescription.Text = "";
                lblDate.Text = "";
            }
            catch (ExcepcionInvalidYearExpense)
            {
                lblDate.Text = "The year must be between 2018 and 2030.";
                lblDate.ForeColor = Color.Red;
                lblExpenses.Text = "";
                lblCategories.Text = "";
                lbDescription.Text = "";
                lblAmount.Text = "";
            }
            catch (ExcepcionExpenseWithEmptyCategory)
            {
                lblCategories.Text = "The category should not be empty ";
                lblCategories.ForeColor = Color.Red;
                lblExpenses.Text = "";
                lblAmount.Text = "";
                lbDescription.Text = "";
                lblDate.Text = "";
            }
          
        }

        private void NewExpense(Category category)
        {
            string description = tbDescription.Text;
            double amount = decimal.ToDouble(nAmount.Value);
            DateTime creationDate = dateTime.Value;
            expenseController.SetExpense(amount, creationDate, description, category);
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
                lblCategories.Text = "You must select a category";
                lblCategories.ForeColor = Color.Red;
                lblExpenses.Text = "";
                lblAmount.Text = "";
                lbDescription.Text = "";
                lblDate.Text = "";
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

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (selectExpense)
            {
                CompleteCategories();
            }
            else
            {
                lblCategories.Text = "Select a expense to edit";
                lblCategories.ForeColor = Color.Red;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
