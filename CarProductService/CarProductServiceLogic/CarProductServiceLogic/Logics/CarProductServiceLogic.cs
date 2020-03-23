using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarProductServiceModel.Data;
using CarProductServiceModel.Models;

namespace CarProductServiceLogic.Logics
{
    public class CarMakerLogic
    {
        private readonly CarProductServiceContext _context;

        public CarMakerLogic(CarProductServiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarMaker>> GetCarMaker()
        {
            return await _context.CarMaker
                            .Include(e => e.CarMakerLangs)
                            .Include(e => e.CarSalesYears)
                            .Include(e => e.CarProducts)
                                .ThenInclude(e => e.CarProductLangs)
                            .Include(e => e.CarProducts)
                                .ThenInclude(e => e.CarProductModels)
                            .ToListAsync();
        }

        public async Task<CarMaker> GetCarMaker(int id)
        {
            var carMaker = await _context.CarMaker
                            .Include(e => e.CarMakerLangs)
                            .Include(e => e.CarSalesYears)
                            .Include(e => e.CarProducts)
                                .ThenInclude(e => e.CarProductLangs)
                            .Include(e => e.CarProducts)
                                .ThenInclude(e => e.CarProductModels)
                            .SingleOrDefaultAsync(s => s.MakerId == id);

            return carMaker;
        }

        public async Task PutCarMaker(int id, CarMaker carMaker)
        {
            _context.Entry(carMaker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task PostCarMaker(CarMaker carMaker)
        {
            _context.CarMaker.Add(carMaker);
            await _context.SaveChangesAsync();
        }

        public async Task<CarMaker> DeleteCarMaker(int id)
        {
            var carMaker = await GetCarMaker(id);

            if (carMaker != null)
            {
                _context.CarMaker.Remove(carMaker);
                await _context.SaveChangesAsync();
            }

            return carMaker;
        }
    }
}
