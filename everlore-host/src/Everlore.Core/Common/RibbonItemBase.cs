namespace Everlore.Core.Common;

public abstract class RibbonItemBase
{
    public string Group   { get; set; } = string.Empty;
    public string ToolTip { get; set; } = string.Empty;
    public int    Order   { get; set; } = 100;
}