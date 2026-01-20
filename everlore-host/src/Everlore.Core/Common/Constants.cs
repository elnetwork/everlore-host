namespace Everlore.Core.Common;

/// <summary>
/// Contains constant string values that define the names of regions used by Prism's RegionManager.
/// These constants ensure consistency across the application when registering or navigating to views.
/// </summary>
public static class RegionName
{
    public static readonly string MenuBar   = "MenuBarRegion";
    public static readonly string Ribbon    = "RibbonRegion";
    public static readonly string StatusBar = "StatusBarRegion";
    public static readonly string Workspace = "WorkspaceRegion";
}
