using Everlore.Core.Common;
using Everlore.Hero.Features.AddItem.Events;
using JetBrains.Annotations;

namespace Everlore.Hero.Shell.ViewModels;

[UsedImplicitly]
public class HeroMainViewModel : ViewModelBase
{
    private const int Collapsed = 40;
    private const int Expanded = 200;

    public HeroMainViewModel(IEventAggregator eventAggregator)
    {
        eventAggregator.GetEvent<ExpandCollapseSidebarEvent>().Subscribe(OnExpandCollapse, ThreadOption.UIThread);
        
        FlyoutWidth = Expanded;
    }

    public int FlyoutWidth { get; set => SetProperty(ref field, value); }
    
    private void OnExpandCollapse() => FlyoutWidth = FlyoutWidth == Expanded ? Collapsed : Expanded;
}