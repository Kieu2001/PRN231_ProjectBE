using Project_PRN231.DataAccess;
using Project_PRN231.DTO;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Repositories
{
    public class AdvertisementOrderRepository : IAdvertisementOrderRepository
    {
        public IEnumerable<AdvertisementOrder> advertisementOrdersByUserId(int id) => AdvertisementOrderManagement.Instance.advertisementOrdersByUserId(id);



        public void DeletetAdvertisementOrder(int id) => AdvertisementOrderManagement.Instance.Delete(id);

        public IEnumerable<AdvertisementOrderDTO> GetAdOrderByApprove() => AdvertisementOrderManagement.Instance.GetAdOrderByApprove();

        public AdvertisementOrder GetAdOrderByOrder(DateTime date) => AdvertisementOrderManagement.Instance.GetAdOrderByOrder(date);
        public AdvertisementOrder GetAdvertisementOrderById(int Id) => AdvertisementOrderManagement.Instance.GetAdOrderById(Id);
        public void InsertAdvertisementOrder(AdvertisementOrder advertisementOrder) => AdvertisementOrderManagement.Instance.AddAdvertisement(advertisementOrder);

        public void UpdateAdvertisementOrder(AdvertisementOrder adOrder) => AdvertisementOrderManagement.Instance.UpdateAdvertisementOrder(adOrder);


    }
}
