using System;
using System.Collections.Generic;

namespace Calling_the_db_SQL_and_ORM.Models
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
    }
}
