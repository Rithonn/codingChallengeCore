using System;
using System.Collections.Generic;

namespace BreweryAPI.Models
{
    public partial class Brewery
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string BreweryType { get; set; } = null!;
        public string? Street { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string City { get; set; } = null!;
        public string? State { get; set; }
        public string? CountyProvince { get; set; }
        public string PostalCode { get; set; } = null!;
        public string? WebsiteUrl { get; set; }
        public string? Phone { get; set; }
        public string Country { get; set; } = null!;
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string? Tags { get; set; }
        public int? Testing { get; set; }
        public int BreweryId { get; set; }
    }
}
