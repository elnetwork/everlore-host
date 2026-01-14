using Everlore.Core.Contracts;
using Everlore.Core.Common;
using JetBrains.Annotations;

namespace Everlore.Hero.Shell.ViewModels;

[UsedImplicitly]
public class HeroMainViewModel : ViewModelBase
{
    private readonly INotificationService _notifyService;
    private const int Collapsed = 40;
    private const int Expanded = 200;

    public HeroMainViewModel(INotificationService notifyService)
    {
        _notifyService = notifyService;
        FlyoutWidth = Expanded;
    }
    
    public int FlyoutWidth { get; set => SetProperty(ref field, value); }
    
    public DelegateCommand FlyoutSidebarCommand => new(() => { FlyoutWidth = FlyoutWidth == Expanded ? Collapsed : Expanded; });
}