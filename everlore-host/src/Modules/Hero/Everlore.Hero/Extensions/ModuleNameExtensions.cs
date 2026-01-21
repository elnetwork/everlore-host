namespace Everlore.Hero.Extensions;

public static class ModuleNameExtensions
{
    extension(string module)
    {
        public string MenuNavigationPath    => $"{module}/Menu";
        public string RibbonNavigationPath  => $"{module}/Ribbon";
        public string SidebarNavigationPath => $"{module}/Sidebar";
        public string WorkspacePath         => $"{module}/Workspace";
    }
}