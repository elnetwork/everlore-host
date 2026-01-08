namespace Everlore.Core.Shared;

/// <summary>
/// Base class for all ViewModels in the application. Inherits from <see cref="BindableBase"/> (provided by Prism)
/// and implements <see cref="INavigationAware"/> to allow ViewModels to react to navigation events.
/// </summary>
public class ViewModelBase : BindableBase,  INavigationAware
{
    private string _title = string.Empty;
    public string Title { get => _title; set => SetProperty(ref _title, value); }

    /// <summary>
    ///   Called to determine if this instance can handle the navigation request.
    ///   Don't call this directly, use <seealso cref="OnNavigatingTo(NavigationContext)"/>.
    /// </summary>
    /// <param name="navigationContext">The navigation context.</param>
    /// <returns><see langword="true"/> if this instance accepts the navigation request; otherwise, <see langword="false"/>.</returns>
    public virtual bool IsNavigationTarget(NavigationContext navigationContext) => OnNavigatingTo(navigationContext);

    /// <summary>Called when the implementer is being navigated away from.</summary>
    /// <param name="navigationContext">The navigation context.</param>
    public virtual void OnNavigatedFrom(NavigationContext navigationContext) {}

    /// <summary>Called when the implementer has been navigated to.</summary>
    /// <param name="navigationContext">The navigation context.</param>
    public virtual void OnNavigatedTo(NavigationContext navigationContext) {}

    /// <summary>Navigation validation checker.</summary>
    /// <remarks>Override for Prism 7.2's IsNavigationTarget.</remarks>
    /// <param name="navigationContext">The navigation context.</param>
    /// <returns><see langword="true"/> if this instance accepts the navigation request; otherwise, <see langword="false"/>.</returns>
    public virtual bool OnNavigatingTo(NavigationContext navigationContext) => true;
}
