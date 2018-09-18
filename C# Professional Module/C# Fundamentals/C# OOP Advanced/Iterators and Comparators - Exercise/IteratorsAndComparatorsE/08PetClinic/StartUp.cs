using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var pets = new List<Pet>();
        var clinics = new List<Clinic>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            string command = tokens[0];

            switch (command)
            {
                case "Create":
                    try
                    {
                        string typeOfCreation = tokens[1];

                        if (typeOfCreation == "Pet")
                        {
                            string name = tokens[2];
                            int age = int.Parse(tokens[3]);
                            string kind = tokens[4];

                            Pet pet = new Pet(name, age, kind);
                            pets.Add(pet);
                        }
                        else
                        {
                            string clinicName = tokens[2];
                            int roomCount = int.Parse(tokens[3]);

                            Clinic clinic = new Clinic(clinicName, roomCount);
                            clinics.Add(clinic);
                        }
                    }
                    catch(ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                    break;

                case "Add":
                    string petName = tokens[1];
                    string clinicNameToAdd = tokens[2];

                    Pet petToAdd = pets.FirstOrDefault(p => p.Name == petName);
                    Clinic clinicToAdd = clinics.FirstOrDefault(c => c.Name == clinicNameToAdd);

                    Console.WriteLine(clinicToAdd.Add(petToAdd));
                    break;

                case "Release":
                    string clinicToReleaseName = tokens[1];

                    Clinic clinicToRelease = clinics.FirstOrDefault(c => c.Name == clinicToReleaseName);

                    Console.WriteLine(clinicToRelease.Release());
                    break;

                case "HasEmptyRooms":
                    string clinicToCheckName = tokens[1];

                    Clinic clinicToCheck = clinics.FirstOrDefault(c => c.Name == clinicToCheckName);

                    Console.WriteLine(clinicToCheck.HasEmptyRooms);
                    break;

                case "Print":
                    string clinicToPrintName = tokens[1];

                    Clinic clinicToPrint = clinics.FirstOrDefault(c => c.Name == clinicToPrintName);

                    if (tokens.Length == 2)
                    {
                        Console.WriteLine(clinicToPrint.PrintAll());
                    }
                    else
                    {
                        int roomNumberToPrint = int.Parse(tokens[2]);

                        Console.WriteLine(clinicToPrint.Print(roomNumberToPrint));
                    }

                    break;
            }
        }
    }
}