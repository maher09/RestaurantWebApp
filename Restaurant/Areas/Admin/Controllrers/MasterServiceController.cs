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
    public class MasterServiceController : Controller
    {
        public IRepository<MasterService> MasterServiceRepository { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IWebHostEnvironment WebHost { get; }

        public MasterServiceController(IRepository<MasterService> _masterServiceRepository , UserManager<IdentityUser> userManager, IWebHostEnvironment webHost) 
        {
            MasterServiceRepository = _masterServiceRepository;
            UserManager = userManager;
            WebHost = webHost;
        }
        // GET: MasterServiceController
        public ActionResult Index()
        {
            return View(MasterServiceRepository.View());
        }

     
        // GET: MasterServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MVMasterService collection)
        {
            try
            {
                //string ImageUrl = SaveImage(collection.File);

                MasterService masterService = new MasterService()
                {
                    MasterServicesTitle = collection.MasterServicesTitle,
                    MasterServicesDesc = collection.MasterServicesDesc,
                    MasterServicesImage = collection.MasterServicesImage,
                    CreateId = UserManager.GetUserId(User),
                };
                MasterServiceRepository.Add(masterService);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            var Data = MasterServiceRepository.Find(id);
            var newdata = new MVMasterService()
            {
                MasterServiceId = Data.MasterServiceId,
                MasterServicesTitle = Data.MasterServicesTitle,
                MasterServicesDesc = Data.MasterServicesDesc,
                MasterServicesImage = Data.MasterServicesImage,
            };
            return View(newdata);
        }

        // POST: MasterServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MVMasterService collection)
        {
            try
            {
                //string ImageUrl = SaveImage(collection.File);

                //if (ImageUrl == "")
                //{
                //    ImageUrl = collection.MasterServicesImage;
                //}
                var masterService = new MasterService()
                {
                    MasterServiceId = collection.MasterServiceId,
                    MasterServicesTitle = collection.MasterServicesTitle,
                    MasterServicesDesc = collection.MasterServicesDesc,
                    MasterServicesImage = collection.MasterServicesImage,
                    CreateId = UserManager.GetUserId(User),
                };
                MasterServiceRepository.Update(id, masterService);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServiceController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete != 0)
            {
                MasterServiceRepository.Delete(idDelete, new Models.MasterService());
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int Id)
        {
            MasterServiceRepository.Active(Id);

            return RedirectToAction(nameof(Index));

        }


        //string SaveImage(IFormFile File)
        //{
        //    string ImageUrl = "";
        //    if (File != null)
        //    {
        //        //"C://wwroot/Image"+ "/Image"
        //        string PatheImage = Path.Combine(WebHost.WebRootPath + "/Images");
        //        FileInfo f = new FileInfo(File.FileName);
        //        ImageUrl = "Images_" + Guid.NewGuid().ToString() + f.Extension;
        //        string FullPath = Path.Combine(PatheImage, ImageUrl);

        //        File.CopyTo(new FileStream(FullPath, FileMode.Create));
        //    }
        //    return ImageUrl;
        //}

    }
}
