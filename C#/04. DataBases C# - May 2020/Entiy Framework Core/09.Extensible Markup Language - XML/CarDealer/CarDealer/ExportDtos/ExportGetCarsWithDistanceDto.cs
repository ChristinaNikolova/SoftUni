using System.Xml.Serialization;

namespace CarDealer.ExportDtos
{
    [XmlType("car")]
    public class ExportGetCarsWithDistanceDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
