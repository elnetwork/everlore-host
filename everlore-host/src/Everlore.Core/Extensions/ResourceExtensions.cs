using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;

namespace Everlore.Core.Extensions;

public static class ResourceExtensions
{
    public static TResource? AsResource<TResource>(this string key) where TResource : class
    {
        if (Application.Current?.TryFindResource(key, ThemeVariant.Dark, out var resource) is true)
            return resource as TResource;
        
        return null;
    }
}