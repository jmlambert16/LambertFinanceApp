using LambertFinanceApp.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambertFinanceApp.Models.ViewModels
{
    public class TransactionsViewModel
    {
        public Transactions transactionsForm { get; set; }
        public Category category { get; set; }
        public IQueryable<Transactions> transactions { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
