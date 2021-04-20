using FileReader.Common;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileReader.Save
{
    class SaveJsonFile : ISaveFile
    {
        public async Task SaveToFile(string numbers)
        {
            try
            {
                var numberList = HelperMethods.FormatNumbers(numbers);
                if (numberList != null)
                {
                    var jsonList = numberList.Select(m => new { Id = m.ToString() }).ToList();
                    string json = JsonSerializer.Serialize(jsonList);

                    string filePath = HelperMethods.GetFilePath(Constants.FILE_NAME, FileExtensions.JSON);
                    await File.WriteAllTextAsync(filePath, json);
                    HelperMethods.DisplaySuccessMessage(filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
