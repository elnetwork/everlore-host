using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JetBrains.Annotations;

namespace Everlore.Hero.Features.AddItem.Assets;

[UsedImplicitly]
public partial class Icons : ResourceDictionary
{
    public static readonly string Action = "Icon.AddHero";
    
    public Icons() => InitializeComponent();

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}