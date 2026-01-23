using Avalonia.Media;

namespace Everlore.Core.Common;

public class RibbonSplitButton(IEnumerable<RibbonRegularButton> items) : RibbonItemBase
{
    public IReadOnlyList<RibbonRegularButton> Items { get; } = items.ToList().AsReadOnly();

    public string           Label          { get; set; } = string.Empty;
    public StreamGeometry?  Icon           { get; set; }
    public bool             IsPrimary      { get; set; }
    public DelegateCommand? DefaultCommand { get; set; }
}