using System;
using System.Collections.Generic;

namespace MigrationTestModel
{
    public class ProductModelMst
    {
        public int ProductId { get; set; }

        public int ModelId { get; set; }

        public string ModelName { get; set; }

        public List<ModelUserMst> ModelUserMsts { get; set; }
    }
}
