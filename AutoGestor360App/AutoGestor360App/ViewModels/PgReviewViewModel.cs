using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGestor360App.ViewModels;

public partial class PgReviewViewModel : ObservableRecipient
{
    [RelayCommand]
    async Task GoBack() => await Shell.Current.GoToAsync("..", true);
}
