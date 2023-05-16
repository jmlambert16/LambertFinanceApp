using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambertFinanceApp.Models
{
    public interface ITransactionRepository
    {
        IQueryable<Transactions> Transaction { get; }

        void AddTransaction(Transactions add);
        void UpdateTransaction(Transactions update);
        void DeleteTransaction(Transactions delete);
    }
}
