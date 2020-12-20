using System.ComponentModel.DataAnnotations;

namespace LocalSpaceCloud.Models.DataModels
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
