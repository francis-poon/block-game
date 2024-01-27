using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public static class GameData
{
    public static readonly string GAME_LAYER = "Default";
    public static readonly string GUI_LAYER = "GUI";

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

    public static string[] rewards = new string[] { , "sets/1/romeo_02", "sets/1/romeo_03", "sets/1/romeo_04",
        "sets/1/romeo_05", "sets/1/romeo_06", "sets/1/romeo_07", "sets/1/romeo_08", "sets/1/romeo_09", "sets/1/romeo_10",
        "sets/1/romeo_11", "sets/1/romeo_12", "sets/1/romeo_13", "sets/1/romeo_14" };


    public static string homeScreenDisplay = "home";

    public static void Test()
    {
        levels.Serialize();
    }
    //void SaveGame()
    //{
    //    BinaryFormatter bf = new BinaryFormatter();
    //    FileStream file = File.Create(Application.persistentDataPath
    //                 + "/MySaveData.dat");
    //    SaveData data = new SaveData();
    //    data.savedInt = intToSave;
    //    data.savedFloat = floatToSave;
    //    data.savedBool = boolToSave;
    //    bf.Serialize(file, data);
    //    file.Close();
    //    Debug.Log("Game data saved!");
    //}
}
