using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEntityModel
{
    public class BankAccount
    {
        public int Id { get; set; }
        public long AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
