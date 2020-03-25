using System;
using System.Collections.Generic;

namespace MigrationTestModel
{
    public class ProductMst
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public List<ProductMstChild> ProductMstParent { get; set; }

        public List<ProductMstChild> ProductMstChild { get; set; }
    }
}
