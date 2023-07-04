using Project_PRN231.DataAccess;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        public Advertisement GetAdByAmount(long amount) => AdvertisementManagement.Instance.GetAdByAmount(amount);
    }
}
