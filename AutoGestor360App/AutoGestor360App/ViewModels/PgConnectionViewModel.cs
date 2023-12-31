﻿using AutoGestor360App.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGestor360App.ViewModels;

public partial class PgConnectionViewModel(IApiClientService apiClientService) : ObservableValidator
{
    readonly IApiClientService apiClientServ = apiClientService;
    [ObservableProperty]
    [Required]
    [Url]
    string? urlApi;

    [ObservableProperty]
    bool statusApi;

    [RelayCommand]
    async Task GoToBack() => await Shell.Current.GoToAsync("..", true);

    [RelayCommand]
    async Task Test()
    {
        ValidateAllProperties();
        if (HasErrors || string.IsNullOrEmpty(UrlApi))
        {
            StatusApi = false;
            return;
        }
        StatusApi = await apiClientServ.Test(UrlApi);
    }

    [RelayCommand]
    async Task Save()
    {
        StatusApi = await apiClientServ.SetUrl(UrlApi!);
    }
}
