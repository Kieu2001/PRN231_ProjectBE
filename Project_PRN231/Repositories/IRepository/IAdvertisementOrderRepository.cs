using Project_PRN231.Models;

namespace Project_PRN231.Repositories.IRepository
{
    public interface IAdvertisementOrderRepository
    {
        AdvertisementOrder GetAdvertisementOrderById(int Id);
        void InsertAdvertisementOrder(AdvertisementOrder advertisementOrder);
    }
}
