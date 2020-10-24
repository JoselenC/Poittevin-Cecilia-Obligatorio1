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
    public partial class AddAndEditBudget : UserControl
    {
        private LogicController logicController { get; set; }
        private Budget CurrentBudget { get; set; }
        public AddAndEditBudget(Repository vRepository)
        {
            InitializeComponent();
            logicController = new LogicController(vRepository);
            this.MaximumSize = new Size(500, 600);
            this.MinimumSize = new Size(500, 600);
            nMonth.Items.AddRange(logicController.GetAllMonthsString());
            CategoriesCount();
            nMonth.SelectedIndex = 0;
        }

        private void CategoriesCount()
        {
            if (logicController.GetCategories().Count == 0)
            {
                MessageBox.Show("There are no categories registered in the system");
                Visible = false;
            }
        }
        private void EditBudgetCategory()
        {
            if (CurrentBudget is null || lstCategory.SelectedItem is null)
            {
                lblCategories.Text = "Select a category from the category list to edit";
                lblCategories.ForeColor = Color.Red;
            }
            else
            {
                lblCategories.Text = "";
                EditBudgetCategory budgetCategory = new EditBudgetCategory((BudgetCategory)lstCategory.SelectedItem, this);
                budgetCategory.Show();
                budgetCategory.FormClosing += (sender, eventArgs) =>
                {
                    LoadBudgetData(CurrentBudget);
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
            CurrentBudget = GetBudget();
            LoadBudgetData(CurrentBudget);
        }

        private Budget GetBudget()
        {
           
            string month = nMonth.SelectedItem.ToString();
            int year = (int)nYear.Value;
            return logicController.BudgetGetOrCreate(month, year);

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

        private void numericYear_ValueChanged(object sender, EventArgs e)
        {
            Budget newBudget = GetBudget();
            LoadBudgetData(newBudget);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                logicController.AddBudget(CurrentBudget);
                Visible = false;
            }
            catch (ArgumentNullException){
                lblMonth.Text = "Selecct a correct month";
                lblMonth.ForeColor = Color.Red;
            }

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
    }
