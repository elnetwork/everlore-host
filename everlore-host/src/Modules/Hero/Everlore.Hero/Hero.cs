using Everlore.Core.Common;
using Everlore.Hero.Shell.ViewModels;
using Everlore.Hero.Shell.Views;
using JetBrains.Annotations;

namespace Everlore.Hero;

/// <summary>
/// Module for creating player characters.
/// </summary>
[UsedImplicitly]
[Module(ModuleName = "Hero", OnDemand = true)]
public class Hero : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<IRegionManager>();
        
        regionManager.RegisterViewWithRegion(RegionName.MenuBar, typeof(HeroMenuBarView));
        regionManager.RegisterViewWithRegion(RegionName.Ribbon, typeof(HeroRibbonView));
        regionManager.RegisterViewWithRegion(RegionName.Workspace, typeof(HeroWorkspaceView));
        
        regionManager.RequestNavigate(RegionName.MenuBar, nameof(HeroMenuBarView));
        regionManager.RequestNavigate(RegionName.Ribbon, nameof(HeroRibbonView));
        regionManager.RequestNavigate(RegionName.Workspace, nameof(HeroWorkspaceView));
    }
    
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Navigation.
        containerRegistry.RegisterForNavigation<HeroWorkspaceView>(ModuleNavigationPath.Hero);

        // View-models.
        containerRegistry.RegisterSingleton<HeroRibbonViewModel>();
        containerRegistry.RegisterSingleton<HeroMainViewModel>();
        containerRegistry.RegisterSingleton<HeroMenuBarViewModel>();
        containerRegistry.RegisterSingleton<SideBarViewModel>();
    }
}