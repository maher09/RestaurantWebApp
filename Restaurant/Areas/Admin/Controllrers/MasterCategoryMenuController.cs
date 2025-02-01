using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModel;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllrers
{
    [Area("admin")]
    public class MasterCategoryMenuController : Controller
    {
        public IRepository<MasterCategoryMenu> MasterMenuCategoryRepository { get; }
        public UserManager<IdentityUser> UserManager { get; }

        public MasterCategoryMenuController(IRepository<MasterCategoryMenu> masterMenuCategoryRepository , UserManager<IdentityUser> userManager)
        {
            MasterMenuCategoryRepository = masterMenuCategoryRepository;
            UserManager = userManager;
        }
        // GET: MasterCategoryMenuController
        public ActionResult Index()
        {
            return View(MasterMenuCategoryRepository.View());
        }

       
        // GET: MasterCategoryMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterCategoryMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MVMasterCategoryMenu collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    MasterCategoryMenu masterMenuCategory = new MasterCategoryMenu()
                    {
                        MasterCategoryMenuName = collection.MasterCategoryMenuName,
                        CreateId = UserManager.GetUserId(User),

                    };
                    MasterMenuCategoryRepository.Add(masterMenuCategory);     

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterMenuCategoryRepository.Find(id);
            var newData = new MVMasterCategoryMenu()
            {
                MasterCategoryMenuId = data.MasterCategoryMenuId,
                MasterCategoryMenuName = data.MasterCategoryMenuName,
            };
            return View(newData);
        }

        // POST: MasterCategoryMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MVMasterCategoryMenu collection)
        {
            try
            {
              
                if (id != collection.MasterCategoryMenuId)
                {
                    return NotFound();
                }
                var masterMenuCategory = new MasterCategoryMenu()
                {
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterCategoryMenuName = collection.MasterCategoryMenuName,
                    EditId = UserManager.GetUserId(User),
                };
                MasterMenuCategoryRepository.Update(id, masterMenuCategory);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete != 0)
            {
                MasterMenuCategoryRepository.Delete(idDelete, new Models.MasterCategoryMenu());
            }
            return RedirectToAction(nameof(Index));

        }

        public ActionResult Active(int Id)
        {
            MasterMenuCategoryRepository.Active(Id);

            return RedirectToAction(nameof(Index));

        }


    }
}
