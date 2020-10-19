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
    public partial class AddBudgetForm : UserControl
    {
        private Repository Repository { get; set; }
        private Budget CurrentBudget { get; set; }
        public AddBudgetForm(Repository vRepository)
        {
            InitializeComponent();
            Repository = vRepository;
            this.MaximumSize = new Size(500, 600);
            this.MinimumSize = new Size(500, 600);
            // TODO: Agregar control de que no se pueda crear un budget si no hay ninguna categoria en el sistema
            comboBoxMonth.Items.AddRange(Repository.GetAllMonthsString());
            comboBoxMonth.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EditBudgetCategory()
        {
            if (CurrentBudget is null || listBoxCategory.SelectedItem is null)
            {
                MessageBox.Show("Por favor seleccione una categoria de la lista de categorias para editar");
            }
            else
            {
                EditBudgetCategory budgetCategory = new EditBudgetCategory((BudgetCategory) listBoxCategory.SelectedItem, this);
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void listBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentBudget = GetBudget();
            LoadBudgetData(CurrentBudget);
        }

        private void AddBudgetForm_Load(object sender, EventArgs e)
        {
            
        }

        private Budget GetBudget()
        {
            string month = comboBoxMonth.SelectedItem.ToString();
            int year = (int) numericYear.Value;
            return Repository.BudgetGetOrCreate(month, year);
        }
        private void LoadBudgetData(Budget budget)
        {
            List<BudgetCategory> budgetCategories = budget.BudgetCategories;
            listBoxCategory.Items.Clear();

            foreach (var budgetCategory in budgetCategories)
            {
                listBoxCategory.Items.Add(budgetCategory);
            }
            
        }

        private void numericYear_ValueChanged(object sender, EventArgs e)
        {
            Budget newBudget = GetBudget();
            LoadBudgetData(newBudget);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Repository.AddBudget(CurrentBudget);
            Visible = false;
        }
    }
}
