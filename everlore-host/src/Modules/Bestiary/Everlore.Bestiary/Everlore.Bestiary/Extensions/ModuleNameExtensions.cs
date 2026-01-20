namespace Everlore.Bestiary.Extensions;

public static class ModuleNameExtensions
{
    extension(string module)
    {
        public string SidebarNavigationPath => $"{module}/Sidebar";
    }
}