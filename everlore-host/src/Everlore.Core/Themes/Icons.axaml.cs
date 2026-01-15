using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JetBrains.Annotations;

namespace Everlore.Core.Themes;

[UsedImplicitly]
public partial class Icons : ResourceDictionary
{
    public static readonly string Settings   = "Icon.Settings";
    public static readonly string Hamburger  = "Icon.Hamburger";
    public static readonly string ReplyArrow = "Icon.ReplyArrow";
    public static readonly string Main       = "Icon.Main";
    public static readonly string Bookmark   = "Icon.Bookmark";
    public static readonly string Tag        = "Icon.Tag";
    public static readonly string Delete     = "Icon.Delete";
    public static readonly string AddItem    = "Icon.AddItem";
    
    public Icons() => InitializeComponent();

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}