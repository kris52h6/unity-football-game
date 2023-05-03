using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public string LevelName { get; set; }
    public bool LevelCompleted { get; set; }
    
    public Level(string levelName)
    {
        LevelName = levelName;
    }
}
