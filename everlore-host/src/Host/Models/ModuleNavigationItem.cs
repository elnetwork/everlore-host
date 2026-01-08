namespace Everlore.Host.Models;

/// <summary>
/// Data about each module necessary for its loading and which are represented by a button in the sidebar.
/// </summary>
public class ModuleNavigationItem
{
    public string Title { get; set; } = string.Empty;
    public string ModuleName { get; set; } = string.Empty;
    public string NavigationPath { get; set; } = string.Empty;
    public string IconData { get; set; } = string.Empty;
    public int Order { get; set; }
}
