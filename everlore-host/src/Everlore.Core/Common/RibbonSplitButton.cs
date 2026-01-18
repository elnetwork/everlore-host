namespace Everlore.Core.Common;

public class RibbonSplitButton(IEnumerable<RibbonRegularButton> items) : RibbonItemBase
{
    public IReadOnlyList<RibbonRegularButton> Items { get; } = items.ToList().AsReadOnly();

    public string Label     { get; set; } = string.Empty;
    public string Icon      { get; set; } = string.Empty;
    public bool   IsPrimary { get; set; }
}