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
            List <string> months= repository.MonthsOrdered();
            if (months.Count < 1)
            {
                MessageBox.Show("There are no expenses registered in the system");
                this.Visible = false;
            }
            else
            {
                for (int i = 0; i < months.Count; i++)
                {
                    lstMonths.Items.Add(months[i]);
                }
                this.Visible = true;
            }
        }


        private void btnConsult_Click(object sender, EventArgs e)
        {
            if (lstMonths.SelectedIndex >= 0)
            {
                lblMonths.Text = "";
                string month = lstMonths.SelectedItem.ToString();
                if (month.Length == 0)
                {
                    lblMonths.Text = "You must select a month to consult";
                }
                List<string[]> report = repository.ExpenseReport(month);
                listView1.Items.Clear();
                ListViewItem item = new ListViewItem();
                for (int i = 0; i < report.Count; i++)
                {
                    item = listView1.Items.Add(report[i][0]);
                    item.SubItems.Add(report[i][1]);
                    item.SubItems.Add(report[i][2]);
                    item.SubItems.Add(report[i][3]);
                }
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
