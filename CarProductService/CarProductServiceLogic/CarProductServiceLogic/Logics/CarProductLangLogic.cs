using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarProductServiceModel.Data;
using CarProductServiceModel.Models;

namespace CarProductServiceLogic.Logics
{
    public class CarProductLangLogic
    {
        private readonly CarProductServiceContext _context;

        public CarProductLangLogic(CarProductServiceContext context)
        {
            _context = context;
        }

        public async Task<CarProductLang> GetCarProductLangAsync(int productId, int makerId, string langId)
        {
            var carProductLang = await _context.CarProductLang
                            .AsNoTracking()
                            .SingleOrDefaultAsync(s => s.ProductId == productId && s.MakerId == makerId && s.LangId == langId);

            return carProductLang;
        }

        public async Task<List<CarProductLang>> PutCarProductLangAsync(List<CarProductLang> carProductLangs)
        {
            carProductLangs.ForEach(async a =>
            {
                // DbContext スレッドの問題の回避
                // https://docs.microsoft.com/ja-jp/ef/core/miscellaneous/configuring-dbcontext
                var prevCarProductLang = await GetCarProductLangAsync(a.ProductId, a.MakerId, a.LangId);
                a.ExclusiveKey = prevCarProductLang.ExclusiveKey;

                _context.Entry(a).State = EntityState.Modified;
            });

            return carProductLangs;
        }

        public async Task<List<CarProductLang>> PostCarProductLangAsync(List<CarProductLang> carProductLangs)
        {
            return carProductLangs;
        }
    }
}
