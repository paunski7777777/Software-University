using System;
using System.Collections.Generic;
public class PersonNameComparer : IComparer<Person>
{
    public int Compare(Person firstPerson, Person secondPerson)
    {
        int result = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);

        if (result == 0)
        {
            char firstPersonLetter = Char.ToLower(firstPerson.Name[0]);
            char secondPersonLetter = Char.ToLower(secondPerson.Name[0]);

            result = firstPersonLetter.CompareTo(secondPersonLetter);
        }

        return result;
    }
}

