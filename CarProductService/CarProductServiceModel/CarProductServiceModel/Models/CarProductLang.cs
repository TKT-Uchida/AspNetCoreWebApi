using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CommonServiceModel.Models;

namespace CarProductServiceModel.Models
{
    public class CarProductLang : CommonData
    {
        [Column("PRODUCT_ID", Order = 0)]
        public int ProductId { get; set; }

        [Column("MAKER_ID", Order = 1)]
        public int MakerId { get; set; }

        [Column("LANG_ID", Order = 2)]
        public string LangId { get; set; }

        [Column("PRODUCT_NAME_LANG", Order = 3)]
        public string ProductNameLang { get; set; }

        public CarProduct CarProduct { get; set; }
    }
}