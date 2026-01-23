using Avalonia.Media;

namespace Everlore.Core.Common;

public class RibbonRegularButton : RibbonItemBase
{
    public string           Label   { get; set; } = string.Empty;
    public StreamGeometry?  Icon    { get; set; }
    public DelegateCommand? Command { get; set; }
}