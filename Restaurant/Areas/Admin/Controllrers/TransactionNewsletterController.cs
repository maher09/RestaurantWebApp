using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllrers
{
    [Area("admin")]
    public class TransactionNewsletterController : Controller
    {
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }

        public TransactionNewsletterController(IRepository<TransactionNewsletter> _TransactionNewsletter)
        {
            TransactionNewsletter = _TransactionNewsletter;
        }
        // GET: TransactionNewsletterController
        public ActionResult Index()
        {
            return View(TransactionNewsletter.View());
        }

   
       
        // GET: TransactionNewsletterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

      
    }
}
