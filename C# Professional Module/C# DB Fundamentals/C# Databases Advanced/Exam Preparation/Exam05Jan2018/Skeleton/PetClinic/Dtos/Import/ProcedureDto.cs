namespace PetClinic.Dtos.Import
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ProcedureDto
    {
        [Required]
        public string Vet { get; set; }

        [Required]
        public string Animal { get; set; }

        [Required]
        public string DateTime { get; set; }

        public List<AnimalAidProcedureDto> AnimalAids { get; set; }
    }
}