using Infrastructure.SharedFiles;

namespace Business.View
{
	public class EmployeeDetailView : TrackingData
	{
        public int Id { get; set; }

        public double Salary { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DepartmentId { get; set; }
    }
}