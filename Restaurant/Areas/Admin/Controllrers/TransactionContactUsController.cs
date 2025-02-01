using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllrers
{
    [Area("admin")]
    public class TransactionContactUsController : Controller
    {
        public IRepository<TransactionContactU> TransactionContactU { get; }

        public TransactionContactUsController(IRepository<TransactionContactU> _transactionContactU)
        {
            TransactionContactU = _transactionContactU;
        }
        // GET: TransactionContactUsController
        public ActionResult Index()
        {
            return View(TransactionContactU.View());
        }

       
        public ActionResult Delete(int id)
        {
            return View();
        }

       
    }
}
