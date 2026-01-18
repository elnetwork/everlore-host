using System.Collections.ObjectModel;
using Everlore.Core.Common;
using Everlore.Core.Contracts;

namespace Everlore.Hero.Shell.ViewModels;

public class HeroRibbonViewModel(IEnumerable<IRibbonContributor> allContributors) : ViewModelBase, IRibbonRegistry
{
    private bool _isInitialized;
    private ObservableCollection<RibbonItemBase> Items { get; } = [];

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        if (_isInitialized) return;
        
        var moduleContributors = allContributors
            .Where(c => c.ModuleName == "Hero")
            .ToList();

        foreach (var contributor in moduleContributors)
            contributor.ContributeTo(this);

        _isInitialized = true;
    }

    public void AddItem(RibbonItemBase item, string group = "") => Items.Add(item);
}