using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Reflection;
using Everlore.Host.Models;

namespace Everlore.Host.Services;

/// <summary>
/// This service exposes the list of available Prism modules along with their navigation metadata.
/// </summary>
public interface IModuleCatalogService
{
    IReadOnlyList<ModuleNavigationItem> Modules { get; }
}

/// <inheritdoc />
public class ModuleCatalogService : IModuleCatalogService
{
    public IReadOnlyList<ModuleNavigationItem> Modules { get; } = LoadCatalog();

    private static List<ModuleNavigationItem> LoadCatalog()
    {
        var assembly = Assembly.GetExecutingAssembly();
        const string resourceName = "Everlore.Host.Assets.ModuleCatalog.json";

        using var stream = assembly.GetManifestResourceStream(resourceName) ??
                           throw new FileNotFoundException("ModuleCatalog.json was not found as a embedded resource.");

        using var reader = new StreamReader(stream);
        var catalog = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var modules = JsonSerializer.Deserialize<List<ModuleNavigationItem>>(catalog, options) ??
                      throw new InvalidOperationException("The module catalog is empty or malformed.");

        return modules.OrderBy(m => m.Order).ToList();
    }
}
