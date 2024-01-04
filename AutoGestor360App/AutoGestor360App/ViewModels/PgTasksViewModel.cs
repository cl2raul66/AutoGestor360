using AutoGestor360App.Models;
using AutoGestor360App.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGestor360App.ViewModels;

public partial class PgTasksViewModel : ObservableValidator
{
    readonly ITasksService tasksServ;

    public PgTasksViewModel(ITasksService tasksService)
    {
        tasksServ = tasksService;
        var tasks = tasksServ.GetAll();
        if (tasks is not null)
        {
            Works = new(tasks);
        }
    }

    [ObservableProperty]
    ObservableCollection<Work>? works;

    [ObservableProperty]
    string? name;

    [ObservableProperty]
    string? description;

    [RelayCommand]
    async Task GoToBack() => await Shell.Current.GoToAsync("..", true);
}
