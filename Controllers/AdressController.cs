using UsingEntityFramework.Data;

namespace UsingEntityFramework.Controllers
{
    internal class AdressController
    {
        internal static Dictionary<int, string> ListGetAdresses()
        {
            //Dictionary to hold available adresses
            Dictionary<int, string> adressDict = new Dictionary<int, string>();

            using (UnitOfWork unitOfWork = new UnitOfWork(new FbgGymnDbContext()))
            {
                var availableAdresses = unitOfWork.Adresses.GetAll().OrderBy(x => x.AdressId);

                foreach (var currentAdress in availableAdresses)
                {
                    adressDict.Add(currentAdress.AdressId, $"{currentAdress.AdressStreet}\n{currentAdress.AdressPostalcode} {currentAdress.AdressCity}");
                    Console.WriteLine($"Id: {currentAdress.AdressId} Adress:\n{currentAdress.AdressStreet}\n{currentAdress.AdressPostalcode} {currentAdress.AdressCity}\n");
                }
            }

            return adressDict;
        }
    }
}
