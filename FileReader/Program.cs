using FileReader.Common;
using FileReader.Save;
using System;
using System.Collections.Generic;

/*
  HOW TO USE THE APPLICATION
  To use application
    1. User must run application in either debug or release mode
    2. User must enter values in format number1,number2,number3,number4,...numberN fileFormatExtension(without period)
    3. The Default location to save file is user's desktop directory with file name default
 */

namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputs = input.Split(" ");
            if(inputs == null || inputs.Length != 2)
            {
                Console.WriteLine("Something went wrong with your input...");
                return;
            }

            ISaveFile saveFile;
            switch (inputs[1].Trim().ToLower())
            {
                case FileExtensions.XML:
                    saveFile = new SaveXmlFile();
                    break;
                case FileExtensions.JSON:
                    saveFile = new SaveJsonFile();
                    break;
                default:
                    saveFile = new SaveTextFile();
                    break;
            }

            saveFile.SaveToFile(inputs[0].Trim());
        }
    }
}
