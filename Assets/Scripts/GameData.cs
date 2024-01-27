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
        }, new Vector2(0,2), "sets/1/romeo_01", new UniqueId()),
        new Level(new int[,] {
            { 1, 0, 1, 1, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 1 },
            { 1, 1, 1, 0, 1 },
            { 1, 1, 0, 0, 1 }
        }, new Vector2(0,0), "sets/1/romeo_01", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 0, 1, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 1, 0, 0, 1 },
            { 0, 0, 0, 0, 0 },
            { 1, 0, 1, 1, 0 }
        }, new Vector2(0,0), "sets/1/romeo_01", new UniqueId()),
        new Level(new int[,] {
            { 1, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 1 },
            { 1, 0, 0, 1, 0 },
            { 1, 1, 0, 0, 0 },
            { 1, 1, 1, 1, 0 }
        }, new Vector2(0,0), "sets/1/romeo_01", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 0, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 1, 0, 0, 1 },
            { 1, 0, 0, 1, 1 }
        }, new Vector2(0,0), "sets/1/romeo_01", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 1, 0, 1, 0, 1 },
            { 1, 0, 1, 1, 1 }
        }, new Vector2(0,1), "sets/1/romeo_01", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 0, 1 },
            { 1, 1, 0, 0, 1 },
            { 0, 0, 0, 1, 1 },
            { 1, 0, 1, 1, 1 }
        }, new Vector2(0,0), "sets/1/romeo_01", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        }, new Vector2(0,0), "sets/1/romeo_01", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 1, 0 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 1, 1 }
        }, new Vector2(0,0), "sets/1/romeo_01", new UniqueId()),
        new Level(new int[,] {
            { 1, 0, 1, 1, 1 },
            { 1, 0, 0, 0, 0 },
            { 1, 0, 0, 1, 0 },
            { 0, 0, 1, 1, 0 },
            { 1, 1, 1, 0, 0 }
        }, new Vector2(0,0), "sets/1/romeo_01", new UniqueId()),
        new Level(new int[,] {
            { 0, 1, 0, 0, 1 },
            { 0, 0, 0, 0, 0 },
            { 1, 1, 1, 0, 0 },
            { 1, 0, 0, 0, 0 },
            { 1, 1, 0, 1, 0 }
        }, new Vector2(1,1), "sets/1/romeo_01", new UniqueId()),
        new Level(new int[,] {
            { 0, 0, 1, 1, 1 },
            { 0, 0, 0, 1, 0 },
            { 0, 1, 0, 0, 0 },
            { 0, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 1 }
        }, new Vector2(0,0), "sets/1/romeo_01", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1 }
        }, new Vector2(0,0), "sets/1/romeo_01", new UniqueId()),
        new Level(new int[,] {
            { 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 1 },
            { 1, 0, 0, 1, 1 },
            { 1, 1, 0, 0, 0 },
            { 1, 1, 1, 1, 0 }
        }, new Vector2(0,0), "sets/1/romeo_01", new UniqueId())
    };


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
