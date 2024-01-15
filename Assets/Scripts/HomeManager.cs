using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private GameObject[] displays;
    [SerializeField]
    private string[] displayNames;
    [SerializeField]
    private string defaultDisplayName;
    
    private Dictionary<string, GameObject> displaysDict;

    private void Awake()
    {
        displaysDict = new Dictionary<string, GameObject>();
        for (int c = 0; c < displayNames.Length; c ++)
        {
            displaysDict.Add(displayNames[c], displays[c]);
        }
        foreach (GameObject display in displaysDict.Values)
        {
            display.SetActive(false);
        }
        if (!displaysDict.ContainsKey(GameData.homeScreenDisplay))
        {
            Debug.Log($"<{GameData.homeScreenDisplay}> home screen display not found, using default <{defaultDisplayName}> display instead");
            displaysDict[defaultDisplayName].SetActive(true);
        }
        else
        {
            displaysDict[GameData.homeScreenDisplay].SetActive(true);
        }
    }
}
