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
        private IManageRepository repository;

        public CurrencyController(IManageRepository vRepository)
        {
            repository = vRepository;
        }

        public void SetCurrency(string name, string symbol, double quotation)
        {
            Currency currency = new Currency() { Name = name, Symbol = symbol, Quotation = quotation };
            repository.SetCurrency(currency);
        }

        public void DeleteCurrency(Currency currency)
        {
            repository.DeleteCurrency(currency);
        }

        public List<Currency> GetCurrencies()
        {
            return repository.GetCurrencies();
        }

        public Currency FindCurrency(Currency currency)
        {
            return repository.FindCurrency(currency);
        }      

        public void UpdateCurrency(Currency oldCurrency, Currency newCurrency)
        {
            repository.UpdateCurrency(oldCurrency, newCurrency);
            repository.EditCurrencyAllExpense(oldCurrency, newCurrency);
        }

    }
}
