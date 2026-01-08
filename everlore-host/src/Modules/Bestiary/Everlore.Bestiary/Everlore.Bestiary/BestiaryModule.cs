using Everlore.Core.Shared;
using Everlore.Bestiary.Views;

namespace Everlore.Bestiary;

/// <summary>
/// Module for creating non-player characters and creatures.
/// </summary>
[Module(ModuleName = "BestiaryModule", OnDemand = true)]
public class BestiaryModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion(RegionName.Content, typeof(BestiaryMainView));
    }
    
    public void RegisterTypes(IContainerRegistry containerRegistry) =>
        containerRegistry.RegisterForNavigation<BestiaryMainView>(ModuleNavigationPath.Bestiary);
}