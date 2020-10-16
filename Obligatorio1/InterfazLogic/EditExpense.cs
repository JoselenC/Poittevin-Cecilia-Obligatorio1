using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace InterfazLogic
{
    public partial class EditExpense : UserControl
    {
        private Repository repository;
        public EditExpense(Repository vRepository)
        {
            InitializeComponent();
            repository = vRepository;
            this.MaximumSize = new Size(800, 800);
            this.MinimumSize = new Size(800, 800);
            lstCategories.Visible = false;
            CompleteExpense();

        }

        private void CompleteExpense()
        {
            if (repository.Expenses.Count > 0)
            {
                foreach (Expense expense in repository.Expenses) {
                    lstExpenses.Items.Add(expense);
                }
            }
            else
            {
                MessageBox.Show("There are no expenses registered in the system");
                Visible = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstExpenses.SelectedIndex >= 0)
            {
               Expense expense = repository.FindRemoveExpense(lstExpenses.SelectedItem.ToString());
               tbDescription.Text = expense.Description;
               nAmount.Value = (decimal)(expense.Amount);
               dateTime.Value = expense.CreationDate;
               lblCategory.Text = expense.Category.ToString();
               int index = lstExpenses.SelectedIndex;
               lstExpenses.Items.RemoveAt(index);
            }
            else if (repository.Expenses.Count == 0)
            {
                lblExpenses.Text = "There are no more expenses to edit";
                lblExpenses.ForeColor = Color.Red;
            }
            else
            {
                lblExpenses.Text = "Select expense to edit";
                lblExpenses.ForeColor = Color.Red;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstExpenses.SelectedIndex >= 0)
            {
                repository.FindRemoveExpense(lstExpenses.SelectedItem.ToString());
                int index = lstExpenses.SelectedIndex;
                lstExpenses.Items.RemoveAt(index);
            }
            else if (repository.Expenses.Count == 0)
            {
                lblExpenses.Text = "There are no more expenses to delete";
                lblExpenses.ForeColor = Color.Red;
            }
            else
            {
                lblExpenses.Text = "Select expense to delete";
                lblExpenses.ForeColor = Color.Red;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (lstCategories.SelectedIndex >= 0)
                {
                    string description = tbDescription.Text;
                    double amount = decimal.ToDouble(nAmount.Value);
                    DateTime creationDate = dateTime.Value;
                    string nameCategory = lstCategories.SelectedItem.ToString();
                    Category category = repository.FindCategoryByName(nameCategory);
                    repository.CreateAddExpense(amount,creationDate,description, category);
                    MessageBox.Show("The expense was recorded successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;
                }
                else
                {
                    lblCategories.Text = "You must select a category";
                    lblCategories.ForeColor = Color.Red;
                }
            }
            catch (ExcepcionInvalidDescriptionLengthExpense)
            {
                lbDescription.Text = "The name must be between 3 and 20 characters long.";
                lbDescription.ForeColor = Color.Red;
            }
            catch (ExcepcionNegativeAmountExpense)
            {
                lblAmount.Text = "The amount must be positive";
                lblAmount.ForeColor = Color.Red;
            }
            catch (ExcepcionInvalidAmountExpense)
            {
                lblAmount.Text = "The amount cannot have more than two decimal places";
                lblAmount.ForeColor = Color.Red;
            }
            catch (ExcepcionInvalidYearExpense)
            {
                lblDate.Text = "The year must be between 2018 and 2030.";
                lblDate.ForeColor = Color.Red;
            }
            catch (ExcepcionExpenseWithEmptyCategory)
            {
                lblCategories.Text = "The category should not be empty ";
                lblCategories.ForeColor = Color.Red;
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            lstCategories.Visible = true;
            foreach (Category category in repository.Categories)
            {
                lstCategories.Items.Add(category);
            }
        }
    }
}
