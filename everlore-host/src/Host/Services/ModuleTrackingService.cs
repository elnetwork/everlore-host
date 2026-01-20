using System;
using System.Collections.Generic;
using Prism.Modularity;

namespace Everlore.Host.Services;

public interface IModuleTrackingService
{
    bool IsModuleLoaded(string moduleName);
    IReadOnlyCollection<string> LoadedModules { get; }

    event EventHandler<string>? ModuleLoaded;
}

public class ModuleTrackingService : IModuleTrackingService
{
    private readonly HashSet<string> _loadedModules = new(StringComparer.OrdinalIgnoreCase);
    private readonly IModuleManager _moduleManager;

    public event EventHandler<string>? ModuleLoaded;

    public ModuleTrackingService(IModuleManager moduleManager)
    {
        _moduleManager = moduleManager;
        _moduleManager.LoadModuleCompleted += OnModuleLoadCompleted;
    }

    private void OnModuleLoadCompleted(object? sender, LoadModuleCompletedEventArgs e)
    {
        if (e.Error != null || e.ModuleInfo == null) return;

        _loadedModules.Add(e.ModuleInfo.ModuleName);
        ModuleLoaded?.Invoke(this, e.ModuleInfo.ModuleName);
    }

    public bool IsModuleLoaded(string moduleName) => _loadedModules.Contains(moduleName);

    public IReadOnlyCollection<string> LoadedModules => _loadedModules;
}
