namespace Everlore.Core.Extensions;

public static class ModuleNameExtensions
{
    extension(string module)
    {
        public string MenuNavigationPath      => $"{module}/Menu";
        public string RibbonNavigationPath    => $"{module}/Ribbon";
        public string WorkspaceNavigationPath => $"{module}/Workspace";
    }
}