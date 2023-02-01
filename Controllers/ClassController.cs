using UsingEntityFramework.Data;

namespace UsingEntityFramework.Controllers
{
    internal class ClassController
    {
        internal static Dictionary<int, string> ListGetClasses()
        {
            //Dictionary to hold available classes
            Dictionary<int, string> classDict = new Dictionary<int, string>();

            using (UnitOfWork unitOfWork = new UnitOfWork(new FbgGymnDbContext()))
            {
                var availableClasses = unitOfWork.Classes.GetAll()
                    .OrderBy(x => x.ClassId);

                foreach (var currentClass in availableClasses)
                {
                    classDict.Add(currentClass.ClassId, currentClass.ClassName);
                    Console.WriteLine($"Id: {currentClass.ClassId} Class: {currentClass.ClassName}");
                }
            }

            return classDict;
        }
    }
}
