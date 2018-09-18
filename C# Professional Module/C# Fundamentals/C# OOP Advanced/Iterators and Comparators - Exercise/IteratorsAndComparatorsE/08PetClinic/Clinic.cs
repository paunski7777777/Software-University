using System;
using System.Linq;
using System.Text;
public class Clinic
{
    public string Name { get; set; }
    public Pet[] Pets { get; set; }
    public int Center => this.Pets.Length / 2;
    public bool HasEmptyRooms => this.Pets.Any(p => p == null);
    public Clinic(string name, int rooms)
    {
        this.Name = name;
        this.ValidateSize(rooms);
        this.Pets = new Pet[rooms];
    }

    private void ValidateSize(int rooms)
    {
        if (rooms % 2 == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }
    }
    public bool Add(Pet pet)
    {
        int currentRoom = this.Center;

        for (int i = 0; i < this.Pets.Length; i++)
        {
            if (i % 2 != 0)
            {
                currentRoom -= i;
            }
            else
            {
                currentRoom += i;
            }

            if (this.Pets[currentRoom] == null)
            {
                this.Pets[currentRoom] = pet;
                return true;
            }
        }

        return false;
    }
    public bool Release()
    {
        for (int i = 0; i < this.Pets.Length; i++)
        {
            int index = (this.Center + i) % this.Pets.Length;

            if (this.Pets[index] != null)
            {
                this.Pets[index] = null;
                return true;
            }
        }

        return false;
    }
    public string Print(int roomNumber)
    {
        return this.Pets[roomNumber - 1]?.ToString() ?? "Room empty";
    }
    public string PrintAll()
    {
        var sb = new StringBuilder();

        for (int i = 1; i <= this.Pets.Length; i++)
        {
            sb.AppendLine(Print(i));
        }

        string result = sb.ToString().TrimEnd();

        return result;
    }
}

