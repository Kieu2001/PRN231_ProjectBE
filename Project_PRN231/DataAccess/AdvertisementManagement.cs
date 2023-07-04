using Project_PRN231.Models;

namespace Project_PRN231.DataAccess
{
    public class AdvertisementManagement
    {
        private static AdvertisementManagement instance = null;
        private static readonly object instanceLock = new object();
        private AdvertisementManagement() { }
        public static AdvertisementManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AdvertisementManagement();
                    }
                    return instance;
                }
            }
        }
        public Advertisement GetAdByAmount(long amount)
        {
            Advertisement? rp = null;
            try
            {
                var db = new PRN231_SUContext();
                rp = db.Advertisements.SingleOrDefault(x => x.Price == amount);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rp;
        }
    }
}
