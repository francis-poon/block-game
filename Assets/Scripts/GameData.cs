using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static int unlockedLevel = 0;
    public static int selectedLevel = 0;
    public static int[][,] levels = new int[][,]
    {
        new int[,] {
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 1 },
            { 1, 0, 0, 1, 0 },
            { 1, 1, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        },
        new int[,] {
            { 1, 1, 1, 0, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 1, 0 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 1, 1 }
        }
    };

    public static string homeScreenDisplay = "home";
}
