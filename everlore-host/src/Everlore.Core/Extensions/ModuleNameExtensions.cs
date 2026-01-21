namespace Everlore.Core.Extensions;

public static class ModuleNameExtensions
{
    extension(string module)
    {
        public string ModuleSpaceNavigationPath => $"{module}/ModuleSpace";
    }
}