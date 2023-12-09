using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum CodeLevel
{
    LOW, MID, HIGH
}

namespace Password_Manager.MVVM.ViewModel
{
    public class DBDescriptionVM
    {
        readonly static string LowLevelImagePath = "pack://siteoforigin:,,,/GuiSources/Images/lowCode.png";
        readonly static string MidLevelImagePath = "pack://siteoforigin:,,,/GuiSources/Images/midCode.png";
        readonly static string HighLevelImagePath = "pack://siteoforigin:,,,/GuiSources/Images/highCode.png";
        public string CodeLevelImagePath
        {
            get
            {
                switch (Level)
                {
                    case CodeLevel.LOW:
                        return LowLevelImagePath;
                    case CodeLevel.MID:
                        return MidLevelImagePath;
                    case CodeLevel.HIGH:
                        return HighLevelImagePath;
                    default:
                        return "";
                }
            }
        }
        public string Name { get; set; }
        public DateTime DataBaseLastOpenDate { get; set; }
        public DateTime DataBaseCreateDate { get; set; }
        public CodeLevel Level { get; set; }
        public string Hint { get; set; }
        public string Path {  get; set; }

        public DBDescriptionVM(string name, DateTime createDate, string hint, string path)
        {
            Name = name;
            DataBaseCreateDate = createDate;
            Hint = hint;
            Path = path;
        }

        public DBDescriptionVM()
        {
            Name = string.Empty;
            DataBaseCreateDate = DateTime.Now;
            DataBaseLastOpenDate = DateTime.Now;
            Level = CodeLevel.LOW;
            Hint = string.Empty;
            Path = string.Empty;
        }
    }
}
