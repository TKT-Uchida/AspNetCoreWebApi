using System;
using System.Collections.Generic;

namespace MigrationTestModel
{
    public class ModelUserMst
    {
        public int UserId { get; set; }

        public int ModelId { get; set; }

        public int Count { get; set; }

        public ProductModelMst ProductModelMst { get; set; }
    }
}
