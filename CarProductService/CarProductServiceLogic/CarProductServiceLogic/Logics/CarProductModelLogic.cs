using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarProductServiceModel.Data;
using CarProductServiceModel.Models;

namespace CarProductServiceLogic.Logics
{
    public class CarProductModelLogic
    {
        private readonly CarProductServiceContext _context;

        public CarProductModelLogic(CarProductServiceContext context)
        {
            _context = context;
        }

        public async Task<CarProductModel> GetCarProductModelAsync(int modelId)
        {
            var carProductModel = await _context.CarProductModel
                            .AsNoTracking()
                            .SingleOrDefaultAsync(s => s.ModelId == modelId);

            return carProductModel;
        }

        public async Task<List<CarProductModel>> PutCarProductModelAsync(List<CarProductModel> carProductModels)
        {
            carProductModels.ForEach(async a =>
            {
                var prevCarProductModel = await GetCarProductModelAsync(a.ModelId);
                a.ExclusiveKey = prevCarProductModel.ExclusiveKey;

                _context.Entry(a).State = EntityState.Modified;
            });

            return carProductModels;
        }

        public async Task<List<CarProductModel>> PostCarProductModelAsync(List<CarProductModel> carProductModels)
        {
            return carProductModels;
        }
    }
}
