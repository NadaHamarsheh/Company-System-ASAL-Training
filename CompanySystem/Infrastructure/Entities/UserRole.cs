using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.SharedFiles;

namespace Infrastructure
{
    [Table("UserRole")]
    public class UserRole : TrackingData
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(40)]
		public string Name { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}