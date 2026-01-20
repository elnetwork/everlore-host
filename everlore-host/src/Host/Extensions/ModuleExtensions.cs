using System;
using System.Collections.Generic;
using Prism.Modularity;

namespace Everlore.Host.Extensions;

/// <summary>
/// Extension members to allow module loading tracking.
/// </summary>
public static class ModuleExtensions
{
    private static readonly HashSet<string> LoadedModuleNames = new(StringComparer.OrdinalIgnoreCase);

    extension(IModuleManager manager)
    {
        public void TrackLoadedModules()
        {
            manager.LoadModuleCompleted += (_, e) =>
            {
                if (e.Error == null && e.ModuleInfo?.ModuleName != null)
                    LoadedModuleNames.Add(e.ModuleInfo.ModuleName);
            };
        }

        public bool IsLoaded(string moduleName) => LoadedModuleNames.Contains(moduleName);
    }
}
