using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterimProject.Models
{
    public class Menu
    {
        [Key]
        public int ItemId { get; set; } 

        [Required(ErrorMessage ="Food Item Name can't be blank")]
        [MaxLength(255)]
        [Display(Name ="Food Item Name")]
        public string ItemName { get; set; }

        [Required(ErrorMessage ="Food Item Cost can't be blank"),Range(0,1000)]
        public decimal ItemCost { get; set; }


        [Required(ErrorMessage = "Discount can't be blank, If No discount offered Enter 0"), Range(0, 100)]
        public int ItemDiscount { get; set; }

        //Navigation Properties
        public Category Category { get; set; }

        [Required(ErrorMessage = "Category can't be blank")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }


        //For Connecting Database
        // dotnet ef migrations add DBCreation -s ./../InterimProject/InterimProject.csproj

    }
}
