using Avalonia.Media;
using Everlore.Core.Common;
using Everlore.Core.Contracts;
using Everlore.Core.Extensions;
using Everlore.Hero.Common;
using Everlore.Hero.Features.AddItem.Assets;
using Everlore.Hero.Features.AddItem.ViewModels.Commands;

namespace Everlore.Hero.Features.AddItem.Common;

public class AddItemRibbonContributor : IContributor
{
    public string Area => ActionBar.Ribbon;
    public string ModuleName => Module.Name;
    public string FeatureName => Feature.Name;

    public AddItemRibbonContributor() => ResourceManager.MergeFeatureIcons(ModuleName, FeatureName);

    public void ContributeTo(IBarRegistry registry)
    {
        List<RibbonRegularButton> items =
        [
            new()
            {
                Label   = AddItemButton.AddHeroAction.Label,
                ToolTip = AddItemButton.AddHeroAction.ToolTip,
                Icon    = Icons.Action.AsResource<StreamGeometry>(),
                Order   = 0,
                Command = new AddHeroCommand(() => { }, () => true)
            },
            new()
            {
                Label   = AddItemButton.AddSuperHeroAction.Label,
                ToolTip = AddItemButton.AddSuperHeroAction.ToolTip,
                Icon    = Icons.Action.AsResource<StreamGeometry>(),
                Order   = 1,
                Command = new AddSuperHeroCommand(() => { }, () => true)
            }
        ];
        
        registry.AddItem(new RibbonSplitButton(items)
        {
            Label     = AddItemButton.Label,
            ToolTip   = AddItemButton.ToolTip,
            Icon      = Icons.Action.AsResource<StreamGeometry>(),
            IsPrimary = true
        });
    }
}