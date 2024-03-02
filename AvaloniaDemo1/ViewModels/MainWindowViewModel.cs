using System;
using ReactiveUI;

namespace AvaloniaDemo1.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    /// <summary>
    /// 保存本地导航服务字段
    /// </summary>
    private readonly NavigationService _navigationService;

    #region Observable 的字段内容

    private ViewModelBase? _currentViewModel;

    #endregion

    #region Observable 的属性内容

    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }

    #endregion

    #region Command 按钮命令内容

    /// <summary>
    /// 导航按钮触发命令
    /// </summary>
    /// <param name="itemId"></param>
    public void NavBtnCommand(int itemId)
    {
        switch (itemId)
        {
            case 1:
                _navigationService.NavigationTo<HomeViewModel>();
                break;
            case 2:
                _navigationService.NavigationTo<CalendarViewModel>();
                break;
            case 3:
                _navigationService.NavigationTo<StatisticsViewModel>();
                break;
            case 4:
                _navigationService.NavigationTo<ManageViewModel>();
                break;
            case 5:
                _navigationService.NavigationTo<AddSingleItemViewModel>();
                break;
            default:
                Console.WriteLine("错误参数");
                break;
        }
    }

    #endregion

    public MainWindowViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
        _navigationService.CurrentViewModelChanged += () => { CurrentViewModel = _navigationService.CurrentViewModel; };
        _navigationService.NavigationTo<HomeViewModel>();
    }
    
}