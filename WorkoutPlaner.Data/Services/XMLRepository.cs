using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using WorkoutPlaner.Data.Models;

namespace WorkoutPlaner.Data.Services;

public class XMLRepository : IRepository
{
    private XElement _rootElement;
    private string _filename = "Exercises.xml";

    public XMLRepository() 
    {
        if (File.Exists(_filename))
        {
            _rootElement = XElement.Load(_filename);
        }
        else
        {
            _rootElement = new XElement("Exercises");
        }
    }

    public bool AddExercise(Exercise exercise) 
    {
        var exerciseElement = new XElement("Exercise", new XAttribute("Name", exercise.Name));
        _rootElement.Add(exerciseElement);
        _rootElement.Save(_filename);
        return true;
    }

    public List<Exercise> AllExercises()
    {
        List<Exercise> exercises = new List<Exercise>();

        var allExercises = from item in _rootElement.Descendants("Exercise")
                           select new Exercise()
                           { Name = item?.Attribute("Name")?.Value ?? "" };

        foreach (var exercise in allExercises)
        {
            exercises.Add(exercise);
        }
        return exercises;
    }
}
