
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class RMasterOffer : IRepository<MasterOffer>
    {
        private readonly AppDbContext db;

        public RMasterOffer(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var Data = Find(Id);
            Data.IsActive = !Data.IsActive;

            Data.EditDate = DateTime.Now;
            db.MasterOffers.Update(Data);
            db.SaveChanges();
        }

        public void Add(MasterOffer entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            entity.CreateId = "1";
            entity.EditId = "1";
            db.MasterOffers.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterOffer entity)
        {
            var Data = Find(Id);
            Data.IsDelete = true;

            Data.EditDate = DateTime.Now;
            db.MasterOffers.Update(Data);
            db.SaveChanges();
        }

        public MasterOffer Find(int Id)
        {
            return db.MasterOffers.SingleOrDefault(x => x.MasterOfferId == Id);
        }

        public void Update(int Id, MasterOffer entity)
        {
        
            var Data = Find(Id);

            Data.MasterOfferTitle = entity.MasterOfferTitle;
            Data.MasterOfferDesc = entity.MasterOfferDesc;
            Data.MasterOfferImageUrl = entity.MasterOfferImageUrl;
            Data.MasterOfferBreef = entity.MasterOfferBreef;
            

            Data.EditDate = DateTime.Now;
            db.MasterOffers.Update(Data);
            db.SaveChanges();
        }

        public List<MasterOffer> View()
        {
            return db.MasterOffers.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterOffer> ViewClient()
        {
            return db.MasterOffers.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
