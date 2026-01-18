using Everlore.Core.Common;
using Everlore.Core.Contracts;
using Everlore.Hero.Common;
using Everlore.Hero.Features.AddItem.Assets;
using Everlore.Hero.Features.AddItem.ViewModels.Commands;

namespace Everlore.Hero.Features.AddItem;

public class AddItemContributor : IRibbonContributor
{
    public string ModuleName { get; } = Module.Name;
    
    public void ContributeTo(IRibbonRegistry registry)
    {
        List<RibbonRegularButton> items =
        [
            new RibbonRegularButton
            {
                Label   = "Add Hero",
                ToolTip = "Add Hero",
                Icon    = Icons.AddHero,
                Order   = 0,
                Command = new AddHeroCommand(() => { }, () => true)
            },
            new RibbonRegularButton
            {
                Label   = "Add SuperHero",
                ToolTip = "Add SuperHero",
                Icon    = Icons.AddSuperHero,
                Order   = 1,
                Command = new AddSuperHeroCommand(() => { }, () => true)
            }
        ];
        
        registry.AddItem(new RibbonSplitButton(items)
        {
            Label     = "Add Item",
            ToolTip   = "Add Item",
            Icon      = Icons.AddHero,
            IsPrimary = true
        });
    }
}