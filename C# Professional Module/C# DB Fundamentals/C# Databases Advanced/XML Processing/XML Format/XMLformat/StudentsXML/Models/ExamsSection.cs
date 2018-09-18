namespace StudentsXML.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("exams")]
    public class ExamsSection
    {
        [XmlElement("exam")]
        public List<ExamDto> Exams { get; set; }
    }
}