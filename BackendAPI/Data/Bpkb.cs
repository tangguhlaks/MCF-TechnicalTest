using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Data
{
    [Table("tr_bpkb")]
    public class Bpkb
    {
        [Key]
        [MaxLength(100)]
        public string agreement_number { get; set; }

        [MaxLength(100)]
        public string bpkb_no { get; set; }

        [MaxLength(10)]
        public string branch_id { get; set; }

        public DateTime bpkb_date { get; set; }

        [MaxLength(100)]
        public string faktur_no { get; set; }

        public DateTime faktur_date { get; set; }

        [MaxLength(10)]
        [ForeignKey("ms_storage_location")]
        public string location_id { get; set; }

        [MaxLength(20)]
        public string police_no { get; set; }

        public DateTime bpkb_date_in { get; set; }

        [MaxLength(20)]
        public string created_by { get; set; }

        public DateTime created_on { get; set; }

        [MaxLength(20)]
        public string last_updated_by { get; set; }

        public DateTime last_updated_on { get; set; }
    }
}
