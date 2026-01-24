namespace Everlore.Core.Contracts;

/// <summary>
/// Each feature that wants to contribute one or more controls to the ribbon or menu bar of its module must include
/// and register a class that implements this interface.
/// </summary>
public interface IContributor
{
    /// <summary>
    /// The value of this property must match the name given to the module. Otherwise contribution will fail.
    /// </summary>
    string ModuleName { get; }
    
    /// <summary>
    /// The value of this property must match the name of the feature's folder. Otherwise contribution will fail.
    /// </summary>
    string FeatureName { get; }
    
    /// <summary>
    /// 
    /// </summary>
    void ContributeTo(IBarRegistry registry);
}