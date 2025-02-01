using Microsoft.AspNetCore;
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
    public class MasterSliderController : Controller
    {
        public IRepository<MasterSlider> MasterSliderRepository { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IWebHostEnvironment WebHost { get; }

        public MasterSliderController(IRepository<MasterSlider> _masterSliderRepository , UserManager<IdentityUser> userManager , IWebHostEnvironment webHost)
        {
            MasterSliderRepository = _masterSliderRepository;
            UserManager = userManager;
            WebHost = webHost;
        }
        // GET: MasterSliderController
        public ActionResult Index()
        {
            return View(MasterSliderRepository.View());
        }


        // GET: MasterSliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MVMasterSlider collection)
        {
            try
            {

                string ImageUrl = SaveImage(collection.File);

                MasterSlider masterSlider = new MasterSlider()
                {
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderUrl = ImageUrl,
                    CreateId = UserManager.GetUserId(User),
                };
                MasterSliderRepository.Add(masterSlider);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController/Edit/5
        public ActionResult Edit(int id)
        {
            var Data = MasterSliderRepository.Find(id);
            var newdata = new MVMasterSlider()
            {
                MasterSliderId = Data.MasterSliderId,
                MasterSliderTitle = Data.MasterSliderTitle,
                MasterSliderBreef = Data.MasterSliderBreef,
                MasterSliderDesc = Data.MasterSliderDesc,
                MasterSliderUrl = Data.MasterSliderUrl,
            };
            
            return View(newdata);
        }

        // POST: MasterSliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MVMasterSlider collection)
        {
            try
            {

                string ImageUrl = SaveImage(collection.File);

                if (ImageUrl == "")
                {
                    ImageUrl = collection.MasterSliderUrl;
                }

                var masterSlider = new MasterSlider()
                {
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderUrl = ImageUrl,
                    EditId = UserManager.GetUserId(User),
                };

                MasterSliderRepository.Update(id, masterSlider);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete != 0)
            {
                MasterSliderRepository.Delete(idDelete, new Models.MasterSlider());
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int Id)
        {
            MasterSliderRepository.Active(Id);

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
