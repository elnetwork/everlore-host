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

        regionManager.RegisterViewWithRegion(HeroRegion.MenuBar, typeof(HeroMenuBarView));
        regionManager.RegisterViewWithRegion(HeroRegion.Ribbon, typeof(HeroRibbonView));
        regionManager.RegisterViewWithRegion(HeroRegion.Sidebar, typeof(SidebarView));
        regionManager.RegisterViewWithRegion(HeroRegion.Workspace, typeof(HeroWorkspaceView));
    }
    
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // View-models.
        containerRegistry.RegisterSingleton<HeroMainViewModel>();
        containerRegistry.RegisterSingleton<HeroRibbonViewModel>();
        containerRegistry.RegisterSingleton<HeroMenuBarViewModel>();
        containerRegistry.RegisterSingleton<SidebarViewModel>();

        // Navigation.
        containerRegistry.RegisterForNavigation<HeroMenuBarView>(Module.Name.MenuNavigationPath);
        containerRegistry.RegisterForNavigation<HeroRibbonView>(Module.Name.RibbonNavigationPath);
        containerRegistry.RegisterForNavigation<HeroMainView>(Module.Name.ModuleSpaceNavigationPath);
        containerRegistry.RegisterForNavigation<SidebarView>(Module.Name.SidebarNavigationPath);
    }
}