using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using JetBrains.Annotations;

namespace Everlore.Hero.Features.AddItem.Assets;

[UsedImplicitly]
public partial class Icons : ResourceDictionary
{
    public static readonly string AddHero      = "Icon.AddHero";
    public static readonly string AddSuperHero = "Icon.AddSuperHero";
    
    public Icons() => InitializeComponent();

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}