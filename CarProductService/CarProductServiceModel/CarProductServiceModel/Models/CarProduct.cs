using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CommonServiceModel.Models;

namespace CarProductServiceModel.Models
{
    public class CarProduct : CommonData
    {
        [Column("PRODUCT_ID", Order = 0)]
        public int ProductId { get; set; }

        [Column("MAKER_ID", Order = 1)]
        public int MakerId { get; set; }

        [Column("TYPE_CODE", Order = 2)]
        public string TypeCode { get; set; }

        [Column("PRODUCT_NAME", Order = 3)]
        public string ProductName { get; set; }

        public CarMaker CarMaker { get; set; }

        public List<CarProductLang> CarProductLangs { get; set; }

        public List<CarProductModel> CarProductModels { get; set; }
    }
}