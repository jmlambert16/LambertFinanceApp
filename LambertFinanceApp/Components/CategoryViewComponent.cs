using LambertFinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambertFinanceApp.Components
{
    public class CategoryViewComponent: ViewComponent
    {
        private ITransactionRepository repo { get; set; }

        public CategoryViewComponent (ITransactionRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            var types = repo.Transaction
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(types);
        }
    }
}
