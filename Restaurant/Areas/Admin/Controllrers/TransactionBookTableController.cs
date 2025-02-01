using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllrers
{
    [Area("admin")]
    public class TransactionBookTableController : Controller
    {
        public IRepository<TransactionBookTable> TransactionBookTable { get; }

        public TransactionBookTableController(IRepository<TransactionBookTable> _transactionBookTable )
        {
            TransactionBookTable = _transactionBookTable;
        }
        // GET: TransactionBookTableController
        public ActionResult Index()
        {
            
            return View(TransactionBookTable.View());
        }

        // GET: TransactionBookTableController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}
