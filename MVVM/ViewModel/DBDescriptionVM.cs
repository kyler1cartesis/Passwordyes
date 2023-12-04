using System;

namespace Password_Manager.MVVM.ViewModel;

public enum CodeLevel {
    LOW, MID, HIGH
}

public class DBDescriptionVM {
    public string Name { get; init; }
    public string Status { get; init; } // что?
    public DateTime? DataBaseLastOpenDate { get; init; }
    public DateTime? DataBaseCreateDate { get; init; }
    public CodeLevel? Level { get; init; } // зачем?

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
    private const string LowLevelImagePath = "pack://siteoforigin:,,,/GuiSources/Images/lowCode.png";
    private const string MidLevelImagePath = "pack://siteoforigin:,,,/GuiSources/Images/midCode.png";
    private const string HighLevelImagePath = "pack://siteoforigin:,,,/GuiSources/Images/highCode.png";
}
