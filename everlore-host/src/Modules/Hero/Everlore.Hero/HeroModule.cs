using Everlore.Core.Common;
using Everlore.Hero.Shell;
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
    
    public void RegisterTypes(IContainerRegistry containerRegistry) =>
        containerRegistry.RegisterForNavigation<HeroMainView>(ModuleNavigationPath.Hero);
}