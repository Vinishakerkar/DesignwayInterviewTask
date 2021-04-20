using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader.Common
{
    public static class HelperMethods
    {
        public static List<int> FormatNumbers(string numbers)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(numbers))
                {
                    Console.WriteLine("No data found!");
                    return null;
                }

                string[] numberArray = numbers.Split(",");

                var numbersList = new List<int>();
                foreach (string number in numberArray)
                {
                    numbersList.Add(Convert.ToInt32(number));
                }

                numbersList.Sort((a, b) => b.CompareTo(a));
                return numbersList;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Invalid numbers recieved by system.");
            }
            return null;
        }

        public static string GetFilePath(string fileName, string extension)
        {
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StringBuilder sb = new StringBuilder();
            sb.Append(filepath);
            sb.Append("\\");
            sb.Append(fileName);
            sb.Append(".");
            sb.Append(extension.ToLower());
            return sb.ToString();
        }

        public static void DisplaySuccessMessage(string filePath)
        {
            Console.WriteLine($"File is saved successfully at : {filePath}");
        }

    }
}
