using System;

namespace Pricing.Models.RequestModels
{
    public class GetPriceRequestModel
    {
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
