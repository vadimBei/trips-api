using Algolia.Core.Domain.Models;
using AutoMapper;

namespace Algolia.Core.Application.Common.ViewModels
{
    [AutoMap(typeof(Location))]
    public class LocationVM
    {
        public string ObjectID { get; set; }
        public string Administrative { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public List<string> County { get; set; }
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
