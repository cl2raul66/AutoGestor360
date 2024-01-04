using AutoGestor360App.Models;
using AutoGestor360App.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AutoGestor360App.ViewModels;

public partial class PgTasksViewModel : ObservableValidator
{
    readonly ITasksService tasksServ;

    public PgTasksViewModel(ITasksService tasksService)
    {
        tasksServ = tasksService;
        GetWorks();
    }

    [ObservableProperty]
    ObservableCollection<Work>? works;

    [ObservableProperty]
    Work? selectedWork;

    [ObservableProperty]
    [Required]
    [MinLength(3)]
    string? name;

    [ObservableProperty]
    string? description;

    [ObservableProperty]
    bool enableInfo;

    [RelayCommand]
    async Task GoToBack() => await Shell.Current.GoToAsync("..", true);

    [RelayCommand]
    async Task AddWork()
    {
        ValidateAllProperties();
        if (HasErrors)
        {
            EnableInfo = true;
            await Task.Delay(3000);
            EnableInfo = false;
            return;
        }

        var resul = tasksServ.Upsert(new(Name!, Description ?? string.Empty));
        if (resul)
        {
            GetWorks();
        }

        ClearValues();
    }

    [RelayCommand]
    void RemoveWork()
    {
        var resul = tasksServ.Delete(SelectedWork!.Name!);
        if (resul)
        {
            GetWorks();
        }
    }

    #region Extra
    void GetWorks()
    {
        var tasks = tasksServ.GetAll();
        if (tasks is not null)
        {
            Works = new(tasks.Reverse());
        }
    }

    void ClearValues()
    {
        Name = string.Empty;
        Description = string.Empty;
    }
    #endregion
}
