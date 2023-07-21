using Project_PRN231.DTO;
using Project_PRN231.Models;

namespace Project_PRN231.Repositories.IRepository
{
    public interface IAdvertisementOrderRepository
    {
        AdvertisementOrder GetAdvertisementOrderById(int Id);
        void InsertAdvertisementOrder(AdvertisementOrder advertisementOrder);
        void UpdateAdvertisementOrder(AdvertisementOrder adOrder);
        AdvertisementOrder GetAdOrderByOrder(DateTime date);
        IEnumerable<AdvertisementOrderDTO> GetAdOrderByApprove();
        void DeletetAdvertisementOrder(int id);
    }
}
