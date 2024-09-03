using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace BackendAPI.Data
{
    [Table("ms_user")]
    public class User
    {
        [Key]
        public long user_id { get; set; }
        [MaxLength(20)]
        public string user_name {  get; set; }
        [MaxLength(50)]
        public string password { get; set;}
        public bool is_active { get; set; }
    }
}
