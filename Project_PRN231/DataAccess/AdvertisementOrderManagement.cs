using Project_PRN231.DTO;
using Project_PRN231.Models;

namespace Project_PRN231.DataAccess
{
    public class AdvertisementOrderManagement
    {

        private static AdvertisementOrderManagement instance = null;
        private static readonly object instanceLock = new object();
        private AdvertisementOrderManagement() { }
        public static AdvertisementOrderManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AdvertisementOrderManagement();
                    }
                    return instance;
                }
            }
        }
        public AdvertisementOrder GetAdOrderById(int AdId)
        {
            AdvertisementOrder? rp = null;
            try
            {
                var db = new PRN231_SUContext();
                rp = db.AdvertisementOrders.SingleOrDefault(x => x.Id == AdId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rp;
        }
        public AdvertisementOrder GetAdOrderByOrder(DateTime date)
        {
            AdvertisementOrder? rp = null;
            try
            {
                var db = new PRN231_SUContext();
                rp = db.AdvertisementOrders.SingleOrDefault(x => x.CreatedDate == date);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rp;
        }

        public IEnumerable<AdvertisementOrderDTO> GetAdOrderByApprove()
        {
            List<AdvertisementOrderDTO> list = new List<AdvertisementOrderDTO>();
            try
            {
                var db = new PRN231_SUContext();
                list = (from c in db.AdvertisementOrders
                        join a in db.Advertisements on c.AdvertisementId equals a.Id
                        join u in db.Users on c.UserId equals u.Id
                        where c.IsApprove == false
                        select new AdvertisementOrderDTO
                        {
                            Id = c.Id,
                            Username = u.FullName,
                            UserId = u.Id,
                            Title = c.Title,
                            Image = c.Image,
                            AdType = (long)a.Price,
                            CreatedDate = (DateTime)c.CreatedDate,
                            EndDate = (DateTime)c.EndDate,
                            Description = c.Description


                        }
                        ).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public void AddAdvertisement(AdvertisementOrder ad)
        {
            try
            {
                AdvertisementOrder rp = GetAdOrderById(ad.Id);
                if (rp == null)
                {
                    var db = new PRN231_SUContext();
                    db.AdvertisementOrders.Add(ad);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This ad is already done");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateAdvertisementOrder(AdvertisementOrder adOrder)
        {
            try
            {
                var db = new PRN231_SUContext();
                var existingAdOrder = db.AdvertisementOrders.SingleOrDefault(x => x.Id == adOrder.Id);

                if (existingAdOrder != null)
                {
                    existingAdOrder.IsPending = adOrder.IsPending;
                    existingAdOrder.IsApprove = adOrder.IsApprove;

                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Advertisement order not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                AdvertisementOrder rp = GetAdOrderById(id);
                if (rp != null)
                {
                    var db = new PRN231_SUContext();
                    db.AdvertisementOrders.Remove(rp);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This AdOrder does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
