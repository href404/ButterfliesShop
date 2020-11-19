using ButterfliesShop.Validators;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace ButterfliesShop.Models
{
    [ButterflyValidation]
    public class Butterfly
    {
        public int Id { get; set; }

        [Display(Name = "Butterfly name:")]
        [Required]
        public string CommonName { get; set; }

        [Display(Name = "Butterfly family:")]
        public Family? ButterflyFamily { get; set; }

        [Display(Name = "Quantity:")]
        public int? Quantity { get; set; }

        [Display(Name = "Characteristics:")]
        public string Characteristics { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ImageMimeType { get; set; }

        public string ImageName { get; set; }

        [Display(Name = "Photo:")]
        [Required]
        public IFormFile Photo { get; set; }
    }
}
