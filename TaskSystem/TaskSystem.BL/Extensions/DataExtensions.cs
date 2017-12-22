using TaskSystem.DL;
using TaskSystem.DL.Entities;

namespace TaskSystem.BL.Extensions
{
    public static class DataExtensions
    {
        public static void DeleteById<T>(this AppDbContext _db, long id) where T : class, IPkidEntity
        {
            _db.Delete<T>(x => x.Id == id);
            _db.SaveChanges();
        }

    }
}