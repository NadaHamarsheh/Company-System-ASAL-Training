using Infrastructure.SharedFiles;

namespace Business.View
{
	public class UserView : TrackingData
	{
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int UserRoleId { get; set; }

        public int UserDetailId { get; set; }

        public int EmployeeDetailId { get; set; }
    }
}

