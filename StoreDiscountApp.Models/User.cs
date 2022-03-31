using System;
using System.ComponentModel;

namespace StoreDiscountApp.Models
{
    public class User : IEntity
    {
        [DisplayName("Rol")]
        public Guid RoleId { get; set; }
    }
}
