using Domain.Models;
using System.Threading.Tasks;

namespace SnappetGarage.Interfaces.Application
{
    public interface ISnappetCarsService
    {
        Task<SnappetCar> GetSnappetCar(int carId);
    }
}
