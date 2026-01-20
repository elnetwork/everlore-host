using System.Diagnostics;
using Everlore.Core.Common;
using Prism.Commands;
using Prism.Navigation.Regions;
using JetBrains.Annotations;

namespace Everlore.Host.ViewModels;

[UsedImplicitly]
public class SettingsSubViewModel : ViewModelBase
{
    private readonly IRegionManager _regionManager;
    private IRegionNavigationJournal? _journal;
    private string? _messageText = string.Empty;
    private string? _messageNumber = string.Empty;

    public SettingsSubViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
    }

    public DelegateCommand CmdNavigateBack => new(() =>
    {
        // Go back to the previous calling page, otherwise, Dashboard.
        if (_journal is { CanGoBack: true })
            _journal.GoBack();
    });

    public string? MessageText { get => _messageText; set => SetProperty(ref _messageText, value); }

    public string? MessageNumber { get => _messageNumber; set => SetProperty(ref _messageNumber, value); }

    /// <summary>Navigation completed successfully.</summary>
    /// <param name="navigationContext">Navigation context.</param>
    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        // Used to "Go Back" to parent
        _journal = navigationContext.NavigationService.Journal;

        // Get and display our parameters
        if (navigationContext.Parameters.TryGetValue("key1", out string? value))
            MessageText = value;

        if (navigationContext.Parameters.TryGetValue("key2", out int msgNum))
            MessageNumber = msgNum.ToString();
    }

    protected override bool OnNavigatingTo(NavigationContext navigationContext)
    {
        Debug.WriteLine("OnNavigatingTo");

        // Navigation permission sample:
        return navigationContext.Parameters.ContainsKey("key1") &&
               navigationContext.Parameters.ContainsKey("key2");
    }
}
