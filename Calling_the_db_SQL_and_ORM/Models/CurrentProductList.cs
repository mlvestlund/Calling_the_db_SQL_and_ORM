using System;
using System.Collections.Generic;

namespace Calling_the_db_SQL_and_ORM.Models
{
    public partial class CurrentProductList
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
    }
}
