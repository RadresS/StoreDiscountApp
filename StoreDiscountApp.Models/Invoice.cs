using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreDiscountApp.Models
{
    public class Invoice : IEntity
    {
        [DisplayName("User")]
        public Guid? UserId { get; set; }
        [DisplayName("User")]
        public string UserName { get; set; }
        [DisplayName("Rol")]
        public string RolName { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:#,###0.00}", ApplyFormatInEditMode = true)]
        [DisplayName("Discount Rate")]
        public decimal DiscountRate { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:#,###0.00}", ApplyFormatInEditMode = true)]
        [DisplayName("Discount")]
        public decimal Discount { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:#,###0.00}", ApplyFormatInEditMode = true)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:#,###0.00}", ApplyFormatInEditMode = true)]
        [DisplayName("Remaining")]
        public decimal Remaining { get; set; }


    }
}
