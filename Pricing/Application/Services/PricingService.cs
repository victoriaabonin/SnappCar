using Pricing.Application.Interfaces;
using Pricing.Infrastructure.Interfaces;
using Pricing.Models.RequestModels;
using Pricing.Models.ResponseModels;
using System;
using System.Threading.Tasks;

namespace Pricing.Application.Services
{
    public class PricingService : IPricingService
    {
        private readonly ISnappetGarageIntegration _snappetGarageIntegration;

        public PricingService(ISnappetGarageIntegration snappetGarageIntegration)
        {
            _snappetGarageIntegration = snappetGarageIntegration;
        }

        // In the assignment it's not very clear which rules has priority.
        // For example, is the discount applied over the insurance and/or the Snappcar addition?
        public async Task<GetPriceResponseModel> GetPrice(GetPriceRequestModel GetPriceRequestModel)
        {
            var response = new GetPriceResponseModel
            {
                CarId = GetPriceRequestModel.CarId,
                StartDate = GetPriceRequestModel.StartDate,
                EndDate = GetPriceRequestModel.EndDate
            };

            // try to fetch the car

            var snappetCar = await _snappetGarageIntegration.GetSnappetCar(GetPriceRequestModel.CarId);

            if (snappetCar == default)
            {
                response.Availavility = GetPriceStatus.NotFound;
                return response;
            }

            // TODO check if car is available in the given dates
            if (false)
            {
                response.Availavility = GetPriceStatus.NotAvailableWithinDates;
                return response;
            }

            // car is available
            response.Availavility = GetPriceStatus.Available;

            // gets the amount of days and weekend days the customer is trying to book the car for
            int rentalDays = 0;
            int weekDays = 0;
            int weekendDays = 0;
            var startDay = GetPriceRequestModel.StartDate.Date;

            while (startDay <= GetPriceRequestModel.EndDate.Date)
            {
                rentalDays++;
                if (startDay.DayOfWeek == DayOfWeek.Saturday ||
                    startDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    weekendDays++;
                }
                else
                {
                    weekDays++;
                }

                startDay = startDay.AddDays(1);
            }

            decimal finalPrice = 0;

            // calculate the value of all weekdays without any fees
            var weekDaysRentalPrice = weekDays * snappetCar.DailyPrice;

            // calculate the value of all weekenddays without any fees
            var weekendDaysRentalPrice = weekendDays * (snappetCar.DailyPrice * 1.05m);

            // calculate the value of alld days without any fees
            var rentalPriceBeforeFees = weekDaysRentalPrice + weekendDaysRentalPrice;

            // calculate the value of the insurance fee
            var insuranceFee = (((rentalDays * 10) * rentalPriceBeforeFees) / 100);

            // calculate the value of the SnappCar fee
            var snappCarFee = (((rentalDays * 10) * rentalPriceBeforeFees) / 100);

            // calculate the value of the rental adding all fees
            var rentalPriceWithFees = rentalPriceBeforeFees + insuranceFee + snappCarFee;

            // if the rental time is longer than 3 day a 15% discount is applied
            decimal discount = 0;
            if (rentalDays > 3)
            {
                discount = rentalPriceWithFees * 0.15m;
                finalPrice = rentalPriceWithFees - discount;
            }

            response.FinalPrice = finalPrice;
            response.WeekDaysRentalPrice = weekDaysRentalPrice;
            response.WeekendDaysRentalPrice = weekendDaysRentalPrice;
            response.InsuranceFee = insuranceFee;
            response.SnappCarFee = snappCarFee;
            response.Discount = discount;
            return response;
        }
    }
}
