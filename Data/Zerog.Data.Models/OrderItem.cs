﻿namespace Zerog.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Zerog.Data.Common.Models;
    using Zerog.Data.Models.ProductModels;

    public class OrderItem : BaseDeletableModel<int>
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
