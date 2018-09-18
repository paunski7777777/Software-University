namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using AutoMapper;

    using Newtonsoft.Json;

    using PetClinic.Data;
    using PetClinic.Dtos.Import;
    using PetClinic.Models;

    public class Deserializer
    {
        private const string ERROR_MESSAGE = "Error: Invalid data.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedAnimalAids = JsonConvert.DeserializeObject<List<AnimalAidDto>>(jsonString);

            var animalAids = new List<AnimalAid>();

            foreach (var animalAidDto in deserializedAnimalAids)
            {
                var animalAidExists = animalAids.Any(n => n.Name == animalAidDto.Name);

                if (!IsValid(animalAidDto) || animalAidExists)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                // var animalAid = Mapper.Map<AnimalAid>(animalAidDto);
                var animalAid = new AnimalAid
                {
                    Name = animalAidDto.Name,
                    Price = animalAidDto.Price
                };

                animalAids.Add(animalAid);

                sb.AppendLine($"Record {animalAid.Name} successfully imported.");
            }

            context.AnimalAids.AddRange(animalAids);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedAnimals = JsonConvert.DeserializeObject<List<AnimalDto>>(jsonString);

            var animals = new List<Animal>();

            foreach (var animalDto in deserializedAnimals)
            {
                var passportSerialNumberExists = animals.Any(s => s.Passport.SerialNumber == animalDto.Passport.SerialNumber);

                if (!IsValid(animalDto) || !IsValid(animalDto.Passport) || passportSerialNumberExists)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                // var animal = Mapper.Map<Animal>(animalDto);
                var animal = new Animal
                {
                    Name = animalDto.Name,
                    Type = animalDto.Type,
                    Age = animalDto.Age,
                    Passport = new Passport
                    {
                        SerialNumber = animalDto.Passport.SerialNumber,
                        OwnerPhoneNumber = animalDto.Passport.OwnerPhoneNumber,
                        OwnerName = animalDto.Passport.OwnerName,
                        RegistrationDate = DateTime.ParseExact(animalDto.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                    }
                };

                animals.Add(animal);

                sb.AppendLine($"Record {animal.Name} Passport №: {animal.Passport.SerialNumber} successfully imported.");
            }

            context.Animals.AddRange(animals);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(List<VetDto>), new XmlRootAttribute("Vets"));

            var deserializedVets = (List<VetDto>)serializer.Deserialize(new StringReader(xmlString));

            var vets = new List<Vet>();

            foreach (var vetDto in deserializedVets)
            {
                var vetExists = vets.Any(pn => pn.PhoneNumber == vetDto.PhoneNumber);

                if (!IsValid(vetDto) || vetExists)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                // var vet = Mapper.Map<Vet>(vetDto);
                var vet = new Vet
                {
                    Name = vetDto.Name,
                    Profession = vetDto.Profession,
                    Age = vetDto.Age,
                    PhoneNumber = vetDto.PhoneNumber
                };

                vets.Add(vet);

                sb.AppendLine($"Record {vet.Name} successfully imported.");
            }

            context.Vets.AddRange(vets);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(List<ProcedureDto>), new XmlRootAttribute("Procedures"));

            var deserializedProcedures = (List<ProcedureDto>)serializer.Deserialize(new StringReader(xmlString));

            var procedures = new List<Procedure>();

            foreach (var procedureDto in deserializedProcedures)
            {
                var vet = context.Vets.SingleOrDefault(v => v.Name == procedureDto.Vet);
                var animal = context.Animals.SingleOrDefault(a => a.PassportSerialNumber == procedureDto.Animal);

                var procedureAnimalAids = new List<ProcedureAnimalAid>();

                var allAnimalsAidsExists = true;

                foreach (var procedureDtoAnimalAid in procedureDto.AnimalAids)
                {
                    var animalAid = context.AnimalAids.SingleOrDefault(a => a.Name == procedureDtoAnimalAid.Name);

                    if (animalAid == null || procedureAnimalAids.Any(p => p.AnimalAid.Name == procedureDtoAnimalAid.Name))
                    {
                        allAnimalsAidsExists = false;
                        break;
                    }

                    ProcedureAnimalAid procedureAnimalAid = new ProcedureAnimalAid
                    {
                        AnimalAid = animalAid
                    };

                    procedureAnimalAids.Add(procedureAnimalAid);
                }

                if (!IsValid(procedureDto)
                    || !procedureDto.AnimalAids.All(IsValid)
                    || vet == null
                    || animal == null
                    || !allAnimalsAidsExists)
                {
                    sb.AppendLine(ERROR_MESSAGE);
                    continue;
                }

                var procedure = new Procedure
                {
                    Animal = animal,
                    Vet = vet,
                    DateTime = DateTime.ParseExact(procedureDto.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    ProcedureAnimalAids = procedureAnimalAids
                };

                procedures.Add(procedure);

                sb.AppendLine("Record successfully imported.");
            }

            context.Procedures.AddRange(procedures);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
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