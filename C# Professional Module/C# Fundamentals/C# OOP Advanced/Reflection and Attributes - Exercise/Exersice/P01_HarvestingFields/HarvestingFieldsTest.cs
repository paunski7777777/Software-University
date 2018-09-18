namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type classType = typeof(HarvestingFields);
            FieldInfo[] allFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                IEnumerable<FieldInfo> fieldsToPrint = null;

                switch (input)
                {
                    case "private":
                        fieldsToPrint = allFields.Where(f => f.IsPrivate);
                        break;

                    case "protected":
                        fieldsToPrint = allFields.Where(f => f.IsFamily);
                        break;

                    case "public":
                        fieldsToPrint = allFields.Where(f => f.IsPublic);
                        break;

                    case "all":
                        fieldsToPrint = allFields;
                        break;
                }

                foreach (var field in fieldsToPrint)
                {
                    Print(field);
                }
            }
        }

        private static void Print(FieldInfo field)
        {
            string access = string.Empty;

            switch (field.Attributes)
            {
                case FieldAttributes.Family:
                    access = "protected";
                    break;

                case FieldAttributes.Private:
                    access = "private";
                    break;

                case FieldAttributes.Public:
                    access = "public";
                    break;
            }

            string result = $"{access} {field.FieldType.Name} {field.Name}";

            Console.WriteLine(result);
        }
    }
}
