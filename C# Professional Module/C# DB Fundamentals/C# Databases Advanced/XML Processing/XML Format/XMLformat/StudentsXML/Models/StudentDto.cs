namespace StudentsXML.Models
{
    using System.Xml.Serialization;
    
    [XmlType("student")]
    public class StudentDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("gender")]
        public string Gender { get; set; }

        [XmlElement("birthDate")]
        public string BirthDate { get; set; }

        [XmlElement("phoneNumber")]
        public string PhoneNumber { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }

        [XmlElement("university")]
        public string University { get; set; }

        [XmlElement("specialty")]
        public string Specialty { get; set; }

        [XmlElement("facultyNumber")]
        public string FacultyNumber { get; set; }

        [XmlElement("exams")]
        public ExamsSection Exams { get; set; }
    }
}