using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CurrencyController
    {

        public MemoryRepository Repository { get; private set; }

        public CurrencyController(MemoryRepository repository)
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

        public void EditCurrency(Currency oldCurrency, string name, string symbol, double quotation)
        {
            Repository.DeleteCurrencyToEdit(oldCurrency);
            SetCurrency(name, symbol, quotation);
            Currency newCurrency = new Currency { Name = name, Quotation = quotation, Symbol = symbol };
            Repository.EditCurrencyAllExpense(oldCurrency, newCurrency);
            
        }
    }
}
