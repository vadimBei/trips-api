using Trips.Core.Domain.Enums;

namespace Trips.Core.Application.Common.ViewModels
{
    public class TripVM
    {
        public long Id { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public DateTime ApprovedDate { get; set; }

        public string Comment { get; set; }

        public string Goal { get; set; }

        public TripType Type { get; set; }

        public TripStatus Status { get; set; }

        public TripVehicleType VehicleType { get; set; }

        public EmployeeVM Author { get; set; }

        public EmployeeVM ApprovedEmployee { get; set; }

        public List<TripLocationVM> Locations { get; set; }

        public List<TripParticipantVM> Participants { get; set; }
    }
}
