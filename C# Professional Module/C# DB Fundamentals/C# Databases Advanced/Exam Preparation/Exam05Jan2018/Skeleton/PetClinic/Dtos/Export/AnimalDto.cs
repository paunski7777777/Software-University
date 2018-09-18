namespace PetClinic.Dtos.Export
{
    using System;

    public class AnimalDto
    {
        public string OwnerName { get; set; }
        public string AnimalName { get; set; }
        public int Age { get; set; }
        public string SerialNumber { get; set; }
        public string RegisteredOn { get; set; }
    }
}