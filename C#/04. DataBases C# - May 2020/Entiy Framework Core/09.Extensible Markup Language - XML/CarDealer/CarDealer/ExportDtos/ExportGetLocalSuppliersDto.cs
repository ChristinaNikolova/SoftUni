using System.Xml.Serialization;

namespace CarDealer.ExportDtos
{
    [XmlType("suplier")]
    public class ExportGetLocalSuppliersDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }
    }
}
