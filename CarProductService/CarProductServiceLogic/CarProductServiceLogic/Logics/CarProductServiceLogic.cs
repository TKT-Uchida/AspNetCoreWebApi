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

        public async Task<IEnumerable<CarMaker>> GetCarMakerAsync()
        {
            return await _context.CarMaker
                            .Include(e => e.CarMakerLangs)
                            .Include(e => e.CarSalesYears)
                            .Include(e => e.CarProducts)
                                .ThenInclude(e => e.CarProductLangs)
                            .Include(e => e.CarProducts)
                                .ThenInclude(e => e.CarProductModels)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<CarMaker> GetCarMakerAsync(int id)
        {
            var carMaker = await _context.CarMaker
                            .Include(e => e.CarMakerLangs)
                            .Include(e => e.CarSalesYears)
                            .Include(e => e.CarProducts)
                                .ThenInclude(e => e.CarProductLangs)
                            .Include(e => e.CarProducts)
                                .ThenInclude(e => e.CarProductModels)
                            .AsNoTracking()
                            .SingleOrDefaultAsync(s => s.MakerId == id);

            return carMaker;
        }

        public async Task PutCarMakerAsync(int id, CarMaker carMaker)
        {
            var prevCarMaker = await GetCarMakerAsync(id);
            carMaker.ExclusiveKey = prevCarMaker.ExclusiveKey;
            // _context.Entry(carMaker).State = EntityState.Modified;
            carMaker.CarMakerLangs.ForEach(a =>
                a.ExclusiveKey = prevCarMaker.CarMakerLangs
                                    .SingleOrDefault(s => s.MakerId == a.MakerId && s.LangId == a.LangId)
                                    .ExclusiveKey
            );
            // _context.Entry(carMaker).State = EntityState.Modified;
            // _context.Entry(carMaker.CarMakerLangs).State = EntityState.Modified;
            _context.Update(carMaker);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task PostCarMakerAsync(CarMaker carMaker)
        {
            _context.CarMaker.Add(carMaker);
            await _context.SaveChangesAsync();
        }

        public async Task<CarMaker> DeleteCarMakerAsync(int id)
        {
            var carMaker = await GetCarMakerAsync(id);

            if (carMaker != null)
            {
                _context.CarMaker.Remove(carMaker);
                await _context.SaveChangesAsync();
            }

            return carMaker;
        }
    }
}
