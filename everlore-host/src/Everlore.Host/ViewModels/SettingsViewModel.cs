using Everlore.Host.Views;
using Prism.Commands;
using Prism.Navigation.Regions;
using Prism.Navigation;
using System.Diagnostics;
using Everlore.Core.Common;
using JetBrains.Annotations;

namespace Everlore.Host.ViewModels;

[UsedImplicitly]
public class SettingsViewModel : ViewModelBase
{
    private readonly IRegionManager _regionManager;

    public SettingsViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
    }

    public DelegateCommand CmdNavigateToChild => new(() =>
    {
        Debug.WriteLine("CmdNavigateToChild() - Navigating away...");
        var navParams = new NavigationParameters
        {
            { "key1", "Some text" },
            { "key2", 999 }
        };

        _regionManager.RequestNavigate(
            HostRegion.ModuleSpace,
            nameof(SettingsSubView),
            navParams);
    });

    public override void OnNavigatedFrom(NavigationContext navigationContext)
    {
        Debug.WriteLine("OnNavigatedFrom()");
        base.OnNavigatedFrom(navigationContext);
    }
}
