using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public static class GameData
{
    public static readonly string GAME_LAYER = "Default";
    public static readonly string GUI_LAYER = "GUI";

    public static PlayerData playerData = new PlayerData();
    public static int selectedLevel = 0;
    private static Level[] levels = new Level[]
    {
        new Level(new int[,] {
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 0, 1 },
            { 0, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 1 }
        }, new Vector2(0,2), "sets/1/romeo_01", new UniqueId()),
        new Level(new int[,] {
            { 1, 0, 1, 1, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 0, 1 },
            { 1, 1, 0, 0, 1 }
        }, new Vector2(0,0), "sets/1/romeo_02", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 0, 1, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 1, 0, 0, 1 },
            { 0, 0, 0, 0, 0 },
            { 1, 0, 1, 1, 0 }
        }, new Vector2(0,0), "sets/1/romeo_03", new UniqueId()),
        new Level(new int[,] {
            { 1, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 1 },
            { 1, 0, 0, 1, 0 },
            { 1, 1, 0, 0, 0 },
            { 1, 1, 1, 1, 0 }
        }, new Vector2(0,0), "sets/1/romeo_04", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 0, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 1, 0, 0, 1 },
            { 1, 0, 0, 1, 1 }
        }, new Vector2(0,0), "sets/1/romeo_05", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 1, 1, 1 }
        }, new Vector2(0,1), "sets/1/romeo_06", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 0, 1 },
            { 1, 1, 0, 0, 1 },
            { 0, 0, 0, 1, 1 },
            { 1, 0, 1, 1, 1 }
        }, new Vector2(0,0), "sets/1/romeo_07", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        }, new Vector2(0,0), "sets/1/romeo_08", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 1, 0 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 1, 1 }
        }, new Vector2(0,0), "sets/1/romeo_09", new UniqueId()),
        new Level(new int[,] {
            { 1, 0, 1, 1, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 1, 0 },
            { 0, 0, 1, 1, 0 },
            { 1, 1, 1, 0, 0 }
        }, new Vector2(0,0), "sets/1/romeo_10", new UniqueId()),
        new Level(new int[,] {
            { 0, 1, 0, 0, 1 },
            { 0, 0, 0, 0, 0 },
            { 1, 1, 1, 0, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 0, 1, 0 }
        }, new Vector2(1,1), "sets/1/romeo_11", new UniqueId()),
        new Level(new int[,] {
            { 0, 0, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 1, 0, 0, 0 },
            { 0, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 1 }
        }, new Vector2(0,0), "sets/1/romeo_12", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        }, new Vector2(0,0), "sets/1/romeo_13", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 1 },
            { 1, 0, 0, 1, 1 },
            { 1, 1, 0, 0, 0 },
            { 1, 1, 1, 1, 0 }
        }, new Vector2(0,0), "sets/1/romeo_14", new UniqueId())
    };
    public static LevelSetData levelSet = new LevelSetData(levels);



    public static string homeScreenDisplay = "home";
}
