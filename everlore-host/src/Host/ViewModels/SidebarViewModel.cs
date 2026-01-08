using System.Linq;
using System.Collections.ObjectModel;
using Avalonia.Media;
using Everlore.Core.Shared;
using Everlore.Host.Services;
using Everlore.Host.Views;
using Prism.Commands;
using Prism.Modularity;
using Prism.Navigation.Regions;

namespace Everlore.Host.ViewModels;

/// <summary>
/// View-model corresponding to the left sidebar where the module buttons are located.
/// </summary>
public class SidebarViewModel : ViewModelBase
{
    private const int Collapsed = 40;
    private const int Expanded = 200;
    private readonly IRegionManager _regionManager;

    public SidebarViewModel(IModuleCatalogService catalogService, IModuleManager moduleManager, IRegionManager regionManager)
    {
        _regionManager = regionManager;

        Title = "Navigation";
        FlyoutWidth = Expanded;

        foreach (var info in catalogService.Modules)
        {
            var item = new NavigationItemViewModel
            {
                Title = info.Title,
                ModuleName = info.ModuleName,
                NavigationPath = info.NavigationPath,
                Icon = StreamGeometry.Parse(info.IconData),
                Order = info.Order,
                NavigateCommand = new DelegateCommand<NavigationItemViewModel>(_ =>
                {
                    moduleManager.LoadModule(info.ModuleName);
                    regionManager.RequestNavigate(RegionName.Content, info.NavigationPath);
                })
            };

            ModuleItems.Add(item);
        }

        var sorted = ModuleItems.OrderBy(i => i.Order).ToList();
        ModuleItems.Clear();
        foreach (var i in sorted) ModuleItems.Add(i);
    }

    public ObservableCollection<NavigationItemViewModel> ModuleItems { get; } = [];
    public int FlyoutWidth { get; set => SetProperty(ref field, value); }

    public DelegateCommand FlyoutSidebarCommand => new(() =>
    {
        var isExpanded = FlyoutWidth == Expanded;
        FlyoutWidth = isExpanded ? Collapsed : Expanded;
    });

    public DelegateCommand SettingsCommand => new(() =>
        _regionManager.RequestNavigate(RegionName.Content, nameof(SettingsView)));
}
