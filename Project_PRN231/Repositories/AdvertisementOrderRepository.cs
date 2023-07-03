using Project_PRN231.DataAccess;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Repositories
{
    public class AdvertisementOrderRepository : IAdvertisementOrderRepository
    {
        public AdvertisementOrder GetAdvertisementOrderById(int Id) => AdvertisementOrderManagement.Instance.GetAdOrderById(Id);
        public void InsertAdvertisementOrder(AdvertisementOrder advertisementOrder) => AdvertisementOrderManagement.Instance.AddAdvertisement(advertisementOrder);



    }
}
