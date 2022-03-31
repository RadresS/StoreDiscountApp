using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreDiscountApp.Models
{
    public class Role : IEntity
    {
        [DisplayName("Store")]
        public Guid StoreId { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:#,###0.00}", ApplyFormatInEditMode = true)]
        [DisplayName("Discount Rate")]
        public decimal DiscountRate { get; set; }

        [DisplayName("Customer")]
        public bool IsCustomer { get; set; }
    }
}
