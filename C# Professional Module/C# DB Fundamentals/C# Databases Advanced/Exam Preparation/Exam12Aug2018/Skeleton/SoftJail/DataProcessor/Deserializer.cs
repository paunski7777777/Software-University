namespace SoftJail.DataProcessor
{
    using Data;
    using SoftJail.DataProcessor.ImportDto;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;

    using Newtonsoft.Json;

    using AutoMapper;

    using System.Text;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Serialization;
    using System.IO;
    using System;
    using System.Globalization;

    public class Deserializer
    {
        private const string ERROR_MESSAGE = "Invalid Data";
        private const string SUCCESS_MESSAGE_Departments_Cells = "Imported {0} with {1} cells";
        private const string SUCCESS_MESSAGE_Prisoners_Mails = "Imported {0} {1} years old";
        private const string SUCCESS_MESSAGE_Officers_Prisoners = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedDepartments = JsonConvert.DeserializeObject<List<DepartmentDto>>(jsonString);

            var validDepartments = new List<Department>();

            foreach (var departmentDto in deserializedDepartments)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var validCells = departmentDto.Cells.All(IsValid);
                if (!validCells)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var department = Mapper.Map<Department>(departmentDto);
                validDepartments.Add(department);

                sb.AppendLine(string.Format(SUCCESS_MESSAGE_Departments_Cells, departmentDto.Name, departmentDto.Cells.Count));
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedPrisoners = JsonConvert.DeserializeObject<List<PrisonerDto>>(jsonString);

            var validPrisoners = new List<Prisoner>();

            foreach (var prisonerDto in deserializedPrisoners)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var validMails = new List<Mail>();

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine(ERROR_MESSAGE);
                        continue;
                    }

                    var mail = new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address,
                    };

                    validMails.Add(mail);
                }

                var incarcerationDate = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var incarcerationDateResult);
                var releaseDate = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var releaseDateResult);

                if (!incarcerationDate)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDateResult,
                    ReleaseDate = releaseDateResult,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                    Mails = validMails
                };

                validPrisoners.Add(prisoner);

                sb.AppendLine(string.Format(SUCCESS_MESSAGE_Prisoners_Mails, prisonerDto.FullName, prisonerDto.Age));
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(List<OfficerDto>), new XmlRootAttribute("Officers"));

            var deserializedOfficers = (List<OfficerDto>)serializer.Deserialize(new StringReader(xmlString));

            var validOfficers = new List<Officer>();

            foreach (var officerDto in deserializedOfficers)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var validPrisoners = new List<OfficerPrisoner>();

                foreach (var prisonerDto in officerDto.Prisoners)
                {
                    if (!IsValid(prisonerDto))
                    {
                        sb.AppendLine(ERROR_MESSAGE);
                        continue;
                    }

                    var prisoner = new OfficerPrisoner
                    {
                        PrisonerId = prisonerDto.Id
                    };

                    validPrisoners.Add(prisoner);
                }

                var position = Enum.TryParse<Position>(officerDto.Position, out var validPosition);
                var weapon = Enum.TryParse<Weapon>(officerDto.Weapon, out var validweapon);
                if (!position || !weapon)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = validPosition,
                    Weapon = validweapon,
                    DepartmentId = officerDto.DepartmentId,
                    OfficerPrisoners = validPrisoners
                };

                validOfficers.Add(officer);

                sb.AppendLine(string.Format(SUCCESS_MESSAGE_Officers_Prisoners, officerDto.Name, officerDto.Prisoners.Count));
            }

            context.AddRange(validOfficers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);

            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}