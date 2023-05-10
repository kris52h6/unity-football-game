using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public static class GameState
    {
        public static Level[] Levels = GenerateLevels();


        public static Level[] GenerateLevels()
        {
            Level level1 = new Level("Level1");
            Level level2 = new Level("Level2");
            Level level3 = new Level("Level3");
            Level level4 = new Level("Level4");
            Level[] list = { level1, level2, level3, level4 };
            list.Append(level1);
            list.Append(level2);
            list.Append(level3);
            list.Append(level4);
            return list;
        }

        public static void SetLevelCompletedByName(string levelName)
        {
            for (int i = 0; i < Levels.Length; i++)
            {
                if (Levels[i].LevelName == levelName)
                {
                    Levels[i].LevelCompleted = true;
                }
            }
        }

        public static bool GetLevelCompletedByName(string levelName)
        {
            for (int i = 0; i < Levels.Length; i++)
            {
                if (Levels[i].LevelName == levelName)
                {
                    return Levels[i].LevelCompleted;
                }
            }

            return false;
        }

    }
    
    
}