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
                    cboxMonth.SelectedIndex = 0;
                }                
            }           
        }

        private bool CompleteReport(ref double totalPlanedAmount, ref double totalRealAmount, ref double totalDiffAmount, Budget budget)
        {
           
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
            try
            {
                double totalPlanedAmount = 0;
                double totalRealAmount = 0;
                double totalDiffAmount = 0;
                if (!initializingForm)
                {                   
                    try
                    {
                        int year=(int)numYear.Value;                       
                        Budget budget = logicController.FindBudget(cboxMonth.SelectedItem.ToString(), year);
                        oldYearValue = year;
                        return CompleteReport(ref totalPlanedAmount, ref totalRealAmount, ref totalDiffAmount, budget);                       
                        
                    }
                    catch (NoFindBudget)
                    {
                        MessageBox.Show("There is not budget created for the selected date");
                        numYear.Value = oldYearValue;
                        return false;
                    }
                    catch (System.NullReferenceException)
                    {
                        lblMonth.Text = "Select a month to consult";
                        lblMonth.ForeColor = Color.Red;
                        return false;
                    }

                }
                else
                    return false;
            }
            catch (ArgumentNullException)
            {
                lblMonth.Text = "Selecct a correct month";
                lblMonth.ForeColor = Color.Red;
                return false;
            }
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
           
                oldYearValue = (int)numYear.Value;
            
        }
        
        private void btnAccept_Click(object sender, EventArgs e)
        {
            Visible = false;

        }
    }
}
