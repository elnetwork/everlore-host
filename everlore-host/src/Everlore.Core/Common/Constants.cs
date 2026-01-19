namespace Everlore.Core.Common;

/// <summary>
/// Contains constant string values that define the names of regions used by Prism's RegionManager.
/// These constants ensure consistency across the application when registering or navigating to views.
/// </summary>
public static class RegionName
{
    public static readonly string MenuBar   = "MenuBarRegion";
    public static readonly string Ribbon    = "RibbonRegion";
    public static readonly string Workspace = "WorkspaceRegion";
}

/// <summary>
/// The navigation paths for each module must exactly match those specified in the corresponding configuration file,
/// such as ModuleCatalog.json. Otherwise, an exception will occur when making a navigation request.
/// </summary>
public static class ModuleNavigationPath
{
    public static readonly string Hero     = "HeroNavigationPath";
    public static readonly string Bestiary = "BestiaryNavigationPath";
}
