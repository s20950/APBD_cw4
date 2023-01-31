using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cw4.Models
{
    public class Animal
    {
        [Required(ErrorMessage = "Id jest wymagane")]
        public int IdAnimal { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Kategoria jest wymagana")]
        [StringLength(200)]
        public string Category { get; set; }
        [Required(ErrorMessage = "Okolica jest wymagana")]
        [StringLength(200)]
        public string Area { get; set; }
    }
}