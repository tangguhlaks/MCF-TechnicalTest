using BackendAPI.Data;

namespace BackendAPI.Repository
{
    public interface IMasterRepositroy
    {
        User? GetUserByUsername(string username);
        StorageLocation? GetStorageLocationById(string location_id);
        List<StorageLocation>? GetStorageLocation();
    }
}
