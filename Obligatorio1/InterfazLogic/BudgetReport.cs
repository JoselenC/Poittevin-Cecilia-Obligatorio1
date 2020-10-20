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
    public partial class BudgetReport : UserControl
    {
        private bool initializingForm = true;
        private LogicController logicController;
        private int oldMonthIndex = DateTime.Now.Month - 1;
        private int oldYearValue = DateTime.Now.Year;
        public BudgetReport(Repository vRepository)
        {
            logicController = new LogicController(vRepository);
            InitializeComponent();
            this.MaximumSize = new Size(800, 800);
            this.MinimumSize = new Size(800, 800);
            numYear.Value = oldYearValue;
            cboxMonth.Items.AddRange(logicController.GetAllMonthsString());
            cboxMonth.SelectedIndex = oldMonthIndex;
            initializingForm = false;
            LoadBudgetReport();
            
        }

        private bool LoadBudgetReport()
        {
            if (!initializingForm)
            {
                Budget budget = logicController.FindBudget(cboxMonth.SelectedIndex + 1, (int)numYear.Value);
                if (budget is null)
                {
                    lblReport.Text="There is not budget created for the selected date";
                    lblReport.ForeColor = Color.Red;
                    return false;
                }
                else
                {
                    lstVReport.Items.Clear();
                    foreach (BudgetCategory budgetCategory in budget.BudgetCategories)
                    {
                        Category category = budgetCategory.Category;
                        ListViewItem item = new ListViewItem(category.Name);
                        double planeedAmount = budgetCategory.Amount;
                        double realAmount = logicController.GetTotalSpentByMonthAndCategory(cboxMonth.Text, category);
                        double diffAmount = planeedAmount - realAmount;
                        item.SubItems.Add(planeedAmount.ToString());
                        item.SubItems.Add(realAmount.ToString());
                        item.SubItems.Add(diffAmount.ToString());
                        lstVReport.Items.Add(item);

                    }
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadBudgetReport();
        }

        private void cboxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!LoadBudgetReport()) {
                cboxMonth.SelectedIndex = oldMonthIndex;
            }
            else
            {
                oldMonthIndex = cboxMonth.SelectedIndex;
            }
        }

        private void numYear_ValueChanged(object sender, EventArgs e)
        {
            if (!LoadBudgetReport())
            {
                numYear.Value = oldYearValue;
            }
            else
            {
                oldYearValue = (int) numYear.Value;
            }
        }
    }
}
