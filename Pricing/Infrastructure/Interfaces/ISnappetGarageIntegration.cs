using Domain.Models;
using System.Threading.Tasks;

namespace Pricing.Infrastructure.Interfaces
{
    public interface ISnappetGarageIntegration
    {
        Task<SnappetCar> GetSnappetCar(int carId);
    }
}
