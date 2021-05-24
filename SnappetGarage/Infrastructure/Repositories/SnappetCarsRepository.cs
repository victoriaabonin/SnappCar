using Domain.Models;
using SnappetGarage.Infrastructure;
using SnappetGarage.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pricing.Infrastructure.Repositories
{
    public class SnappetCarsRepository : ISnappetCarsRepository
    {
        private readonly ApplicationDbContext _context;

        // mock data
        private readonly List<SnappetCar> Cars = new List<SnappetCar>
        {
            new SnappetCar
            {
                Id = 1,
                DailyPrice = 10
            },
            new SnappetCar
            {
                Id = 2,
                DailyPrice = 12
            },
            new SnappetCar
            {
                Id = 3,
                DailyPrice = 18
            },
            new SnappetCar
            {
                Id = 4,
                DailyPrice = 22
            },
            new SnappetCar
            {
                Id = 5,
                DailyPrice = 43
            },
            new SnappetCar
            {
                Id = 6,
                DailyPrice = 39
            },
            new SnappetCar
            {
                Id = 7,
                DailyPrice = 76
            },
        };


        public SnappetCarsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SnappetCar> GetSnappetCar(int carId)
        {
            //return await _context.SnappetCars.FindAsync(carId);
            return Cars.FirstOrDefault(x => x.Id == carId);
        }
    }
}
