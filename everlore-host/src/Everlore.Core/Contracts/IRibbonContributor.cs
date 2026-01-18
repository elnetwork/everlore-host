namespace Everlore.Core.Contracts;

public interface IRibbonContributor
{
    string ModuleName { get; }
    
    void ContributeTo(IRibbonRegistry registry);
}