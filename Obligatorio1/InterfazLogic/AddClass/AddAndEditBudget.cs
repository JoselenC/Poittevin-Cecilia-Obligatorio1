using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Repository;

namespace InterfazLogic
{
    public partial class AddAndEditBudget : UserControl
    {
        private BudgetController budgetController { get; set; }
        private Budget currentBudget { get; set; }
        public AddAndEditBudget(ManagerRepository vRepository)
        {
            InitializeComponent();
            budgetController = new BudgetController(vRepository);
            MaximumSize = new Size(500, 600);
            MinimumSize = new Size(500, 600);
            nMonth.Items.AddRange(budgetController.GetAllMonthsString());           
            nMonth.SelectedIndex = 0;
        }

        private void SetMessage(string messsage, Label lblToSetMessage)
        {
            if (lblToSetMessage != lblMonth)
                lblMonth.Text = "";
            if (lblToSetMessage != lblCategories)
                lblCategories.Text = "";
            lblToSetMessage.Text = messsage;
            lblToSetMessage.ForeColor = Color.Red;
        }

        private void EditBudgetCategory()
        {
            if (currentBudget is null || lstCategory.SelectedItem is null)
            {
                SetMessage("Select a category from the category list to edit", lblCategories);
            }
            else
            {
                lblCategories.Text = "";
                EditBudgetCategory budgetCategory = new EditBudgetCategory((BudgetCategory)lstCategory.SelectedItem, this);
                budgetCategory.Show();
                budgetCategory.FormClosing += (sender, eventArgs) =>
                {
                    LoadBudgetData(currentBudget);
                };
            }
        }

        private void listBoxCategory_DoubleClick(object sender, EventArgs e)
        {
            EditBudgetCategory();
        }

        private void ChangeBudgetCategory_Click(object sender, EventArgs e)
        {
            EditBudgetCategory();
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                currentBudget = GetBudget();
                LoadBudgetData(currentBudget);
            }
            catch (ExceptionBudgetWithEmptyCategory){
                MessageBox.Show("There are no categories registered in the system");
                Visible = false;
            }
        }

        private Budget GetBudget()
        {
           
            string month = nMonth.SelectedItem.ToString();
            int year = (int)NYear.Value;
            return budgetController.BudgetGetOrCreate(month, year);
        }

        private void LoadBudgetData(Budget budget)
        {

            List<BudgetCategory> budgetCategories = budget.BudgetCategories;
            
            lstCategory.Items.Clear();

            foreach (var budgetCategory in budgetCategories)
            {
                lstCategory.Items.Add(budgetCategory);
            }
        } 

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                budgetController.SetBudget(currentBudget);
                Visible = false;
            }
            catch (ArgumentNullException)
            {
                SetMessage("Selecct a correct month", lblMonth);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void NYear_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Budget newBudget = GetBudget();
                LoadBudgetData(newBudget);
                currentBudget = newBudget;
            }
            catch (ExceptionBudgetWithEmptyCategory)
            {
                MessageBox.Show("There are no categories registered in the system");
                Visible = false;
            }
        }
    }
    }
