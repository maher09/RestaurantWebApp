
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class RTransactionContactU : IRepository<TransactionContactU>
    {
        private readonly AppDbContext db;

        public RTransactionContactU(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            throw new NotImplementedException();
        }

        public void Add(TransactionContactU entity)
        {
            entity.CreateId = "1";
            entity.EditId = "1";
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;

            entity.TransactionContactUsEmail = entity.TransactionContactUsEmail;
            entity.TransactionContactUsFullName = entity.TransactionContactUsFullName;
            entity.TransactionContactUsMessage = entity.TransactionContactUsMessage;
            entity.TransactionContactUsSubject = entity.TransactionContactUsSubject;
            


            db.TransactionContactUs.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionContactU entity)
        {
            throw new NotImplementedException();
        }

        public TransactionContactU Find(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, TransactionContactU entity)
        {
            throw new NotImplementedException();
        }

        public List<TransactionContactU> View()
        {
            return db.TransactionContactUs.Where(x => x.IsDelete == false).ToList();
        }

        public List<TransactionContactU> ViewClient()
        {
            return db.TransactionContactUs.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
