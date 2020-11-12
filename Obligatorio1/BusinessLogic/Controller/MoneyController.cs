using BusinessLogic.Repository;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class MoneyController
    {

        public IManageRepository Repository { get; private set; }

        public MoneyController(IManageRepository repository)
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

        public void EditMoney(Money oldMoney, string name, string symbol, double quotation)
        {
            Repository.DeleteMoneyToEdit(oldMoney);
            setMoney(name, symbol, quotation);
            Money newMoney = new Money { Name = name, Quotation = quotation, Symbol = symbol };
            Repository.EditMoneyAllExpense(oldMoney, newMoney);
            
        }
    }
}
