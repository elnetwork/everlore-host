using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Everlore.Core.Themes;

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