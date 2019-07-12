﻿using Best.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best.Entities.Entities
{
    public class Product : IEntity
    {
        public virtual int ProductId { get; set; }

        public virtual int CategoryId { get; set; }

        public virtual string ProductName { get; set; }

        public virtual string QuantityPerUnit { get; set; }

        public virtual decimal UnitPrice { get; set; }

    }
}