using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Restaurant.Areas.Admin.ViewModel;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllrers
{
    [Area("admin")]
    public class MasterSocialMediumController : Controller
    {
        public IRepository<MasterSocialMedium> MasterSocialMediumRepository { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IWebHostEnvironment WebHost { get; }

        public MasterSocialMediumController(IRepository<MasterSocialMedium> _masterSocialMediumRepository , UserManager<IdentityUser> userManager, IWebHostEnvironment webHost)
        {
            MasterSocialMediumRepository = _masterSocialMediumRepository;
            UserManager = userManager;
            WebHost = webHost;
        }
        // GET: MasterSocialMediumController
        public ActionResult Index()
        {
            return View(MasterSocialMediumRepository.View());
        }

      

        // GET: MasterSocialMediumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSocialMediumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MVMasterSocialMedium collection)
        {
            try
            {
                string ImageUrl = SaveImage(collection.File);

                MasterSocialMedium masterSocialMedium = new MasterSocialMedium()
                {
                    MasterSocialMediaImageUrl = ImageUrl,
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl,
                    CreateId = UserManager.GetUserId(User),
                };
                MasterSocialMediumRepository.Add(masterSocialMedium);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediumController/Edit/5
        public ActionResult Edit(int id)
        {
            var Data = MasterSocialMediumRepository.Find(id);
            var newData = new MVMasterSocialMedium()
            {
                MasterSocialMediumId = Data.MasterSocialMediumId,
                MasterSocialMediaImageUrl = Data.MasterSocialMediaImageUrl,
                MasterSocialMediaUrl = Data.MasterSocialMediaUrl,
            };

            return View(newData);
        }

        // POST: MasterSocialMediumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MVMasterSocialMedium collection)
        {
            try
            {
                string ImageUrl = SaveImage(collection.File);

                if (ImageUrl == "")
                {
                    ImageUrl = collection.MasterSocialMediaImageUrl;
                }

                var data = new MasterSocialMedium()
                {
                    MasterSocialMediumId = collection.MasterSocialMediumId,
                    MasterSocialMediaImageUrl = ImageUrl,
                    MasterSocialMediaUrl = collection.MasterSocialMediaUrl,
                    CreateId = UserManager.GetUserId(User),
                };

                MasterSocialMediumRepository.Update(id,data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediumController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete != 0)
            {
                MasterSocialMediumRepository.Delete(idDelete, new Models.MasterSocialMedium());
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int Id)
        {
            MasterSocialMediumRepository.Active(Id);

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
