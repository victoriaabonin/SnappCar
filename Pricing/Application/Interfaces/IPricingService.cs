using Pricing.Models.RequestModels;
using Pricing.Models.ResponseModels;
using System.Threading.Tasks;

namespace Pricing.Application.Interfaces
{
    public interface IPricingService
    {
        Task<GetPriceResponseModel> GetPrice(GetPriceRequestModel GetPriceRequestModel);
    }
}
