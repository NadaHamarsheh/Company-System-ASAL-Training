using Infrastructure.SharedFiles;

namespace Business.View
{
	public class UserDetailView : TrackingData
	{
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] Photo { get; set; }

        public string Address { get; set; }

        public string Tel { get; set; }

        public string Experience { get; set; }
    }
}