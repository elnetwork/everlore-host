using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JetBrains.Annotations;

namespace Everlore.Core.Themes;

[UsedImplicitly]
public partial class Icons : ResourceDictionary
{
    public static readonly string Home       = "Icon.Home";
    public static readonly string Settings   = "Icon.Settings";
    public static readonly string Lock       = "Icon.Lock";
    public static readonly string Hamburger  = "Icon.Hamburger";
    public static readonly string ReplyArrow = "Icon.ReplyArrow";
    
    public Icons() => InitializeComponent();

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}