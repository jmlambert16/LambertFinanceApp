using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambertFinanceApp.Models.VeiwModels
{
    public class PageInfo
    {
        public int TotalNumTransactions { get; set; }
        public int TransactionsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalNumTransactions / TransactionsPerPage);
    }
}
