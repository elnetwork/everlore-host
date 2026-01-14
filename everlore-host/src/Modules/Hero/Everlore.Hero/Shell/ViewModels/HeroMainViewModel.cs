using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Styling;
using Everlore.Core.Contracts;
using Everlore.Core.Shared;

namespace Everlore.Hero.Shell.ViewModels;

public class HeroMainViewModel(INotificationService notifyService) : ViewModelBase
{
    private int _counter = 0;
    private int _listItemSelected = -1;
    private ObservableCollection<string> _listItems = [];
    private string _listItemText = string.Empty;
    private ThemeVariant _themeSelected = ThemeVariant.Default;

    public DelegateCommand CmdAddItem => new(() =>
    {
        _counter++;

        // Insert items at the top of the list
        ListItems.Insert(0, $"Item Number: {_counter}");

        // Insert at the bottom
        // ListItems.Add($"Item Number: {_counter}");
    });

    public DelegateCommand CmdClearItems => new(ListItems.Clear);

    public DelegateCommand CmdNotification => new(() =>
    {
        notifyService.Show("Hello Everlore!", "Notification Pop-up Message from Hero.");

        // Alternate OnClick action
        ////_notification.Show("Hello Prism!", "Notification Pop-up Message.", () =>
        ////{
        ////    // Action to perform
        ////});
    });

    public int ListItemSelected
    {
        get => _listItemSelected;
        set
        {
            SetProperty(ref _listItemSelected, value);

            if (value == -1)
                return;

            ListItemText = ListItems[ListItemSelected];
        }
    }

    public string ListItemText { get => _listItemText; set => SetProperty(ref _listItemText, value); }

    public ObservableCollection<string> ListItems { get => _listItems; set => SetProperty(ref _listItems, value); }
}