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
            initializingForm = false;
           
            GetMonths();
            
        }

        private void GetMonths()
        {
            if (logicController.Repository.GetBudgets().Count == 0)
            {
                MessageBox.Show("There are no budgets registered in the system");
                this.Visible = false;
            }
            else
            {
                cboxMonth.Items.Clear();
                List<string> monthsWithBudget = logicController.OrderedMonthsInWhichThereAreBudget();
                foreach (string month in monthsWithBudget)
                {
                    cboxMonth.Items.Add(month);
                }
            }
           
        }

        private bool CompleteReport(ref double totalPlanedAmount, ref double totalRealAmount, ref double totalDiffAmount, Budget budget)
        {
            lblReport.Text = "";
            lstVReport.Items.Clear();
            foreach (BudgetCategory budgetCategory in budget.BudgetCategories)
            {
                Category category = budgetCategory.Category;
                ListViewItem item = new ListViewItem(category.Name);
                item.UseItemStyleForSubItems = false;
                double planeedAmount = budgetCategory.Amount;
                double realAmount = logicController.GetTotalSpentByMonthAndCategory(cboxMonth.Text, category);
                double diffAmount = planeedAmount - realAmount;
                totalPlanedAmount += planeedAmount;
                totalRealAmount += realAmount;
                totalDiffAmount += diffAmount;
                if (totalPlanedAmount < 0)
                    item.SubItems.Add("(" + (Math.Abs(planeedAmount)).ToString() + ")").ForeColor = Color.Red;
                else
                    item.SubItems.Add(planeedAmount.ToString());
                if (realAmount < 0)
                    item.SubItems.Add("(" + (Math.Abs(realAmount)).ToString() + ")").ForeColor = Color.Red;
                else
                    item.SubItems.Add(realAmount.ToString());
                if (diffAmount < 0)
                    item.SubItems.Add("(" + (Math.Abs(diffAmount)).ToString() + ")").ForeColor = Color.Red;
                else
                    item.SubItems.Add(diffAmount.ToString());
                lstVReport.Items.Add(item);

            }
            ListViewItem total = new ListViewItem("TOTAL");
            total.UseItemStyleForSubItems = false;
            if (totalPlanedAmount < 0)
                total.SubItems.Add("(" + (Math.Abs(totalPlanedAmount)).ToString() + ")").ForeColor = Color.Red;
            else
                total.SubItems.Add(totalPlanedAmount.ToString());
            if (totalRealAmount < 0)
                total.SubItems.Add("(" + (Math.Abs(totalRealAmount)).ToString() + ")").ForeColor = Color.Red;
            else
                total.SubItems.Add(totalRealAmount.ToString());
            if (totalDiffAmount < 0)
                total.SubItems.Add("(" + (Math.Abs(totalDiffAmount)).ToString() + ")").ForeColor = Color.Red;
            else
                total.SubItems.Add(totalDiffAmount.ToString());

            lstVReport.Items.Add(total);
            return true;
        }

        private bool LoadBudgetReport()
        {
            double totalPlanedAmount = 0;
            double totalRealAmount = 0;
            double totalDiffAmount = 0;
            if (!initializingForm)
            {
                
                Budget budget = logicController.FindBudget(cboxMonth.SelectedItem.ToString(), (int)numYear.Value);
                try
                {
                    return CompleteReport(ref totalPlanedAmount, ref totalRealAmount, ref totalDiffAmount, budget);

                }
                catch (NoFindBudget)
                {
                    lblReport.Text = "There is not budget created for the selected date";
                    lblReport.ForeColor = Color.Red;
                    return false;
                }              

            }
            else
                return false;
        }

      

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadBudgetReport();
        }

        private void cboxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                oldMonthIndex = cboxMonth.SelectedIndex;
            
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Visible = false;

        }
    }
}
