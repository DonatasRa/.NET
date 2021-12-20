using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopListApp.Models
{
    public class Shop
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Pavadinimas negali būti trumpesnis nei 5 simboliai"), MaxLength(20)]
        public string Name { get; set; }
    }
}
