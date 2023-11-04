using System.ComponentModel.DataAnnotations;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportProducerDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+[ ][A-Z][a-z]+$")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^\+359[ ][0-9]{3}[ ][0-9]{3}[ ][0-9]{3}$")]
        public string PhoneNumber { get; set; }

        public ImportAlbumDto[] Albums { get; set; }
    }

    public class ImportAlbumDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }
    }
}
