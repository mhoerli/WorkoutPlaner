using System;
using System.Collections.Generic;
using System.Text;
using WorkoutPlaner.Data.Models;

namespace WorkoutPlaner.Data;

public interface IRepository
{
    bool AddExercise(Exercise exercise);

    List<Exercise> AllExercises();

    void ClearExercises();
}
