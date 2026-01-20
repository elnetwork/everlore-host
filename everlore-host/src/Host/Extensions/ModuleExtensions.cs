using System;
using System.Collections.Generic;
using Prism.Modularity;

namespace Everlore.Host.Extensions;

public static class ModuleExtensions
{
    private static readonly HashSet<string> LoadedModuleNames = new(StringComparer.OrdinalIgnoreCase);

    extension(IModuleManager manager)
    {
        public void TrackLoadedModules()
        {
            manager.LoadModuleCompleted += (s, e) =>
            {
                if (e.Error == null && e.ModuleInfo?.ModuleName != null)
                    LoadedModuleNames.Add(e.ModuleInfo.ModuleName);
            };
        }

        public bool IsLoaded(string moduleName) => LoadedModuleNames.Contains(moduleName);
    }
}
