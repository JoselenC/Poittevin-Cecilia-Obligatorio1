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
            this.MaximumSize = new Size(800, 800);
            this.MinimumSize = new Size(800, 800);
            tbDescription.Clear();
            lstCategories.Items.Clear();
        }

        private void CompleteCategories(string description)
        {
            Category category = repository.FindCategoryByDescription(description);
            string categoryName = "";
            if (category != null)
            {
                categoryName = category.Name;
                lstCategories.Items.Add(categoryName);
            }
            else if (repository.Categories.Count > 0)
            {
                foreach (Category vCategory in repository.Categories)
                {
                    lstCategories.Items.Add(vCategory.Name);
                }
            }
            else
            {
                MessageBox.Show("There are no categories registered in the system");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string description = tbDescription.Text;
            CompleteCategories(description);
        }


        private void btnRegistrExpense_Click(object sender, EventArgs e)
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
                    repository.SetExpense(amount, creationDate, description, category);                
                    MessageBox.Show("The expense was recorded successfully","",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

       
    }
}
