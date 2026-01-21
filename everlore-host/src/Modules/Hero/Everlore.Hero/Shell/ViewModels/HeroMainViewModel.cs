using Everlore.Core.Contracts;
using Everlore.Core.Common;
using Everlore.Hero.Common;
using Everlore.Hero.Features.AddItem.Events;
using Everlore.Hero.Features.Sidebar.Views;
using Everlore.Hero.Extensions;
using JetBrains.Annotations;

namespace Everlore.Hero.Shell.ViewModels;

[UsedImplicitly]
public class HeroMainViewModel : ViewModelBase
{
    private readonly INotificationService _notifyService;
    private readonly IRegionManager _regionManager;
    private const int Collapsed = 40;
    private const int Expanded = 200;

    public HeroMainViewModel(
        INotificationService notifyService,
        IEventAggregator eventAggregator,
        IRegionManager regionManager)
    {
        _notifyService = notifyService;
        _regionManager = regionManager;

        eventAggregator.GetEvent<ExpandCollapseSidebarEvent>().Subscribe(OnExpandCollapse, ThreadOption.UIThread);
        
        FlyoutWidth = Expanded;
    }

    public int FlyoutWidth { get; set => SetProperty(ref field, value); }
    
    private void OnExpandCollapse() => FlyoutWidth = FlyoutWidth == Expanded ? Collapsed : Expanded;
    
    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        // Load all subregions.
        _regionManager.RequestNavigate(HeroRegion.MenuBar, Module.Name.MenuNavigationPath);
        _regionManager.RequestNavigate(HeroRegion.Ribbon, Module.Name.RibbonNavigationPath);
        _regionManager.RequestNavigate(HeroRegion.Workspace, Module.Name.WorkspacePath);
        _regionManager.RequestNavigate(HeroRegion.Sidebar, Module.Name.SidebarNavigationPath);
    }
}