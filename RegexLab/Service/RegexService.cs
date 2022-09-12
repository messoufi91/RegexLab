using Newtonsoft.Json;
using RegexLab.Model;
using System.Collections.Generic;

namespace RegexLab.Service
{
    public class RegexService : IRegexService
    {
        public static string Path
        {
            get { return System.IO.Directory.GetCurrentDirectory() + @"\Json.txt"; }
        }

        public static List<RegexModel> regexModel
        {
            get
            {
                return new List<RegexModel>()
            {
                new RegexModel()
                {
                    Expression ="Expression 1",
                    Pattern="Pattern 1",
                    IsMatch =false,
                },
                new RegexModel()
                {
                    Expression ="Expression 2",
                    Pattern="Pattern 2",
                    IsMatch =true,
                },
                new RegexModel()
                {
                    Expression ="Expression 3",
                    Pattern="Pattern 3",
                    IsMatch =true,
                },
                 new RegexModel()
                {
                    Expression ="Expression 4",
                    Pattern="Pattern 4",
                    IsMatch =true,
                },
                new RegexModel()
                {
                    Expression ="Expression 5",
                    Pattern="Pattern 5",
                    IsMatch =false,
                },
                new RegexModel()
                {
                    Expression ="Expression 6",
                    Pattern="Pattern 6",
                    IsMatch =true,
                },
            };
            }
        }

        public void AddRegex(RegexModel regexModel)
        {
            var jsonData = System.IO.File.ReadAllText(Path);
            var regexList = JsonConvert.DeserializeObject<List<RegexModel>>(jsonData)
                              ?? new List<RegexModel>();

            regexList.Add(regexModel);

            jsonData = JsonConvert.SerializeObject(regexList, Formatting.Indented);
            System.IO.File.WriteAllText(Path, jsonData);
        }

        public List<RegexModel> GetAllRegex()
        {
            var jsonData = System.IO.File.ReadAllText(Path);
            return JsonConvert.DeserializeObject<List<RegexModel>>(jsonData)
                              ?? new List<RegexModel>();

         
        }
    }
}
