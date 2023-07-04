using Project_PRN231.Models;

namespace Project_PRN231.Repositories.IRepository
{
    public interface IAdvertisementRepository
    {
        Advertisement GetAdByAmount(long amount);
    }
}
