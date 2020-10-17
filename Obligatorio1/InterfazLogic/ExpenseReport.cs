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
    public partial class ExpenseReport : UserControl
    {
        private Repository repository;
        public ExpenseReport(Repository vRepository)
        {
            InitializeComponent();
            repository = vRepository;
            monthsWithExpenses();
            this.MaximumSize = new Size(500, 600);
            this.MinimumSize = new Size(500, 600);

        }

        private void monthsWithExpenses(){
            lblMonths.Text = "";
            List <string> months= repository.OrderedMonthsInWhichThereAreExpenses();
            if (months.Count < 1)
            {
                MessageBox.Show("There are no expenses registered in the system");
                this.Visible = false;
            }
            else
            {
                foreach (string month in months)
                {
                    lstMonths.Items.Add(month);
                }
                this.Visible = true;
            }
        }


        private void btnConsult_Click(object sender, EventArgs e)
        {
            double totalAmount = 0;
            if (lstMonths.SelectedIndex >= 0)
            {
                lblMonths.Text = "";
                string month = lstMonths.SelectedItem.ToString();
                if (month.Length == 0)
                {
                    lblMonths.Text = "You must select a month to consult";
                }
                List<Expense> expenseReportByMonth = repository.GetExpense(month);
                listView1.Items.Clear();
                ListViewItem item = new ListViewItem();
                foreach(Expense vExpense in expenseReportByMonth)
                {
                    string date = vExpense.CreationDate.ToString("dd/MM/yyyy");
                    string description = vExpense.Description;
                    string name = vExpense.Category.Name;
                    string amount = vExpense.Amount.ToString();
                        totalAmount += Convert.ToDouble(vExpense.Amount);
                        item = listView1.Items.Add(date);
                        item.SubItems.Add(description);
                        item.SubItems.Add(name);
                        item.SubItems.Add(amount);                   

                }                
                lblTotalAmount.Text = "Total amount of the month " + month + " was " + totalAmount.ToString();
            }
            else
            {
                lblMonths.Text = "Select a month to consult";
            }

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
