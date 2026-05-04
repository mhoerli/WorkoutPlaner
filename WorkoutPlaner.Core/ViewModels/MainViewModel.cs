using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WorkoutPlaner.Data;
using WorkoutPlaner.Data.Models;

namespace WorkoutPlaner.Core.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private IRepository _repository;

    [ObservableProperty]
    private string _input;

    private int counter = 0;

    private List<string> _befehle = new List<string>();

    [RelayCommand]
    private void Weiter()
    {
        if (counter > 3)
        {
            Befehl = string.Empty;
        }
        else
        {
            Befehl = _befehle[counter];
            counter++;
        }

    }

    [ObservableProperty]
    private string _befehl;

    public MainViewModel(IRepository repository)
    {
        _repository = repository;
        _befehle = ["Gib eine Bizepsübung ein", "Gib eine Trizepsübung ein", "Gib eine Rückenübung ein", "Gib eine Brustübung ein"];
        Weiter();
    }

    [ObservableProperty]
    private ObservableCollection<Exercise> _workouts = new ObservableCollection<Exercise>();


    [RelayCommand]
    public void AddExercise()
    {
        var Ex = new Exercise
        {
            Name = this._input
        };
        Workouts.Add(Ex);
        _repository.AddExercise(Ex);
        this.Input = string.Empty;
    }

    [RelayCommand]
    public void Load()
    {
        var exercises = _repository.AllExercises();
        foreach (var exercise in exercises)
        {
            Workouts.Add(exercise); 
        }
    }

    [RelayCommand]
    public void RepositoryClear()
    {
        Workouts.Clear();
        _repository.ClearExercises();
    }
}

