using Password_Manager.MVVM.ViewModel;
using System;

namespace Password_Manager.MVVM.Model;

public class Entry : IEntryOrFolderVM {
    public string Url { get; init; }
    public string Login { get; init; }
    public string Password { get; init; }
    public DateTime CreateDate { get; set; }
    public string? Description { get; internal set; }
}