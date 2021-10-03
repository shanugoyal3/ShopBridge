using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBridge.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Field is Required")]
        public string  Name { get; set; }
        [Required(ErrorMessage = "Description Field is Required")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Price Field is Required")]
        public decimal Price { get; set; }


        public Category Category { get; set; }
        [ForeignKey("CategoryId")]
        public byte  CategoryId { get; set; }


    }
}
