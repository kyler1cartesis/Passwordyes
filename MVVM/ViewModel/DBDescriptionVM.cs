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
                _ => throw new NotImplementedException(),
            };
        }
    }
    public string Name { get; init; }
    public string Status { get; init; } // что?
    public DateTime DataBaseLastOpenDate { get; init; }
    public DateTime DataBaseCreateDate { get; init; }
    public CodeLevel Level { get; init; } // зачем?

    public DBDescriptionVM (string dataBaseName, DateTime dataBaseCreateDate, CodeLevel level) {
        Name = dataBaseName;
        DataBaseCreateDate = dataBaseCreateDate;
        Level = level;
    }

    public DBDescriptionVM () {
    }
}
