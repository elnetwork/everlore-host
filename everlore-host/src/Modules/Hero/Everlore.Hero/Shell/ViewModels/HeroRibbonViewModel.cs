using System.Collections.ObjectModel;
using Everlore.Core.Common;
using Everlore.Core.Contracts;
using Everlore.Hero.Common;

namespace Everlore.Hero.Shell.ViewModels;

public class HeroRibbonViewModel : ViewModelBase, IRibbonRegistry
{
    private readonly bool _isInitialized;

    public HeroRibbonViewModel(IEnumerable<IContributor> allContributors)
    {
        if (_isInitialized) return;
        
        var moduleContributors = allContributors
            .Where(c => c.ModuleName == Module.Name)
            .ToList();

        foreach (var contributor in moduleContributors)
            contributor.ContributeTo(this);

        _isInitialized = true;
    }
    
    public ObservableCollection<RibbonItemBase> Items { get; } = [];

    public void AddItem(RibbonItemBase item, string group = "") => Items.Add(item);
}