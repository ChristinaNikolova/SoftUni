using System.Xml.Serialization;

namespace CarDealer.ImportDtos
{
    [XmlType("Car")]
    public class ImportCarDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ExportPartCarDto[] Parts { get; set; }
    }

    [XmlType("partId")]
    public class ExportPartCarDto
    {
        [XmlAttribute("id")]

        public int Id { get; set; }
    }
}
