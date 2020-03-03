using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "You must provide a positive number")]
        public double Price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must provide a positive number")]
        public int Stock { get; set; }
        [Display(Name = "Image")]
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "You must provide a Genre")]
        [Display(Name = "Genre")]
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}