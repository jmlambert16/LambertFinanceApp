using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LambertFinanceApp.Models
{
    public class Transactions
    {
        [Key]
        public int transactionId { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public double amount { get; set; }
        public bool income { get; set; }
        public bool returned { get; set; }
        public string category { get; set; }

        //foreign key
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
