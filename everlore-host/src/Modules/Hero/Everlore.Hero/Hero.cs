using Everlore.Core.Common;
using Everlore.Core.Extensions;
using Everlore.Hero.Common;
using Everlore.Hero.Extensions;
using Everlore.Hero.Features.Sidebar.ViewModels;
using Everlore.Hero.Features.Sidebar.Views;
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
        
        // Shell.
        regionManager.RegisterViewWithRegion(RegionName.MenuBar, typeof(HeroMenuBarView));
        regionManager.RegisterViewWithRegion(RegionName.Ribbon, typeof(HeroRibbonView));
        regionManager.RegisterViewWithRegion(RegionName.Workspace, typeof(HeroWorkspaceView));
        regionManager.RegisterViewWithRegion(RegionName.StatusBar, typeof(HeroStatusBarView));
        
        // Features.
        regionManager.RegisterViewWithRegion(HeroRegionName.Sidebar, typeof(SidebarView));
    }
    
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Navigation.
        containerRegistry.RegisterForNavigation<HeroMenuBarView>(Module.Name.MenuNavigationPath);
        containerRegistry.RegisterForNavigation<HeroRibbonView>(Module.Name.RibbonNavigationPath);
        containerRegistry.RegisterForNavigation<HeroWorkspaceView>(Module.Name.WorkspaceNavigationPath);
        containerRegistry.RegisterForNavigation<SidebarView>(Module.Name.SidebarNavigationPath);
        
        // View-models.
        containerRegistry.RegisterSingleton<HeroRibbonViewModel>();
        containerRegistry.RegisterSingleton<HeroWorkspaceViewModel>();
        containerRegistry.RegisterSingleton<HeroMenuBarViewModel>();
        containerRegistry.RegisterSingleton<HeroStatusBarViewModel>();
        containerRegistry.RegisterSingleton<SidebarViewModel>();
    }
}