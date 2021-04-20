using System;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Threading;
using FileReader.Common;

namespace FileReader.Save
{
    public class SaveXmlFile : ISaveFile
    {
        public async Task SaveToFile(string numbers)
        {
            try
            {
                var numberList = HelperMethods.FormatNumbers(numbers);
                if (numberList != null)
                {
                    XElement document = new XElement("Numbers");
                    for(int i = 0; i < numberList.Count; ++i)
                    {
                        var element = new XElement("Number", numberList[i].ToString());
                        element.Add(new XAttribute("ID", i + 1));
                        document.Add(element);
                    }
                    string filePath = HelperMethods.GetFilePath(Constants.FILE_NAME, FileExtensions.XML);
                    using (XmlWriter write = XmlWriter.Create(filePath, new XmlWriterSettings() { Async = true }))
                    {
                        await document.SaveAsync(write, new CancellationToken());
                        HelperMethods.DisplaySuccessMessage(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
