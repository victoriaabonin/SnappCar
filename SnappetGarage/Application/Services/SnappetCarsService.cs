using Domain.Models;
using SnappetGarage.Infrastructure.Interfaces;
using SnappetGarage.Interfaces.Application;
using System.Threading.Tasks;

namespace SnappetGarage.Services.Application
{
    public class SnappetCarsService : ISnappetCarsService
    {
        private readonly ISnappetCarsRepository _snappetCarsRepository;

        public SnappetCarsService(ISnappetCarsRepository snappetCarsRepository)
        {
            _snappetCarsRepository = snappetCarsRepository;
        }

        public async Task<SnappetCar> GetSnappetCar(int carId)
        {
            var snappetCar = await _snappetCarsRepository.GetSnappetCar(carId);
            return snappetCar;
        }
    }
}
