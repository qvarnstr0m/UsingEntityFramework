using UsingEntityFramework.Repositories;

namespace UsingEntityFramework.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FbgGymnDbContext _context;
        public IStudentRepository Students { get; private set; }
        public IClassRepository Classes { get; private set; }
        public IAdressRepository Adresses { get; private set; }
        public ICourseRepository Courses { get; private set; }

        public UnitOfWork(FbgGymnDbContext context)
        {
            _context = context;
            Students = new StudentRepository(_context);
            Classes = new ClassRepository(_context);
            Adresses = new AdressRepository(_context);
            Courses = new CourseRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
