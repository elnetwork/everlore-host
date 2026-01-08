using Avalonia.Media;
using Prism.Commands;

namespace Everlore.Host.ViewModels;

/// <summary>
/// View-model that corresponds to the ModuleNavigationItem class with the information of the available Prism modules.
/// </summary>
public class NavigationItemViewModel
{
    public string Title { get; init; } = string.Empty;
    public string ModuleName { get; init; } = string.Empty;
    public string NavigationPath { get; init; } = string.Empty;
    public StreamGeometry? Icon { get; init; }
    public int Order { get; init; }
    public DelegateCommand<NavigationItemViewModel>? NavigateCommand { get; init; }
}
