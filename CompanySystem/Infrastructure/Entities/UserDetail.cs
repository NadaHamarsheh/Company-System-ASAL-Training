using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.SharedFiles;

namespace Infrastructure
{
    [Table("UserDetail")]
    public class UserDetail : TrackingData
	{
		[Key]
		public int Id { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [Column("Photo", TypeName = "image")]
        public byte[] Photo { get; set; }

        [MaxLength(40)]
        public string Address { get; set; }

        [MaxLength(15)]
        public string Tel { get; set; }

        [MaxLength(40)]
        public string Experience { get; set; }
        
        public User Users { get; set; }
    }
}