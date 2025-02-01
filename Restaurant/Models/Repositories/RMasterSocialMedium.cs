
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class RMasterSocialMedium : IRepository<MasterSocialMedium>
    {
        private readonly AppDbContext db;

        public RMasterSocialMedium(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var Data = Find(Id);
            Data.IsActive = !Data.IsActive;

            Data.EditDate = DateTime.Now;
            db.MasterSocialMedia.Update(Data);
            db.SaveChanges();
        }

        public void Add(MasterSocialMedium entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            entity.CreateId = "1";
            entity.EditId = "1";

            db.MasterSocialMedia.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterSocialMedium entity)
        {
            var Data = Find(Id);
            Data.IsDelete = true;

            Data.EditDate = DateTime.Now;
            db.MasterSocialMedia.Update(Data);
            db.SaveChanges();
        }

        public MasterSocialMedium Find(int Id)
        {
            return db.MasterSocialMedia.SingleOrDefault(x => x.MasterSocialMediumId == Id);
        }

        public void Update(int Id, MasterSocialMedium entity)
        {
            var Data = Find(Id);

            Data.MasterSocialMediaImageUrl = entity.MasterSocialMediaImageUrl;
            Data.MasterSocialMediaUrl = entity.MasterSocialMediaUrl;

            Data.EditDate = DateTime.Now;
            db.MasterSocialMedia.Update(Data);
            db.SaveChanges();
        }

        public List<MasterSocialMedium> View()
        {
            return db.MasterSocialMedia.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSocialMedium> ViewClient()
        {
            return db.MasterSocialMedia.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
