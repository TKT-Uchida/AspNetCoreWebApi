using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CommonServiceModel.Models;

namespace CarProductServiceModel.Models
{
    public class CarMakerLang : CommonData
    {
        [Column("MAKER_ID", Order = 0)]
        public int MakerId { get; set; }

        [Column("LANG_ID", Order = 1)]
        public string LangId { get; set; }

        [Column("MAKER_NAME_LANG", Order = 2)]
        public string MakerNameLang { get; set; }

        public CarMaker CarMaker { get; set; }
    }
}