using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerData
{
    public int unlockedLevel;
    [XmlElement("bestScores")]
    public XmlKeyValuePair<string, int>[] serializableBestScores
    {
        get
        {
            XmlKeyValuePair<string, int>[] output = new XmlKeyValuePair<string, int>[bestScores.Count];
            int c = 0;
            foreach (UniqueId id in bestScores.Keys)
            {
                output[c] = new XmlKeyValuePair<string,int>(id.ToString(), bestScores[id]);
                c++;
            }

            return output;
        } 
        set
        { 
            foreach (XmlKeyValuePair<string, int> keyValuePair in value)
            {
                bestScores[new UniqueId(keyValuePair.key)] = keyValuePair.value;
            }
        }
    }
    [XmlIgnore]
    private Dictionary<UniqueId, int> bestScores;
    private static XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));

    public PlayerData()
    {
        bestScores = new Dictionary<UniqueId, int>();
        unlockedLevel = 0;
    }

    public PlayerData(Dictionary<UniqueId, int> bestScores, int unlockedLevel)
    {
        this.bestScores = bestScores;
        this.unlockedLevel = unlockedLevel;
    }

    public bool AddScore(UniqueId levelId, int score)
    {
        if (!bestScores.ContainsKey(levelId) || score < bestScores[levelId])
        {
            bestScores[levelId] = score;
            return true;
        }
        return false;
    }

    public int GetBestScore(UniqueId levelId)
    {
        return bestScores.ContainsKey(levelId) ? bestScores[levelId] : 0;
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

    public static PlayerData Load(string filename)
    {
        string fullPath = Path.Combine(new string[] { Application.persistentDataPath, filename });
        if (File.Exists(fullPath))
        {
            try
            {
                return (PlayerData)serializer.Deserialize(File.OpenRead(fullPath));
            }
            catch(Exception e) 
            {
                Debug.LogError(e);
                Debug.Log("Player data file load failed, using default player data.");
                return new PlayerData();
            }
        }
        Debug.Log("Player data file not found, using default player data.");
        return new PlayerData();
    }
}

public struct XmlKeyValuePair<K, V>
{
    public K key { get; set; }
    public V value { get; set; }

    public XmlKeyValuePair(K key, V value)
    {
        this.key = key;
        this.value = value;
    }
}
