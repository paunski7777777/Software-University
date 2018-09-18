namespace SoftJail.DataProcessor
{
    using Data;
    using SoftJail.DataProcessor.ExportDto;

    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                                   .Where(i => ids.Contains(i.Id))
                                   .Select(p => new
                                   {
                                       Id = p.Id,
                                       Name = p.FullName,
                                       CellNumber = p.Cell.CellNumber,
                                       Officers = p.PrisonerOfficers
                                                   .Select(o => new
                                                   {
                                                       OfficerName = o.Officer.FullName,
                                                       Department = o.Officer.Department.Name
                                                   })
                                                   .OrderBy(on => on.OfficerName)
                                                   .ToList(),
                                       TotalOfficerSalary = p.PrisonerOfficers
                                                             .Sum(s => s.Officer.Salary)
                                   })
                                   .OrderBy(n => n.Name)
                                   .ThenBy(pi => pi.Id)
                                   .ToList();

            var jsonString = JsonConvert.SerializeObject(prisoners, Newtonsoft.Json.Formatting.Indented);
            return jsonString;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisonersInput = prisonersNames.Split(',');

            var prisoners = context.Prisoners
                                   .Where(n => prisonersInput.Contains(n.FullName))
                                   .Select(p => new PrisonerDto
                                   {
                                       Id = p.Id,
                                       Name = p.FullName,
                                       IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                                       EncryptedMessages = p.Mails
                                                            .Select(m => new MessageDto
                                                            {
                                                                Description = Reverse(m.Description)
                                                            })
                                                            .ToList()
                                   })
                                   .OrderBy(pn => pn.Name)
                                   .ThenBy(pi => pi.Id)
                                   .ToList();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(List<PrisonerDto>), new XmlRootAttribute("Prisoners"));

            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            serializer.Serialize(new StringWriter(sb), prisoners, xmlNamespaces);

            string result = sb.ToString().TrimEnd();
            return result;
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();

            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}