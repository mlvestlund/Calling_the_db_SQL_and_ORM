﻿using System;
using System.Collections.Generic;

namespace Calling_the_db_SQL_and_ORM.Models
{
    public partial class SummaryOfSalesByYear
    {
        public DateTime? ShippedDate { get; set; }
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
