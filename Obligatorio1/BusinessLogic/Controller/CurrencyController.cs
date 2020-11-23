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

        public IManageRepository Repository { get; private set; }

        public CurrencyController(IManageRepository repository)
        {
            Repository = repository;
        }

        public void SetCurrency(string name, string symbol, double quotation)
        {
            Currency currency = new Currency() { Name = name, Symbol = symbol, Quotation = quotation };
            Repository.SetCurrency(currency);
        }

        public void DeleteCurrency(Currency currency)
        {
            Repository.DeleteCurrency(currency);
        }

        public List<Currency> GetCurrencies()
        {
            return Repository.GetCurrencies();
        }

        public Currency FindCurrency(Currency currency)
        {
            return Repository.FindCurrency(currency);
        }      

        public void UpdateCurrency(Currency oldCurrency, Currency newCurrency)
        {
            Repository.UpdateCurrency(oldCurrency, newCurrency);
            Repository.EditCurrencyAllExpense(oldCurrency, newCurrency);
        }

    }
}
