using BackendAPI.Context;
using BackendAPI.Data;

namespace BackendAPI.Repository
{
    public class MasterRepository : IMasterRepositroy
    {
        private ApplicationDbContext _context;
        public MasterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region User
        public User? GetUserByUsername(string username)
        {
            try
            {
                User user = _context.Users.Where(x => x.user_name.Equals(username)).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        #endregion

        public List<StorageLocation>? GetStorageLocation()
        {
            try
            {
                List<StorageLocation> locations = _context.StorageLocations.ToList();
                return locations;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public StorageLocation? GetStorageLocationById(string location_id)
        {
            try
            {
                StorageLocation location = _context.StorageLocations.Where(x => x.location_id.Equals(location_id)).FirstOrDefault();
                return location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

    }
}
