using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Everlore.Core.Contracts;

namespace Everlore.Host.Services;

/// <inheritdoc />
public class NotificationService : INotificationService
{
    private const int NotificationTimeout = 10;
    private WindowNotificationManager? _notificationManager;

    /// <inheritdoc />
    public void Show(string title, string message, Action? onClick = null) =>
        _notificationManager?.Show(
            new Notification(
                title,
                message,
                NotificationType.Information,
                TimeSpan.FromSeconds(NotificationTimeout),
                onClick));

    /// <inheritdoc />
    public void SetHostWindow(TopLevel hostWindow)
    {
        var notificationManager = new WindowNotificationManager(hostWindow)
        {
            Position = NotificationPosition.BottomRight,
            MaxItems = 4,
            Margin = new Thickness(0, 0, 15, 40)
        };

        _notificationManager = notificationManager;
    }
}
