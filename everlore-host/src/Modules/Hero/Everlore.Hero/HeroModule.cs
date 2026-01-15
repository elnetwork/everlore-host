using Everlore.Core.Common;
using Everlore.Hero.Shell.ViewModels;
using Everlore.Hero.Shell.Views;
using JetBrains.Annotations;

namespace Everlore.Hero;

/// <summary>
/// Module for creating player characters.
/// </summary>
[UsedImplicitly]
[Module(ModuleName = "HeroModule", OnDemand = true)]
public class HeroModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion(RegionName.Content, typeof(HeroMainView));
    }
    
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Navigation.
        containerRegistry.RegisterForNavigation<HeroMainView>(ModuleNavigationPath.Hero);

        // View-models.
        containerRegistry.RegisterSingleton<CommandBarViewModel>();
        containerRegistry.RegisterSingleton<HeroMainViewModel>();
        containerRegistry.RegisterSingleton<MenuBarViewModel>();
        containerRegistry.RegisterSingleton<SideBarViewModel>();
    }
}