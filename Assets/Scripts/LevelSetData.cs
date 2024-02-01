using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

[Serializable]
public class LevelSetData
{
    public readonly Level[] levels;


    public LevelSetData(Level[] levels)
    {
        this.levels = levels;

    }

    public bool Save(string filename)
    {
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
        //string json = JsonSerializer.ToJsonString(levels);
        XmlSerializer serializer = new XmlSerializer(this.levels.GetType());
        serializer.Serialize(File.OpenWrite(Application.persistentDataPath + filename), this.levels);
        //File.WriteAllText(Application.persistentDataPath + filename, json);

        return false;
    }

    public bool Load(string filename)
    {
        string json = File.OpenText(Application.persistentDataPath + filename).ReadToEnd();


        return false;
    }
    

}
