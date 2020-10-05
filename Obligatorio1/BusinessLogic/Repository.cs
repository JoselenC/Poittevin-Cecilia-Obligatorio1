using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Repository
    {
        public List<Category> categoryList { set { } }

        public List<Expense> expenseList { get; set; }

        public Repository(List<Category> categoryReceived)
        {
            this.Categories = categoryReceived;

        }       

        public Category findCategory(string description, List<Category> categoryListReceived)
        {
            Category category = null;
            string[] desc = description.Split(' ');
            bool exist = false;
            int cont = 0;
            for (int i = 0; i < categoryListReceived.Count; i++)
            {
                exist = false;
                for (int j = 0; j < desc.Length && !exist; j++)
                {
                    exist = categoryListReceived[i].keyWords.Contains(desc[j]);
                }
                if (exist)
                {
                    category = categoryListReceived[i];
                    cont=cont+1;
                }
            }
            if (cont == 1)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        public List<string> MonthsOrdered()
        {
            List<int> months = new List<int>();
            for (int i = 0; i < this.expenseList.Count; i++)
            {
                Expense expense = this.expenseList[i];
                if (!months.Contains(expense.creationDate.Month))
                    months.Add(expense.creationDate.Month);
            }
            months.Sort();
            List<string> monthsString=GetMonthsString(months);
            return monthsString;
        }

        private List<string> GetMonthsString(List<int> months)
        {
            List<string> monthsString = new List<string>();
            for (int i = 0; i < months.Count; i++)
            {
                DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                string nombreMes = formatoFecha.GetMonthName(months[i]);
                monthsString.Add(nombreMes);                
            }
            return monthsString;
        }

        public double ExpenseByMonths(string month)
        {
            int monthInt = ToIntMonth(month);
            double total = 0;
            for (int i = 0; i < this.expenseList.Count; i++)
            {
                Expense expense = this.expenseList[i];
                if (expense.creationDate.Month == monthInt)
                    total += expense.amount;                    
            }
            return total;
        }

        private int ToIntMonth(string month)
        {
            if (month == "Enero") return 1;
            if (month == "Febrero") return 2;
            if (month == "Marzo") return 3;
            if (month == "Abril") return 4;
            if (month == "Mayo") return 5;
            if (month == "Junio") return 6;
            if (month == "Julio") return 7;
            if (month == "Agosto") return 8;
            if (month == "Setiembre") return 9;
            if (month == "Octubre") return 10;
            if (month == "Noviembre") return 11;
            return 12;
        }

        //funciones de Reporte de Gastos:se muestran los gastos y el monto total del month. 
        //obtener todo eso que tenemos que mostrar
        public List<string[]> ExpenseReport(string month)
        {
            int monthInt = ToIntMonth(month);
            List<string[]> reports = new List<string[]>();
            for (int i = 0; i < this.Expenses.Count; i++)
            {
                string[] report = new string[4];
                Expense expense = this.Expenses[i];
                if (expense.CreationDate.Month == monthInt)
                {
                    string date = ToStringDate(expense.CreationDate);
                    string description = expense.Description;
                    string name = expense.Category.Name;
                    string amount = expense.Amount.ToString();

                    report[0] = date;
                    report[1] = description;
                    report[2] = name;
                    report[3] = amount;

                }
                reports.Add(report);
            }
            return reports;
        }

        private string ToStringDate(DateTime creationDate)
        {
            string date;
            string year = creationDate.Year.ToString();
            string month = creationDate.Month.ToString();
            string day = creationDate.Day.ToString();
            date = day + "/" + month + "/" + year;
            return date;
        }

    }
}