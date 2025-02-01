
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class RMasterPartner : IRepository<MasterPartner>
    {
        private readonly AppDbContext db;

        public RMasterPartner(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var Data = Find(Id);
            Data.IsActive = !Data.IsActive;

            Data.EditDate = DateTime.Now;
            db.MasterPartners.Update(Data);
            db.SaveChanges();
        }

        public void Add(MasterPartner entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            entity.CreateId = "1";
            entity.EditId = "1";

            db.MasterPartners.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterPartner entity)
        {
            var Data = Find(Id);
            Data.IsDelete = true;

            Data.EditDate = DateTime.Now;
            db.MasterPartners.Update(Data);
            db.SaveChanges();
        }

        public MasterPartner Find(int Id)
        {
            return db.MasterPartners.SingleOrDefault(x => x.MasterPartnerId == Id);
        }

        public void Update(int Id, MasterPartner entity)
        {
            var Data = Find(Id);

           
            Data.MasterPartnerName = entity.MasterPartnerName;
            Data.MasterPartnerLogoImageUrl = entity.MasterPartnerLogoImageUrl;
            Data.MasterPartnerWebsiteUrl = entity.MasterPartnerWebsiteUrl;



            Data.EditDate = DateTime.Now;
            db.MasterPartners.Update(Data);
            db.SaveChanges();
        }

        public List<MasterPartner> View()
        {
            return db.MasterPartners.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterPartner> ViewClient()
        {
            return db.MasterPartners.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
