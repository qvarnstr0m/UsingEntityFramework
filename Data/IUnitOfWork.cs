using UsingEntityFramework.Repositories;

namespace UsingEntityFramework.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        IClassRepository Classes { get; }
        IAdressRepository Adresses { get; }
        ICourseRepository Courses { get; }
        int Save();
    }
}
