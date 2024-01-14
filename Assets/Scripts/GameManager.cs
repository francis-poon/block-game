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

    private int[][,] levels;
    public int unlockedLevel { get; private set; }
    public GameObject levelGrid { get; private set; }
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
        levels = new int[][,]
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
        unlockedLevel = 0;
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
        unlockedLevel++;
        if (unlockedLevel >= levels.Length)
        {
            ChangeState(GameState.ClearedSet);
        }
        ChangeState(GameState.ClearedLevel);
    }

    public void ResetLevel()
    {
        unlockedLevel--;
        LoadLevel();
    }

    public void LoadLevel()
    {
        if (levelGrid != null)
        {
            Destroy(levelGrid);
        }
        levelGrid = Instantiate(gridPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        levelGrid.GetComponent<GridHandler>().LoadLevel(levels[unlockedLevel]);
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
