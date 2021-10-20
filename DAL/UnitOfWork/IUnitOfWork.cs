using DAL.Entities;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        GenericRepository<Resource> ResourceRepository { get; }
        GenericRepository<Booking> BookingRepository { get; }
        void Commit();
        void Rollback();
    }
}
