using Everlore.Core.Common;
using Everlore.Bestiary.Views;
using Everlore.Bestiary.Common;
using JetBrains.Annotations;

namespace Everlore.Bestiary;

/// <summary>
/// Module for creating non-player characters and creatures.
/// </summary>
[UsedImplicitly]
[Module(ModuleName = "Bestiary", OnDemand = true)]
public class BestiaryModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion(RegionName.Workspace, typeof(BestiaryMainView));
    }
    
    public void RegisterTypes(IContainerRegistry containerRegistry) =>
        containerRegistry.RegisterForNavigation<BestiaryMainView>(Module.Name);
}