using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileReader.Save
{
    public interface ISaveFile
    {
        public Task SaveToFile(string numbers);
    }
}
