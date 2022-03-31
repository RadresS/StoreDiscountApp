using System;
using System.ComponentModel.DataAnnotations;

namespace StoreDiscountApp.Models
{
    public abstract class IEntity 
    {
        [Key]
        public Guid Id { get; set; } =  Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
