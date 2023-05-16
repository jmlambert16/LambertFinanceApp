using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambertFinanceApp.Models
{
    public class EFTransactionsRepository:ITransactionRepository
    {
        private TransactionDbContext _context { get; set; }

        public EFTransactionsRepository(TransactionDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Transactions> Transaction => _context.Transaction;

        public void AddTransaction(Transactions add)
        {
            _context.Set<Transactions>().Add(add);
            _context.SaveChanges();
        }

        public void UpdateTransaction(Transactions update)
        {
            _context.Update(update);
            _context.SaveChanges();
        }

        public void DeleteTransaction(Transactions delete)
        {
            _context.Transaction.Remove(delete);
            _context.SaveChanges();
        }

    }
}
