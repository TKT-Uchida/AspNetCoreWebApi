using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonServiceModel.Models
{
    public class CommonData
    {
        [Column("CREATE_TIME")]
        public DateTime CreateTime { get; set; }

        [Column("CREATE_USER")]
        public string CreateUser { get; set; }

        [Column("UPDATE_TIME")]
        public DateTime UpdateTime { get; set; }

        [Column("UPDATE_USER")]
        public string UpdateUser { get; set; }

        [Timestamp]
        [Column("EX_STAMP")]
        public byte[] ExclusiveKey { get; set; }
    }
}
