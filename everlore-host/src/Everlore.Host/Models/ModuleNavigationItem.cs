using JetBrains.Annotations;

namespace Everlore.Host.Models;

/// <summary>
/// Data about each module necessary for its loading and which are represented by a button in the sidebar.
/// </summary>
[UsedImplicitly]
public class ModuleNavigationItem
{
    public string Name { get; set; } = string.Empty;
    public string IconFileName { get; set; } = string.Empty;
    public int Order { get; set; }
}
