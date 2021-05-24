using Domain.Models;
using System.Threading.Tasks;

namespace SnappetGarage.Infrastructure.Interfaces
{
    public interface ISnappetCarsRepository
    {
        Task<SnappetCar> GetSnappetCar(int carId);
    }
}
