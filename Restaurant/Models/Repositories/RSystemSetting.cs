
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class RSystemSetting : IRepository<SystemSetting>
    {
        private readonly AppDbContext db;

        public RSystemSetting(AppDbContext _db)
        {
           db = _db;
        }
        public void Active(int Id)
        {
            var Data = Find(Id);
            Data.IsActive = !Data.IsActive;

            Data.EditDate = DateTime.Now;
            db.SystemSettings.Update(Data);
            db.SaveChanges();
        }

        public void Add(SystemSetting entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            entity.CreateId = "1";
            entity.EditId = "1";

            db.SystemSettings.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, SystemSetting entity)
        {
            var Data = Find(Id);
            Data.IsDelete = true;

            Data.EditDate = DateTime.Now;
            db.SystemSettings.Update(Data);
            db.SaveChanges();
        }

        public SystemSetting Find(int Id)
        {
            return db.SystemSettings.SingleOrDefault(x => x.SystemSettingId == Id);
        }

        public void Update(int Id, SystemSetting entity)
        {
            var Data = Find(Id);

            Data.SystemSettingLogoImageUrl = entity.SystemSettingLogoImageUrl;
            Data.SystemSettingLogoImageUrl2 = entity.SystemSettingLogoImageUrl2;
            Data.SystemSettingMapLocation = entity.SystemSettingMapLocation;
            Data.SystemSettingWelcomeNoteBreef  = entity.SystemSettingWelcomeNoteBreef;
            Data.SystemSettingWelcomeNoteDesc = entity.SystemSettingWelcomeNoteDesc;
            Data.SystemSettingWelcomeNoteImageUrl = entity.SystemSettingWelcomeNoteImageUrl;
            Data.SystemSettingWelcomeNoteTitle = entity.SystemSettingWelcomeNoteTitle;
            Data.SystemSettingWelcomeNoteUrl = entity.SystemSettingWelcomeNoteUrl;
            Data.SystemSettingCopyright = entity.SystemSettingCopyright;
            Data.EditId = "1";
            Data.CreateId = "1";
            Data.CreateDate = DateTime.Now;
            Data.EditDate = DateTime.Now;
            db.SystemSettings.Update(Data);
            db.SaveChanges();
        }

        public List<SystemSetting> View()
        {
            return db.SystemSettings.Where(x => x.IsDelete == false).ToList();
        }

        public List<SystemSetting> ViewClient()
        {
            return db.SystemSettings.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
