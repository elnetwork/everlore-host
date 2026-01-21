using System.Linq;
using System.Collections.ObjectModel;
using Everlore.Core.Common;
using Everlore.Core.Extensions;
using Everlore.Host.Extensions;
using Everlore.Host.Services;
using Everlore.Host.Views;
using Prism.Commands;
using Prism.Modularity;
using Prism.Navigation.Regions;

namespace Everlore.Host.ViewModels;

/// <summary>
/// View-model corresponding to the left sidebar where the module buttons are located.
/// </summary>
public class ModuleBarViewModel : ViewModelBase
{
    private readonly IRegionManager _regionManager;

    public ModuleBarViewModel(
        IModuleCatalogService catalogService, IModuleManager moduleManager, IRegionManager regionManager)
    {
        _regionManager = regionManager;

        foreach (var module in catalogService.Modules)
        {
            var item = new NavigationItemViewModel
            {
                Name            = module.Name,
                IconFilePath    = $"/Assets/Icons/{module.IconFileName}",
                Order           = module.Order,
                NavigateCommand = new DelegateCommand<NavigationItemViewModel>(_ =>
                {
                    if (!moduleManager.IsLoaded(module.Name))
                        moduleManager.LoadModule(module.Name);

                    regionManager.RequestNavigate(HostRegion.ModuleSpace, module.Name.ModuleSpaceNavigationPath);
                })
            };

            ModuleItems.Add(item);
        }

        var sorted = ModuleItems.OrderBy(i => i.Order).ToList();
        ModuleItems.Clear();
        foreach (var i in sorted) ModuleItems.Add(i);
    }

    public ObservableCollection<NavigationItemViewModel> ModuleItems { get; } = [];

    public DelegateCommand SettingsCommand => new(() =>
        _regionManager.RequestNavigate(HostRegion.ModuleSpace, nameof(SettingsView)));
}
