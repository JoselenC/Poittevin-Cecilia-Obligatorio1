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
    public partial class RegisterExpense : UserControl
    {
        private Repository repository;
        public RegisterExpense(Repository vRepository)
        {
            InitializeComponent();
            repository = vRepository;
            this.MaximumSize = new Size(500, 600);
            this.MinimumSize = new Size(500, 600);

            tbDescription.Clear();
            lstCategories.Items.Clear();
        }

        private void CompleteCategories(string description)
        {
            Category category = repository.FindCategoryByDescription(description);
            string categoryName = "";

            if(category!=null)
                categoryName = category.Name;

            if (categoryName.Length > 0)
            {
                lstCategories.Items.Add(categoryName);
            }
            else if (repository.Categories.Count > 0)
            {
                for (int i = 0; i < repository.Categories.Count; i++)
                {
                    lstCategories.Items.Add(repository.Categories[i].Name);
                }
            }
            else
            {
                MessageBox.Show("There are no categories registered in the system");
            }
        }


        private void btnRegistrExpense_Click(object sender, EventArgs e)
        {
            try
            {
                string description = tbDescription.Text;
                double amount = decimal.ToDouble(nAmount.Value);
                DateTime creationDate = dateTime.Value;
                Expense expense = new Expense { Amount = amount, CreationDate = creationDate, Description = description };
                if (lstCategories.SelectedIndex >= 0)
                {
                    string nameCategory = lstCategories.SelectedItem.ToString();
                    Category category = repository.FindCategoryByName(nameCategory);
                    expense.Category = category;
                    repository.AddExpenseToExpenses(expense);
                    lbDescription.Text = "";
                    lblAmount.Text = "";
                    lblCategories.Text = "";
                    lblDate.Text = "";
                    MessageBox.Show("The expense was recorded successfully");
                    this.Visible = false;
                }
                else
                {
                    lblCategories.Text = "You must select a category";
                }
            }
            catch (ExcepcionInvalidDescriptionLengthExpense)
            {
                lbDescription.Text = "The name must be between 3 and 20 characters long.";            
                lblAmount.Text = "";
                lblCategories.Text = "";
                lblDate.Text = "";

            }
            catch (ExcepcionNegativeAmountExpense)
            {
                lblAmount.Text = "The amount must be positive";
                lbDescription.Text = "";
                lblCategories.Text = "";
                lblDate.Text = "";
            }
            catch (ExcepcionInvalidYearExpense)
            {
                lblDate.Text = "The year must be between 2018 and 2030.";
                lbDescription.Text = "";
                lblAmount.Text = "";
                lblCategories.Text = "";
            }
            catch (ExcepcionExpenseWithEmptyCategory)
            {
                lblCategories.Text = "The category should not be empty ";
                lbDescription.Text = "";
                lblAmount.Text = "";
                lblDate.Text = "";
            }
            catch (ExcepcionInvalidAmountExpense)
            {
                lblAmount.Text= "The amount cannot have more than two decimal places";
                lbDescription.Text = "";
                lblCategories.Text = "";
                lblDate.Text = "";
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string description = tbDescription.Text;
            CompleteCategories(description);
        }
    }
}
