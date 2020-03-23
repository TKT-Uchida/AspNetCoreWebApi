using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CommonServiceModel.Models;

namespace CarProductServiceModel.Models
{
    public class CarProductModel : CommonData
    {
        [Column("MODEL_ID", Order = 0)]
        public int ModelId { get; set; }

        [Column("PRODUCT_ID", Order = 1)]
        public int ProductId { get; set; }

        [Column("MAKER_ID", Order = 2)]
        public int MakerId { get; set; }

        [Column("MODEL_YEAR", Order = 3)]
        public string ModelYear { get; set; }

        [Column("PRODUCT_MODEL_NAME", Order = 4)]
        public string ProductModelName { get; set; }

        public CarProduct CarProduct { get; set; }
    }
}