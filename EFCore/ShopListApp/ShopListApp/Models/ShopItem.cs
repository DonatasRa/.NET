using System;
using System.ComponentModel.DataAnnotations;

namespace ShopListApp.Models
{
    public class ShopItem
    {

        public int Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Pavadinimas negali būti trumpesnis nei 5 simboliai"), MaxLength(20)]
        public string Name { get; set; }   
        public int ShopId { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow;
        public Shop Shop { get; set; }
    }
}
