using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutPlaner.Core.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _workouts = string.Empty;

    [RelayCommand]
    private void tage2()
    {
        Workouts = "Ganzkörper: Montag + Donnerstag" +
            " 3x Brust" +
            " 4x Rücken" +
            " 3x Schulter" +
            " 3x Quads" +
            " 3x Hamstring" +
            " 2x Waden";
    }

    [RelayCommand]
    private void tage3()
    {
        Workouts = "2x Latzug";
    }

    [RelayCommand]
    private void tage4()
    {
        Workouts = "2x Beinstrecker";
    }
}


