
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class RMasterService : IRepository<MasterService>
    {
        private readonly AppDbContext db;

        public RMasterService(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            var Data = Find(Id);
            Data.IsActive = !Data.IsActive;

            Data.EditDate = DateTime.Now;
            db.MasterServices.Update(Data);
            db.SaveChanges();
        }

        public void Add(MasterService entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            entity.EditId = "1";
            entity.CreateId = "1";

            db.MasterServices.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterService entity)
        {
            var Data = Find(Id);
            Data.IsDelete = true;

            Data.EditDate = DateTime.Now;
            db.MasterServices.Update(Data);
            db.SaveChanges();
        }

        public MasterService Find(int Id)
        {
            return db.MasterServices.SingleOrDefault(x => x.MasterServiceId == Id);
        }

        public void Update(int Id, MasterService entity)
        {
            var Data = Find(Id);

            Data.IsActive = entity.IsActive;
            Data.IsDelete = entity.IsDelete;

            Data.MasterServicesTitle = entity.MasterServicesTitle;
            Data.MasterServicesDesc = entity.MasterServicesDesc;
            Data.MasterServicesImage = entity.MasterServicesImage;
            Data.EditDate = DateTime.Now;
            db.MasterServices.Update(Data);
            db.SaveChanges();
        }

        public List<MasterService> View()
        {
            return db.MasterServices.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterService> ViewClient()
        {
            return db.MasterServices.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
