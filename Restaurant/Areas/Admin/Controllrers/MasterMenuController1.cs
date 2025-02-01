using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModel;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllrers
{
    [Area("admin")]
 
    public class MasterMenuController : Controller
    {

        public UserManager<IdentityUser> UserManager { get; } //--Register  Create Update 
        
        public IRepository<MasterMenu> MasterMenuRepository { get; }

        public MasterMenuController(IRepository<MasterMenu> masterMenuRepository , UserManager<IdentityUser> userManager)
        {
            MasterMenuRepository = masterMenuRepository;
            UserManager = userManager;
        }

        // GET: MasterMenuController1
        public ActionResult Index()
        {
            return View(MasterMenuRepository.View());
        }

        // GET: MasterMenuController1/Details/5
  

        // GET: MasterMenuController1/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: MasterMenuController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MVMasterMenu collection)
        {
            try
            {
                var masterMenu = new MasterMenu()
                {
                    MasterMenuName = collection.MasterMenuName,
                    MasterMenuUrl = collection.MasterMenuUrl,
                    CreateId = UserManager.GetUserId(User),
                
                };
                MasterMenuRepository.Add(masterMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController1/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterMenuRepository.Find(id);
            var newData = new MVMasterMenu()
            {
                MasterMenuId = data.MasterMenuId,
                MasterMenuName = data.MasterMenuName,
                MasterMenuUrl = data.MasterMenuUrl,
            };  
            return View(newData);
        }

        // POST: MasterMenuController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MVMasterMenu collection)
        {
            try
            {


                    var masterMenu = new MasterMenu()
                    {
                        MasterMenuId = collection.MasterMenuId,
                        MasterMenuName = collection.MasterMenuName,
                        MasterMenuUrl = collection.MasterMenuUrl,
                        EditId = UserManager.GetUserId(User),
                    };
                    MasterMenuRepository.Update(id,masterMenu);
                    return RedirectToAction(nameof(Index));

            }

            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController1/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete != 0)
            {
                MasterMenuRepository.Delete(idDelete, new Models.MasterMenu());
            }
            return RedirectToAction(nameof(Index));
            
        }


        public ActionResult Active(int Id)
        {
            MasterMenuRepository.Active(Id);

            return RedirectToAction(nameof(Index));

        }

       





    }
}
