namespace Everlore.Hero.Common;

public static class Module
{
    public static readonly string Name = "Hero";
}

public static class HeroRegion
{
    public static readonly string Sidebar   = $"{Module.Name}SidebarRegion";
    public static readonly string Workspace = $"{Module.Name}WorkspaceRegion";
}