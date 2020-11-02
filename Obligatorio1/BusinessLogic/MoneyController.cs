using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MoneyController
    {

        public MemoryRepository Repository { get; private set; }

        public MoneyController(MemoryRepository repository)
        {
            Repository = repository;
        }

        public void setMoney(string name, string symbol, double quotation)
        {
            Money money = new Money() { Name = name, Symbol = symbol, Quotation = quotation };
            Repository.SetMoney(money);
        }

        public void DeleteMoney(Money money)
        {
            Repository.DeleteMoney(money);
        }

        public List<Money> GetMonies()
        {
            return Repository.GetMonies();
        }

        public Money FindMoney(Money money)
        {
            return Repository.FindMoney(money);
        }
    }
}
