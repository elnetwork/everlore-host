using Avalonia.Media;
using Everlore.Core.Contracts;

namespace Everlore.Core.Common;

public class RibbonRegularButton : IBarItem
{
    public string           Label   { get; set; } = string.Empty;
    public string           ToolTip { get; set; } = string.Empty;
    public StreamGeometry?  Icon    { get; set; }
    public DelegateCommand? Command { get; set; }
    public int              Order   { get; set; }
}