using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarProductServiceModel.Data;
using CarProductServiceModel.Models;

namespace CarProductServiceLogic.Logics
{
    public class CarSalesYearLogic
    {
        private readonly CarProductServiceContext _context;

        public CarSalesYearLogic(CarProductServiceContext context)
        {
            _context = context;
        }

        public async Task<CarSalesYear> GetCarSalesYearAsync(int carSalesId)
        {
            var carSalesYear = await _context.CarSalesYear
                            .AsNoTracking()
                            .SingleOrDefaultAsync(s => s.CarSalesId == carSalesId);

            return carSalesYear;
        }

        public async Task<List<CarSalesYear>> PutCarSalesYearAsync(List<CarSalesYear> carSalesYears)
        {
            carSalesYears.ForEach(async a =>
            {
                var prevCarSalesYear = await GetCarSalesYearAsync(a.CarSalesId);
                a.ExclusiveKey = prevCarSalesYear.ExclusiveKey;

                _context.Entry(a).State = EntityState.Modified;
            });

            return carSalesYears;
        }

        public async Task<List<CarSalesYear>> PostCarSalesYearAsync(List<CarSalesYear> carSalesYears)
        {
            return carSalesYears;
        }
    }
}
