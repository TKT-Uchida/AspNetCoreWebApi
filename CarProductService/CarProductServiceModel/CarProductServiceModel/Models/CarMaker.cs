using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CommonServiceModel.Models;

namespace CarProductServiceModel.Models
{
    public class CarMaker : CommonData
    {
        [Column("MAKER_ID", Order = 3)]
        public int MakerId { get; set; }

        [Column("COUNTRY_CODE", Order = 2)]
        public string CountryCode { get; set; }

        [Column("MAKER_NAME", Order = 1)]
        public string MakerName { get; set; }

        public List<CarMakerLang> CarMakerLangs { get; set; }

        public List<CarSalesYear> CarSalesYears { get; set; }

        public List<CarProduct> CarProducts { get; set; }
    }
}