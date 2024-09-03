using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace BackendAPI.Data
{
    [Table("ms_storage_location")]
    public class StorageLocation
    {
        [Key]
        [MaxLength(10)]
        public string location_id { get; set; }
        [MaxLength(100)]
        public string location_name {  get; set; }
    }
}
