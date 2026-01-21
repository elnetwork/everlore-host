using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Everlore.Core.Contracts;
using Everlore.Core.Common;
using Everlore.Host.Extensions;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;
using Everlore.Host.Services;
using Everlore.Host.ViewModels;
using Everlore.Host.Views;

namespace Everlore.Host;

public class App : PrismApplication
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        // Required when overriding Initialize
        base.Initialize();
    }

    protected override AvaloniaObject CreateShell() => Container.Resolve<MainWindow>();

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Services.
        containerRegistry.RegisterSingleton<INotificationService, NotificationService>();
        containerRegistry.RegisterSingleton<IModuleCatalogService, ModuleCatalogService>();

        // Navigation.
        containerRegistry.RegisterForNavigation<BackgroundView>();
        containerRegistry.RegisterForNavigation<SettingsView>();
        containerRegistry.RegisterForNavigation<SettingsSubView>();

        // View-models.
        containerRegistry.Register<ModuleBarViewModel>();

        // Dialogs, etc.
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        base.ConfigureModuleCatalog(moduleCatalog);

        var moduleManager = Container.Resolve<IModuleManager>();
        moduleManager.TrackLoadedModules();

        // Register all modules.
        moduleCatalog.AddModule<Hero.Hero>(InitializationMode.OnDemand);
        moduleCatalog.AddModule<Bestiary.Bestiary>(InitializationMode.OnDemand);
    }

    /// <summary>Called after Initialize.</summary>
    protected override void OnInitialized()
    {
        // Register Views to the Region it will appear in. Don't register them in the ViewModel.
        var regionManager = Container.Resolve<IRegionManager>();

        // WARNING: Prism v11.0.0-prev4
        // - DataTemplates MUST define a DataType or else an XAML error will be thrown.
        // - Error: DataTemplate inside of DataTemplates must have a DataType set.

        regionManager.RegisterViewWithRegion(HostRegion.ModuleSpace, typeof(BackgroundView));
        regionManager.RequestNavigate(HostRegion.ModuleSpace, nameof(BackgroundView));
    }

    /// <summary>Custom region adapter mappings.</summary>
    /// <param name="regionAdapterMappings">Region Adapters.</param>
    protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
    {
        regionAdapterMappings.RegisterMapping<ContentControl, ContentControlRegionAdapter>();
    }
}
