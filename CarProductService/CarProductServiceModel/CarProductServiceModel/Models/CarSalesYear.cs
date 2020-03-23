using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CommonServiceModel.Models;

namespace CarProductServiceModel.Models
{
    public class CarSalesYear : CommonData
    {
        [Column("CAR_SALES_ID", Order = 0)]
        public int CarSalesId { get; set; }
        
        [Column("MAKER_ID", Order = 1)]
        public int MakerId { get; set; }

        [Column("TARGET_YEAR", Order = 2)]
        public string TargetYear { get; set; }

        [Column("SALES_VOLUME", Order = 3)]
        public string SalesVolume { get; set; }

        public CarMaker CarMaker { get; set; }
    }
}