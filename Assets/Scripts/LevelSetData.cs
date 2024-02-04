using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

[Serializable]
public class LevelSetData
{
    public Level[] levels;

    private static XmlSerializer serializer = new XmlSerializer(typeof(LevelSetData));

    public LevelSetData()
    {
        levels = new Level[0];
    }
    
    public LevelSetData(Level[] levels)
    {
        this.levels = levels;
    }

    public bool Save(string filename)
    {
        serializer.Serialize(File.OpenWrite(Path.Combine(new string[] { Application.persistentDataPath, filename })), this);

        return false;
    }

    public static LevelSetData Load(string filename)
    {
        string fullPath = Path.Combine(new string[] { Application.persistentDataPath, filename });
        if (File.Exists(fullPath))
        {
            try
            {
                return (LevelSetData)serializer.Deserialize(File.OpenRead(fullPath));
            }
            catch(Exception e)
            {
                Debug.LogError(e.Message);
                Debug.Log("Level set data loading failed, using default");
                return new LevelSetData();
            }
        }
        Debug.Log("Level set data file not found, using default");
        return new LevelSetData();
    }
}
