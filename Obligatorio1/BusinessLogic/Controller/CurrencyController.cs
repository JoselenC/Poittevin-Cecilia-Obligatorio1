using System;
using BusinessLogic.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CurrencyController
    {
        private ManagerRepository repository;

        public CurrencyController(ManagerRepository vRepository)
        {
            repository = vRepository;
        }
        private bool AlreadyExistTheCurrencySymbol(string CurrencySymbol)
        {
            bool exist = false;
            foreach (Currency Currency in GetCurrencies())
            {
                if (CurrencySymbol.ToLower() == Currency.Symbol.ToLower())
                    exist = true;
            }
            return exist;
        }

        private bool AlreadyExistTheCurrencyName(string CurrencyName)
        {
            bool exist = false;
            foreach (Currency Currency in GetCurrencies())
            {
                if (CurrencyName.ToLower() == Currency.Name.ToLower())
                    exist = true;
            }
            return exist;
        }

        public void SetCurrency(string name, string symbol, double quotation)
        {
            Currency currency = new Currency() { Name = name, Symbol = symbol, Quotation = quotation };

            if (AlreadyExistTheCurrencySymbol(currency.Symbol))
                throw new ExceptionAlreadyExistTheCurrencySymbol();
            if (AlreadyExistTheCurrencyName(currency.Name))
                throw new ExceptionAlreadyExistTheCurrencyName();
            repository.Currencies.Add(currency);
        }

        public void DeleteCurrency(Currency currency)
        {
            ExpenseController expenseController = new ExpenseController(repository);
            try
            {
                foreach (Expense expense in expenseController.GetExpenses())
                {
                    expense.IsSameCurrencyExpense(currency);
                }
                repository.Currencies.Delete(currency);
            }
            catch (ExcepcionNoDeleteCurrency)
            {
                throw new ExcepcionNoDeleteCurrency();
            }
        }

        public List<Currency> GetCurrencies()
        {
            return repository.Currencies.Get();
        }

        public Currency FindCurrency(Currency currency)
        {
            try
            {
                return repository.Currencies.Find(e => e.Equals(currency));
            }
            catch (ValueNotFound)
            {
                throw new NoFindCurrency();
            }
        }      

        public void UpdateCurrency(Currency oldCurrency, Currency newCurrency)
        {
            repository.Currencies.Update(oldCurrency, newCurrency);
            EditCurrencyAllExpense(oldCurrency, newCurrency);
        }

        private void EditCurrencyAllExpense(Currency oldCurrency, Currency newCurrency)
        {
            ExpenseController expenseController = new ExpenseController(repository);
            foreach (Expense expense in expenseController.GetExpenses())
            {
                expense.EditCurrency(oldCurrency, newCurrency);
            }
        }

        public Currency FindCurrencyByName(string currencyName)
        {
            try
            {
                return repository.Currencies.Find(e => e.IsSameCurrencyName(currencyName));
            }
            catch (ValueNotFound)
            {
                throw new NoFindCurrencyByName();
            }
        }
    }
}
