namespace Everlore.Core.Contracts;

/// <summary>
/// Each feature that wants to contribute one or more controls to the ribbon or menu bar of its module must include
/// and register a class that implements this interface.
/// </summary>
public interface IContributor
{
    /// <summary>
    /// A module can include different areas (most likely identified with Prism regions) where a feature can add its
    /// controls or menu items. Each area will have its own contributor.
    /// </summary>
    string Area { get; }
    
    /// <summary>
    /// The value of this property must match the name given to the module. Otherwise contribution will fail.
    /// </summary>
    string ModuleName { get; }
    
    /// <summary>
    /// The value of this property must match the name of the feature's folder. Otherwise contribution will fail.
    /// </summary>
    string FeatureName { get; }
    
    /// <summary>
    /// Contribution can be made to any list of controls, typically a ribbon or a menu bar. Use the list's own
    /// view-model (e.g. RibbonViewModel) as the IBarRegistry argument.
    /// </summary>
    void ContributeTo(IBarRegistry registry);
}