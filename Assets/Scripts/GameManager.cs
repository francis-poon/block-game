using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static event Action<GameState> onBeforeStateChanged;
    public static event Action<GameState> onAfterStateChanged;

    public GameState state;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject gridPrefab;
    [SerializeField]
    private GameObject playerPrefab;

    public GameObject levelGrid { get; private set; }
    public int currentLevel { get; private set; }
    private GameObject player;

    public int stateChanges;
    public int score { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        onAfterStateChanged += OnStateChange;
        stateChanges = 0;
        currentLevel = GameData.selectedLevel;
    }

    private void OnDestroy()
    {
        onAfterStateChanged -= OnStateChange;
    }
    private void Start()
    {
        LoadLevel();
    }

    private void OnStateChange(GameState newState)
    {
        switch (newState)
        {
            case GameState.Playing:
                HandlePlaying();
                break;
            case GameState.ClearedLevel:
                HandleClearedLevel();
                break;
            case GameState.ClearedSet:
                HandleClearedSet();
                break;
            case GameState.Paused:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    public void ChangeState(GameState newState)
    {
        if (newState == state)
        {
            Debug.Log($"Repeat state {state} and new state {newState}");
            return;
        }
        Debug.Log($"Changeing state from {state} to {newState}");

        stateChanges++;
        onBeforeStateChanged?.Invoke(newState);

        state = newState;

        onAfterStateChanged?.Invoke(newState);
    }

    public void IncreaseScore(int points)
    {
        score += points;
    }

    public void ClearLevel()
    {
        GameData.levels[currentLevel].AddScore(score);
        currentLevel++;
        GameData.unlockedLevel = Mathf.Max(currentLevel, GameData.unlockedLevel);
        ChangeState(GameState.ClearedLevel);
    }

    public void ResetLevel()
    {
        currentLevel--;
        LoadLevel();
    }

    public bool HasNextLevel()
    {
        return currentLevel < GameData.levels.GetLength(0);
    }

    public void LoadLevel()
    {
        if (levelGrid != null)
        {
            Destroy(levelGrid);
        }
        levelGrid = Instantiate(gridPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        levelGrid.GetComponent<GridHandler>().LoadLevel(GameData.levels[currentLevel].level);
        if (player != null)
        {
            Destroy(player);
        }
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        score = 0;
        ChangeState(GameState.Playing);
    }

    private void HandlePlaying()
    {
    }

    private void HandleClearedLevel()
    {
    }

    private void HandleClearedSet()
    {
        Debug.Log("Cleared Set");
    }
}

[Serializable]
public enum GameState
{
    None,
    Playing,
    ClearedLevel,
    ClearedSet,
    Paused
}
