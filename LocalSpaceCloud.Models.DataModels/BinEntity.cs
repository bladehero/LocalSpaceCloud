using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalSpaceCloud.Models.DataModels
{
    public class BinEntity
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string RestorePath { get; set; }
        public DateTime DeletedAt { get; set; } = DateTime.Now;

        public SystemEntityType SystemEntityType { get; set; }
        [ForeignKey(nameof(SystemEntityType))]
        public SystemEntityTypeValue SystemEntityTypeValue { get; set; }

        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
    }
}
