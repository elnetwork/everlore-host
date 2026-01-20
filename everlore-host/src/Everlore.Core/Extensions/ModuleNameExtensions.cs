namespace Everlore.Core.Extensions;

/// <summary>
/// Extension properties to allow modules to set unique names to the shell regions. 
/// </summary>
public static class ModuleNameExtensions
{
    extension(string module)
    {
        public string MenuNavigationPath      => $"{module}/Menu";
        public string RibbonNavigationPath    => $"{module}/Ribbon";
        public string WorkspaceNavigationPath => $"{module}/Workspace";
    }
}