using Avalonia.Controls;

namespace Everlore.Core.Contracts;

/// <summary>
/// Service for displaying toast notifications.
/// </summary>
public interface INotificationService
{
    /// <summary>
    /// Sets the main window (or top-level surface) that will serve as the reference for displaying notifications.
    /// </summary>
    void SetHostWindow(TopLevel window);
    
    /// <summary>
    /// Displays a notification with the specified title and message.
    /// </summary>
    void Show(string title, string message, Action? onClick = null);
}
