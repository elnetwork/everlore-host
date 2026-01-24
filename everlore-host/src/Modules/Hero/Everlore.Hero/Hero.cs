using Everlore.Core.Contracts;
using Everlore.Core.Extensions;
using Everlore.Hero.Common;
using Everlore.Hero.Features.AddItem.Common;
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
[Module(ModuleName = nameof(Hero), OnDemand = true)]
public class Hero : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<IRegionManager>();

        // Views are not going to change, so they only need to be registered with their corresponging region.
        regionManager.RegisterViewWithRegion(HeroRegion.MenuBar, typeof(HeroMenuBarView));
        regionManager.RegisterViewWithRegion(HeroRegion.Ribbon, typeof(HeroRibbonView));
        regionManager.RegisterViewWithRegion(HeroRegion.Sidebar, typeof(SidebarView));
        regionManager.RegisterViewWithRegion(HeroRegion.Workspace, typeof(HeroWorkspaceView));
    }
    
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // View-models.
        containerRegistry.RegisterSingleton<HeroMainViewModel>();
        containerRegistry.RegisterSingleton<HeroMenuBarViewModel>();
        containerRegistry.RegisterSingleton<HeroRibbonViewModel>();
        containerRegistry.RegisterSingleton<SidebarViewModel>();
        containerRegistry.RegisterSingleton<HeroWorkspaceViewModel>();
        
        // Contributors.
        containerRegistry.Register<IContributor, AddItemRibbonContributor>();

        // Navigation to the module.
        containerRegistry.RegisterForNavigation<HeroMainView>(Module.Name.ModuleSpaceNavigationPath);
    }
}