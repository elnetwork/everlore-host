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
        
        // Shell loading. It must happen before feature registering and loading.
        regionManager.RequestNavigate(HostRegion.MenuBar, Module.Name.MenuNavigationPath);
        regionManager.RequestNavigate(HostRegion.Ribbon, Module.Name.RibbonNavigationPath);
        regionManager.RequestNavigate(HostRegion.Workspace, Module.Name.WorkspaceNavigationPath);
        
        // Feature loading. Workspace inner regions must be registered before loading.
        regionManager.RegisterViewWithRegion(HeroRegionName.Sidebar, typeof(SidebarView));
        regionManager.RequestNavigate(HeroRegionName.Sidebar, Module.Name.SidebarNavigationPath);
    }
    
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // View-models.
        containerRegistry.RegisterSingleton<HeroRibbonViewModel>();
        containerRegistry.RegisterSingleton<HeroWorkspaceViewModel>();
        containerRegistry.RegisterSingleton<HeroMenuBarViewModel>();
        containerRegistry.RegisterSingleton<HeroStatusBarViewModel>();
        containerRegistry.RegisterSingleton<SidebarViewModel>();

        // Navigation.
        containerRegistry.RegisterForNavigation<HeroMenuBarView>(Module.Name.MenuNavigationPath);
        containerRegistry.RegisterForNavigation<HeroRibbonView>(Module.Name.RibbonNavigationPath);
        containerRegistry.RegisterForNavigation<HeroWorkspaceView>(Module.Name.WorkspaceNavigationPath);
        containerRegistry.RegisterForNavigation<SidebarView>(Module.Name.SidebarNavigationPath);
    }
}