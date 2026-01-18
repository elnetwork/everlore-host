namespace Everlore.Core.Common;

public class RibbonRegularButton : RibbonItemBase
{
    public string           Label   { get; set; } = string.Empty;
    public string           Icon    { get; set; } = string.Empty;
    public DelegateCommand? Command { get; set; }
}