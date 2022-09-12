using RegexLab.Model;
using System.Collections.Generic;

namespace RegexLab.Service
{
    public interface IRegexService
    {
        public void AddRegex(RegexModel regexModel);

        public List<RegexModel> GetAllRegex();
    }
}
