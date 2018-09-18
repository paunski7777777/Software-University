namespace PetClinic.DataProcessor
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.Xml;

    using Newtonsoft.Json;

    using PetClinic.Data;
    using PetClinic.Dtos.Export;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals
                                .Where(pn => pn.Passport.OwnerPhoneNumber == phoneNumber)
                                .Select(a => new AnimalDto
                                {
                                    OwnerName = a.Passport.OwnerName,
                                    AnimalName = a.Name,
                                    Age = a.Age,
                                    SerialNumber = a.PassportSerialNumber,
                                    RegisteredOn = a.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                                })
                                .OrderBy(a => a.Age)
                                .ThenBy(s => s.SerialNumber)
                                .ToList();

            var jsonString = JsonConvert.SerializeObject(animals, Newtonsoft.Json.Formatting.Indented);

            return jsonString;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedure = context.Procedures
                                   .OrderBy(d => d.DateTime)
                                   .Select(p => new ProcedureDto
                                   {
                                       Passport = p.Animal.PassportSerialNumber,
                                       OwnerNumber = p.Animal.Passport.OwnerPhoneNumber,
                                       DateTime = p.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                                       AnimalAids = p.ProcedureAnimalAids
                                                     .Select(a => new AnimalAidDto
                                                     {
                                                         Name = a.AnimalAid.Name,
                                                         Price = a.AnimalAid.Price
                                                     })
                                                     .ToList(),
                                       TotalPrice = p.ProcedureAnimalAids
                                                     .Sum(a => a.AnimalAid.Price)
                                   })
                                   .OrderBy(p => p.Passport)
                                   .ToList();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(List<ProcedureDto>), new XmlRootAttribute("Procedures"));

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            serializer.Serialize(new StringWriter(sb), procedure, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }
    }
}