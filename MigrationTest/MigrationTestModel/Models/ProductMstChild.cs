using System;

namespace MigrationTestModel
{
    public class ProductMstChild
    {
        public int ParenctProductId { get; set; }

        public int ChildProductId { get; set; }

        public ProductMst ParentProductMst { get; set; }

        public ProductMst ChildProductMst { get; set; }
    }
}
