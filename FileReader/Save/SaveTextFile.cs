using System;
using System.IO;
using System.Threading.Tasks;
using FileReader.Common;

namespace FileReader.Save
{
    public class SaveTextFile : ISaveFile
    {
        public async Task SaveToFile(string numbers)
        {
            try
            {
                var numberList = HelperMethods.FormatNumbers(numbers);
                if(numberList != null)
                {
                    string filePath = HelperMethods.GetFilePath(Constants.FILE_NAME, FileExtensions.TEXT);
                    await File.WriteAllTextAsync(filePath, string.Join(",", numberList.ToArray()));
                    HelperMethods.DisplaySuccessMessage(filePath);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
