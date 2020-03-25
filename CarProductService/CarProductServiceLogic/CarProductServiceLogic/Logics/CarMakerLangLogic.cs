using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarProductServiceModel.Data;
using CarProductServiceModel.Models;

namespace CarProductServiceLogic.Logics
{
    public class CarMakerLangLogic
    {
        private readonly CarProductServiceContext _context;

        public CarMakerLangLogic(CarProductServiceContext context)
        {
            _context = context;
        }

        public async Task<CarMakerLang> GetCarMakerLangAsync(int makerId, string langId)
        {
            var carMakerLang = await _context.CarMakerLang
                            .AsNoTracking()
                            .SingleOrDefaultAsync(s => s.MakerId == makerId && s.LangId == langId);

            return carMakerLang;
        }

        public async Task<List<CarMakerLang>> PutCarMakerLangAsync(List<CarMakerLang> carMakerLangs)
        {
            carMakerLangs.ForEach(async a =>
            {
                var prevCarMakerLang = await GetCarMakerLangAsync(a.MakerId, a.LangId);
                a.ExclusiveKey = prevCarMakerLang.ExclusiveKey;

                _context.Entry(a).State = EntityState.Modified;
            });

            return carMakerLangs;
        }

        public async Task<List<CarMakerLang>> PostCarMakerLangAsync(List<CarMakerLang> carMakerLangs)
        {
            return carMakerLangs;
        }
    }
}
