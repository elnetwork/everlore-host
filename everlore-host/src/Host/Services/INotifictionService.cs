using System;
using Avalonia.Controls;

namespace Everlore.Host.Services;

public interface INotificationService
{
    int NotificationTimeout { get; set; }

    void SetHostWindow(TopLevel window);

    void Show(string title, string message, Action? onClick = null);
}
