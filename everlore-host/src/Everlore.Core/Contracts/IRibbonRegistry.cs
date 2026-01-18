using Everlore.Core.Common;

namespace Everlore.Core.Contracts;

public interface IRibbonRegistry
{
    void AddItem(RibbonItemBase item, string group = "");
}