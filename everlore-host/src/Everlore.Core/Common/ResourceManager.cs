using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Everlore.Core.Common;

public static class ResourceManager
{
    public static void MergeFeatureIcons(string moduleName, string featureName,
        string iconsFileName = "Icons.axaml", IResourceDictionary? targetDictionary = null)
    {
        try
        {
            var uri = new Uri($"avares://Everlore.{moduleName}/Features/{featureName}/Assets/{iconsFileName}");
            var dictionary = (ResourceDictionary)AvaloniaXamlLoader.Load(uri);

            if (targetDictionary == null)
                Application.Current?.Resources.MergedDictionaries.Add(dictionary);
            else
                targetDictionary.MergedDictionaries.Add(dictionary);
        }
        catch (Exception ex)
        {
            // TODO: inject and use ILogger.
            Console.WriteLine($"Error merging feature icons: {ex.Message}");
        }
    }
}