using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocalSpaceCloud.Models.DataModels
{
    public enum SystemEntityType
    {
        [Description("File system cataloging structure which contains references to other computer files, and possibly other directories")]
        Directory,
        [Description("Computer resource for recording data discretely in a computer storage device")]
        File,
        [Description("An archive is an accumulation of historical records")]
        Archive
    }

    public class SystemEntityTypeValue
    {
        [Key]
        public SystemEntityType ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
