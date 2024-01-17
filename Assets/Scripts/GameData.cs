using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static int unlockedLevel = 0;
    public static int selectedLevel = 0;
    public static Level[] levels = new Level[]
    {
        new Level(new int[,] {
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 0, 1 },
            { 0, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 1 }
        }, new Vector2(0,2)),
        new Level(new int[,] {
            { 1, 0, 1, 1, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 0, 1 },
            { 1, 1, 0, 0, 1 }
        }, new Vector2(0,0)),
        new Level(new int[,] {
            { 1, 1, 0, 1, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 1, 0, 0, 1 },
            { 0, 0, 0, 0, 0 },
            { 1, 0, 1, 1, 0 }
        }, new Vector2(0,0)),
        new Level(new int[,] {
            { 1, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 1 },
            { 1, 0, 0, 1, 0 },
            { 1, 1, 0, 0, 0 },
            { 1, 1, 1, 1, 0 }
        }, new Vector2(0,0)),
        new Level(new int[,] {
            { 1, 1, 0, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 1, 0, 0, 1 },
            { 1, 0, 0, 1, 1 }
        }, new Vector2(0,0)),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 1, 1, 1 }
        }, new Vector2(0,1)),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 0, 1 },
            { 1, 1, 0, 0, 1 },
            { 0, 0, 0, 1, 1 },
            { 1, 0, 1, 1, 1 }
        }, new Vector2(0,0)),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        }, new Vector2(0,0)),
        new Level(new int[,] {
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 1, 0 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 1, 1 }
        }, new Vector2(0,0)),
        new Level(new int[,] {
            { 1, 0, 1, 1, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 1, 0 },
            { 0, 0, 1, 1, 0 },
            { 1, 1, 1, 0, 0 }
        }, new Vector2(0,0)),
        new Level(new int[,] {
            { 0, 1, 0, 0, 1 },
            { 0, 0, 0, 0, 0 },
            { 1, 1, 1, 0, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 0, 1, 0 }
        }, new Vector2(1,1)),
        new Level(new int[,] {
            { 0, 0, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 1, 0, 0, 0 },
            { 0, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 1 }
        }, new Vector2(0,0)),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        }, new Vector2(0,0)),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 1 },
            { 1, 0, 0, 1, 1 },
            { 1, 1, 0, 0, 0 },
            { 1, 1, 1, 1, 0 }
        }, new Vector2(0,0))
    };

    public static string homeScreenDisplay = "home";
}
