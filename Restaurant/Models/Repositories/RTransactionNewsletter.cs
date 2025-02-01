
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class RTransactionNewsletter : IRepository<TransactionNewsletter>
    {
        private readonly AppDbContext db;

        public RTransactionNewsletter(AppDbContext _db)
        {
            db = _db;
        }
        

        public void Active(int Id)
        {
            throw new NotImplementedException();
        }

        public void Add(TransactionNewsletter entity)
        {

            entity.CreateId = "1";
            entity.EditId = "1";
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;

            entity.TransactionNewsletterEmail = entity.TransactionNewsletterEmail;


            db.TransactionNewsletters.Add(entity);
            db.SaveChanges();

        }

        public void Delete(int Id, TransactionNewsletter entity)
        {
            throw new NotImplementedException();
        }

        public TransactionNewsletter Find(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, TransactionNewsletter entity)
        {
            throw new NotImplementedException();
        }

        public List<TransactionNewsletter> View()
        {
            return db.TransactionNewsletters.ToList();
        }

        public List<TransactionNewsletter> ViewClient()
        {
            return db.TransactionNewsletters.ToList();
        }
    }
}
