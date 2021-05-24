using System;

namespace Pricing.Models.ResponseModels
{
    public class GetPriceResponseModel
    {
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal FinalPrice { get; set; }
        public decimal WeekDaysRentalPrice { get; set; }
        public decimal WeekendDaysRentalPrice { get; set; }
        public decimal InsuranceFee { get; set; }
        public decimal SnappCarFee { get; set; }
        public decimal Discount { get; set; }
        public GetPriceStatus Availavility { get; set; }
    }

    public enum GetPriceStatus
    {
        Available,
        NotAvailableWithinDates,
        NotFound
    }
}
