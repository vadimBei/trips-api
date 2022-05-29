using AutoMapper;
using Trips.Core.Domain.Models;

namespace Trips.Core.Application.Common.ViewModels
{
    [AutoMap(typeof(Employee))]
    public class TripParticipantVM
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
