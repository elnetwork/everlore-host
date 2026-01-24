using Avalonia.Media;
using Everlore.Core.Contracts;

namespace Everlore.Core.Common;

public class RibbonSplitButton(IEnumerable<RibbonRegularButton> items) : IBarItem
{
    public IReadOnlyList<RibbonRegularButton> Items { get; } = items.ToList().AsReadOnly();

    public string           Label          { get; set; } = string.Empty;
    public string           ToolTip        { get; set; } = string.Empty;
    public StreamGeometry?  Icon           { get; set; }
    public bool             IsPrimary      { get; set; }
    public int              Order          { get; set; }
    public DelegateCommand? DefaultCommand { get; set; }
}