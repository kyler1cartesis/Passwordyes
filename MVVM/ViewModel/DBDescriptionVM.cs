using System;

namespace Password_Manager.MVVM.ViewModel;

public enum CodeLevel {
    LOW, MID, HIGH
}

public class DBDescriptionVM {
    readonly static string LowLevelImagePath = "pack://siteoforigin:,,,/GuiSources/Images/lowCode.png";
    readonly static string MidLevelImagePath = "pack://siteoforigin:,,,/GuiSources/Images/midCode.png";
    readonly static string HighLevelImagePath = "pack://siteoforigin:,,,/GuiSources/Images/highCode.png";
    public string CodeLevelImagePath {
        get {
            return Level switch {
                CodeLevel.LOW => LowLevelImagePath,
                CodeLevel.MID => MidLevelImagePath,
                CodeLevel.HIGH => HighLevelImagePath,
                _ => "",
            };
        }
    }
    public string Name { get; set; }
    public string Status { get; set; }
    public DateTime DataBaseLastOpenDate { get; set; }
    public DateTime DataBaseCreateDate { get; set; }
    public CodeLevel Level { get; set; }

    public DBDescriptionVM (string dataBaseName, DateTime dataBaseCreateDate, CodeLevel level) {
        Name = dataBaseName;
        DataBaseCreateDate = dataBaseCreateDate;
        Level = level;
    }

    public DBDescriptionVM () {
    }
}
