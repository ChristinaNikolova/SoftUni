using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-z]+[ ][A-Z][a-z]+$")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(typeof(int), "3", "103")]
        public int Age { get; set; }

        public ImportCardDto[] Cards { get; set; }
    }

    public class ImportCardDto
    {
        [Required]
        [RegularExpression(@"^[0-9]{4}[ ][0-9]{4}[ ][0-9]{4}[ ][0-9]{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}$")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
