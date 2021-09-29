using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class CarForUpdateDto
    {
        [Required(ErrorMessage = "Model name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string ModelName { get; set; }
        [Required(ErrorMessage = "Colour is a required field.")]
        public string Colour { get; set; }
        public string Describtion { get; set; }
        [Required(ErrorMessage = "year is a required field.")]
        public int Year { get; set; }
        [Required(ErrorMessage = "price is a required field.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Condition is a required field.")]
        public string Condition { get; set; }
        public string BodyType { get; set; }
        public IEnumerable<CarForCreationDto> Cars { get; set; }
    }
}
