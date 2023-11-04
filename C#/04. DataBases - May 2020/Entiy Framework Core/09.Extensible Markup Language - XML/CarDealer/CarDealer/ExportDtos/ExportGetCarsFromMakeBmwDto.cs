using System.Xml.Serialization;

namespace CarDealer.ExportDtos
{
    [XmlType("car")]
    public class ExportGetCarsFromMakeBmwDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
