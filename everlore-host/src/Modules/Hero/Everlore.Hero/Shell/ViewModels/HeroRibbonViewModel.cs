using Everlore.Core.Common;
using Everlore.Core.Contracts;
using Everlore.Hero.Common;

namespace Everlore.Hero.Shell.ViewModels;

public class HeroRibbonViewModel : ViewModelBase, IBarRegistry
{
    private readonly List<IBarItem> _unsortedItems = [];

    public HeroRibbonViewModel(IEnumerable<IContributor> allContributors)
    {
        
        var moduleContributors = allContributors
            .Where(c => c.ModuleName == Module.Name && c.Area == ActionBar.Ribbon)
            .ToList();

        foreach (var contributor in moduleContributors)
            contributor.ContributeTo(this);
        
        Items = _unsortedItems.OrderBy(i => i.Order).ToList();
    }
    
    public IEnumerable<IBarItem> Items { get; }

    public void AddItem(IBarItem item) => _unsortedItems.Add(item);
}