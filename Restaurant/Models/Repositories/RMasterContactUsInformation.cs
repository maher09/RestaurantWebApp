
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class RMasterContactUsInformation : IRepository<MasterContactUsInformation>
    {
        private readonly AppDbContext db;

        public RMasterContactUsInformation(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var Data = Find(Id);
            Data.IsActive = !Data.IsActive;

            Data.EditDate = DateTime.Now;
            db.MasterContactUsInformations.Update(Data);
            db.SaveChanges();
        }

        public void Add(MasterContactUsInformation entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            entity.CreateId = "1";
            entity.EditId = "1";
            db.MasterContactUsInformations.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterContactUsInformation entity)
        {
            var Data = Find(Id);
            Data.IsDelete = true;

            Data.EditDate = DateTime.Now;
            db.MasterContactUsInformations.Update(Data);
            db.SaveChanges();
        }

        public MasterContactUsInformation Find(int Id)
        {
            return db.MasterContactUsInformations.SingleOrDefault(x => x.MasterContactUsInformationId == Id);
        }

        public void Update(int Id, MasterContactUsInformation entity)
        {
            var Data = Find(Id);
            Data.MasterContactUsInformationIdesc = entity.MasterContactUsInformationIdesc;
            Data.MasterContactUsInformationImageUrl = entity.MasterContactUsInformationImageUrl;
            Data.MasterContactUsInformationRedirect = entity.MasterContactUsInformationRedirect;

            

            Data.EditDate = DateTime.Now;
            db.MasterContactUsInformations.Update(Data);
            db.SaveChanges();
        }

        public List<MasterContactUsInformation> View()
        {
            return db.MasterContactUsInformations.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterContactUsInformation> ViewClient()
        {
            return db.MasterContactUsInformations.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
