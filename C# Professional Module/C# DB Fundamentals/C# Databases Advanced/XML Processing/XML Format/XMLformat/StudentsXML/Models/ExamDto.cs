namespace StudentsXML.Models
{
    using System.Xml.Serialization;

    [XmlType("exam")]
    public class ExamDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("dateTaken")]
        public string DateTaken { get; set; }

        [XmlElement("grade")]
        public double Grade { get; set; }
    }
}