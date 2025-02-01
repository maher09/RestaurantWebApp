using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using NuGet.Protocol.Core.Types;
using Restaurant.Areas.Admin.ViewModel;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllrers
{
    [Area("admin")]
    public class MasterItemMenusController : Controller
    {
        public IRepository<MasterItemMenu> MasterItemMenuRepository { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IWebHostEnvironment WebHost { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenuRepository { get; }

        public MasterItemMenusController(IRepository<MasterItemMenu> _masterItemMenuRepository , UserManager<IdentityUser> userManager , IWebHostEnvironment webHost ,IRepository<MasterCategoryMenu> _masterCategoryMenuRepository)
        {
            MasterItemMenuRepository = _masterItemMenuRepository;
            UserManager = userManager;
            WebHost = webHost;
            MasterCategoryMenuRepository = _masterCategoryMenuRepository;
        }
        // GET: MasterItemMenusController
        public ActionResult Index()
        {
            return View(MasterItemMenuRepository.View());
        }

     

        // GET: MasterItemMenusController/Create
        public ActionResult Create()
        {
            var categories = MasterCategoryMenuRepository.View();  // Ensure this returns a list of categories
            if (categories == null || !categories.Any())
            {
                ViewBag.Data = new List<MasterCategoryMenu>(); // Prevent null reference exception
            }
            else
            {
                ViewBag.Data = categories;
            }

            return View();
        }

        // POST: MasterItemMenusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MVMasterItemMenu collection)
        {
            try
            {
                string ImageUrl = SaveImage(collection.File);
                MasterItemMenu masterItemMenu = new MasterItemMenu()
                {
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,   
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterItemMenuImageUrl = ImageUrl,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    CreateId = UserManager.GetUserId(User),

                };  

                MasterItemMenuRepository.Add(masterItemMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenusController/Edit/5
        public ActionResult Edit(int id)
        {
            var categories = MasterCategoryMenuRepository.View();  // Ensure this returns a list of categories
            if (categories == null || !categories.Any())
            {
                ViewBag.Data = new List<MasterCategoryMenu>(); // Prevent null reference exception
            }
            else
            {
                ViewBag.Data = categories;
            }



            var data = MasterItemMenuRepository.Find(id);
            var newData = new MVMasterItemMenu()
            {
                MasterItemMenuId = data.MasterItemMenuId,
                MasterCategoryMenuId = data.MasterCategoryMenuId,
                MasterItemMenuTitle = data.MasterItemMenuTitle,
                MasterItemMenuBreef = data.MasterItemMenuBreef,
                MasterItemMenuDesc = data.MasterItemMenuDesc,
                MasterItemMenuPrice = data.MasterItemMenuPrice,
                MasterItemMenuImageUrl = data.MasterItemMenuImageUrl,
                MasterItemMenuDate = data.MasterItemMenuDate,
            };


            return View(newData);
        }

        // POST: MasterItemMenusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MVMasterItemMenu collection)
        {
            try
            {
                string ImageUrl = SaveImage(collection.File);

                if (ImageUrl == "")
                {
                    ImageUrl = collection.MasterItemMenuImageUrl;
                }

                var data = new MasterItemMenu()
                {
                    MasterItemMenuId = collection.MasterItemMenuId,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuImageUrl = ImageUrl,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    CreateId = UserManager.GetUserId(User),
                };
                MasterItemMenuRepository.Update(id,data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenusController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete != 0)
            {
                MasterItemMenuRepository.Delete(idDelete, new Models.MasterItemMenu());
            }
            return RedirectToAction(nameof(Index));
        }

      
       

        public ActionResult Active(int Id)
        {
            MasterItemMenuRepository.Active(Id);

            return RedirectToAction(nameof(Index));

        }


        string SaveImage(IFormFile File)
        {
            string ImageUrl = "";
            if (File != null)
            {
                //"C://wwroot/Image"+ "/Image"
                string PatheImage = Path.Combine(WebHost.WebRootPath + "/Images");
                FileInfo f = new FileInfo(File.FileName);
                ImageUrl = "Images_" + Guid.NewGuid().ToString() + f.Extension;
                string FullPath = Path.Combine(PatheImage, ImageUrl);

                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageUrl;
        }

    }
}
