using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsValidationSample
{
    public class Person
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}