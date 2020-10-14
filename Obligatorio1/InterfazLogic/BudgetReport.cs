using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazLogic
{
    public partial class BudgetReport : Form
    {
        private Repository repository;
        public BudgetReport(Repository vRepository)
        {
            repository = vRepository;
            InitializeComponent();
            cboxMonth.Items.AddRange(repository.GetAllMonthsString());

        }

        private void lstVReport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string workingMonth = cboxMonth.Text;
            Budget budget = repository.BudgetGetOrCreate(workingMonth, DateTime.Now.Year);
            foreach (BudgetCategory budgetCategory in budget.BudgetCategories)
            {
                Category category = budgetCategory.Category;
                ListViewItem item = new ListViewItem(category.Name);
                double planeedAmount = budgetCategory.Amount;
                double realAmount = repository.GetTotalSpentByMonthAndCategory(workingMonth, category);
                double diffAmount = planeedAmount - realAmount;
                item.SubItems.Add(planeedAmount.ToString());
                item.SubItems.Add(realAmount.ToString());
                item.SubItems.Add(diffAmount.ToString());
                lstVReport.Items.Add(item);

            }
        }
    }
}
