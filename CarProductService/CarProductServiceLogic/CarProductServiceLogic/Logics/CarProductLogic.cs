using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarProductServiceModel.Data;
using CarProductServiceModel.Models;

namespace CarProductServiceLogic.Logics
{
    public class CarProductLogic
    {
        private readonly CarProductServiceContext _context;

        public CarProductLogic(CarProductServiceContext context)
        {
            _context = context;
        }

        public async Task<CarProduct> GetCarProductAsync(int productId, int makerId)
        {
            var carProduct = await _context.CarProduct
                            .AsNoTracking()
                            .SingleOrDefaultAsync(s => s.ProductId == productId && s.MakerId == makerId);

            return carProduct;
        }

        public async Task<List<CarProduct>> PutCarProductAsync(List<CarProduct> carProducts)
        {
            // var carProductLangLogic = new CarProductLangLogic(_context);
            // var carProductModelLogic = new CarProductModelLogic(_context);

            carProducts.ForEach(async a =>
            {
                var prevCarProduct = await GetCarProductAsync(a.ProductId, a.MakerId);
                a.ExclusiveKey = prevCarProduct.ExclusiveKey;

                _context.Entry(a).State = EntityState.Modified;

                // await carProductLangLogic.PutCarProductLangAsync(a.CarProductLangs);
                // await carProductModelLogic.PutCarProductModelAsync(a.CarProductModels);
            });

            return carProducts;
        }

        public async Task<List<CarProduct>> PostCarProductAsync(List<CarProduct> carProducts)
        {
            return carProducts;
        }
    }
}
