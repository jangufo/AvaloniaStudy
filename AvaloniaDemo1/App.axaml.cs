using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaDemo1.ViewModels;
using AvaloniaDemo1.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaDemo1;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public new static App Current => (App)Application.Current!;
    public ServiceProvider Services { get; } = ConfigureServices();

    private static ServiceProvider ConfigureServices()
    {
        var service = new ServiceCollection();
        service.AddSingleton<MainWindow>();
        service.AddSingleton<NavigationService>();
        
        service.AddSingleton<MainWindowViewModel>();
        service.AddSingleton<HomeViewModel>();
        service.AddSingleton<AddSingleItemViewModel>();
        service.AddSingleton<CalendarViewModel>();
        service.AddSingleton<ManageViewModel>();
        service.AddSingleton<StatisticsViewModel>();
        
        return service.BuildServiceProvider();
    }


    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow()
            {
                DataContext = Services.GetRequiredService<MainWindowViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}