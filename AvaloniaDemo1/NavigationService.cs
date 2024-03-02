using System;
using AvaloniaDemo1.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaDemo1;

public class NavigationService
{
    private ViewModelBase? _currentViewModel;

    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        private set
        {
            _currentViewModel = value;
            CurrentViewModelChanged?.Invoke();
        }
    }

    public event Action? CurrentViewModelChanged;

    public void NavigationTo<T>() where T : ViewModelBase
        => CurrentViewModel = App.Current.Services.GetService<T>();
}