using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using System.Text;

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
        try
        {
            using (FileStream stream = File.Create(Path.Combine(new string[] { Application.persistentDataPath, filename })))
            {
                serializer.Serialize(stream, this);
            }
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return false;
        }
    }

    public static LevelSetData Load(string filename)
    {
        try
        {
            TextAsset data = (TextAsset) Resources.Load(filename, typeof(TextAsset));
            return (LevelSetData)serializer.Deserialize(new MemoryStream(Encoding.Unicode.GetBytes(data.text ?? "")));
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            Debug.Log("Level set data loading failed, using default");
            return new LevelSetData();
        }
    }
}
