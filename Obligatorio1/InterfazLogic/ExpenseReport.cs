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

        }

        private void monthsWithExpenses(){
            List <string> months= repository.MonthsOrdered();
            for (int i = 0; i < months.Count; i++)
            {
                lstMonths.Items.Add(months[i]);
            }
        }


        private void btnConsult_Click(object sender, EventArgs e)
        {
           
            string month = lstMonths.SelectedIndex.ToString();
            List<string[]> report=repository.ExpenseReport(month);
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

       
    }
}
