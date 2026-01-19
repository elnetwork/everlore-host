using Everlore.Hero.Features.AddItem.Events;

namespace Everlore.Hero.Shell.ViewModels;

public class HeroMenuBarViewModel(IEventAggregator eventAggregator)
{
    public DelegateCommand FlyoutSidebarCommand => new(() =>
        eventAggregator.GetEvent<ExpandCollapseSidebarEvent>().Publish());
}