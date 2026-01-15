using System.Linq;
using System.Collections.ObjectModel;
using Avalonia.Media;
using Everlore.Core.Common;
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
    private readonly IRegionManager _regionManager;

    public SidebarViewModel(IModuleCatalogService catalogService, IModuleManager moduleManager, IRegionManager regionManager)
    {
        _regionManager = regionManager;

        Title = "Navigation";

        foreach (var info in catalogService.Modules)
        {
            var item = new NavigationItemViewModel
            {
                Title           = info.Title,
                ModuleName      = info.ModuleName,
                NavigationPath  = info.NavigationPath,
                IconFilePath    = $"/Assets/Icons/{info.IconFileName}",
                Order           = info.Order,
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

    public DelegateCommand SettingsCommand => new(() => _regionManager.RequestNavigate(RegionName.Content, nameof(SettingsView)));
}
