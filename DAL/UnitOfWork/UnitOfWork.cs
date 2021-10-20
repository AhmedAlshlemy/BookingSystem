using DAL.DataContext;
using DAL.Entities;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context ;
        private GenericRepository<Resource> _resourceRepository;
        private GenericRepository<Booking> _bookingRepository;
       
        public UnitOfWork(DataBaseContext context)
        { _context = context; }
        public GenericRepository<Resource> ResourceRepository
        {
            get { return _resourceRepository ??= new GenericRepository<Resource>(_context); }
        }
        public GenericRepository<Booking> BookingRepository
        {
            get { return _bookingRepository ??= new GenericRepository<Booking>(_context); }
        }

        public void Commit()
        { _context.SaveChanges(); }

        public void Rollback()
        { _context.Dispose(); }
    }
}
