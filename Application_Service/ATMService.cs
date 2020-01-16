using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service
{
    public class ATMService
    {
        public readonly AppDbContext db = new AppDbContext();

        public decimal GetAccountBalance(int id)
        {
            var selectedAccount = db.BankAccounts.Find(id);
            return selectedAccount.AccountBalance;
        }
    }
}
