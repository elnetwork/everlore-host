namespace Everlore.Hero.Common;

public static class Module
{
    public static readonly string Name = "Hero";
}

public static class HeroRegion
{
    public static readonly string MenuBar   = $"{Module.Name}MenuBarRegion";
    public static readonly string Ribbon    = $"{Module.Name}RibbonRegion";
    public static readonly string Sidebar   = $"{Module.Name}SidebarRegion";
    public static readonly string Workspace = $"{Module.Name}WorkspaceRegion";
}