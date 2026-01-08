using Avalonia;
using Avalonia.Controls;
using Everlore.Core.Contracts;
using Prism.Ioc;

namespace Everlore.Host.Views;

public partial class BackgroundView : UserControl
{
    public BackgroundView() => InitializeComponent();

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        var notifyService = ContainerLocator.Current.Resolve<INotificationService>();
#pragma warning disable CS8604 // Possible null reference argument.
        notifyService.SetHostWindow(TopLevel.GetTopLevel(this));
#pragma warning restore CS8604 // Possible null reference argument.
    }
}

