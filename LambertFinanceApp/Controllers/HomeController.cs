using LambertFinanceApp.Models;
using LambertFinanceApp.Models.VeiwModels;
using LambertFinanceApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LambertFinanceApp.Controllers
{
    public class HomeController : Controller
    {
        private ITransactionRepository _repo { get; set; }
        private TransactionDbContext tcontext { get; set; }

        public HomeController(ITransactionRepository temp, TransactionDbContext context)
        {
            _repo = temp;
            tcontext = context; 
        }


        [HttpGet]
        public IActionResult Index(int CategoryId, int pageNum = 1)
        {

            ViewBag.categories = tcontext.Category.ToList();

            int pageSize = 10;

            var x = new TransactionsViewModel
            {
                transactions = _repo.Transaction
                .Where(c => c.CategoryID == CategoryId || CategoryId == 0)
                .Include(x => x.Category)
                .OrderByDescending(p => p.date)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumTransactions = (CategoryId == 0
                    ? _repo.Transaction.Count()
                    : _repo.Transaction.Where(x => x.CategoryID == CategoryId).Count()),
                    TransactionsPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };


            return View(x);
        }

        [HttpPost]
        public IActionResult Index(TransactionsViewModel model)
        {
            _repo.AddTransaction(model.transactionsForm);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.categories = tcontext.Category.ToList();
            Transactions transaction = _repo.Transaction.Single(c => c.transactionId == id);

            return View(transaction);
        }

        [HttpPost]
        public IActionResult Edit(Transactions model)
        {
            _repo.UpdateTransaction(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var transaction = _repo.Transaction.Single(x => x.transactionId == id);

            return View(transaction);
        }

        [HttpPost]
        public IActionResult Delete(Transactions model)
        {
            _repo.DeleteTransaction(model);

            return RedirectToAction("Index");
        }
    }
}
