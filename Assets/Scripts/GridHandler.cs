using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject backgroundPrefab;
    [SerializeField]
    private GameObject gridSquarePrefab;

    [Header("Attributes")]
    [SerializeField]
    private Color gridWallColor;
    [SerializeField]
    private Color gridFilledColor;
    [SerializeField]
    private Color gridHoleColor;

    private GameObject background;
    private GameObject[,] grid;
    private int width;
    private int height;
    private float rowMod;
    private float colMod;
    private int[,] level;
    private int[,] playerMoves;

    private void Awake()
    {
        
        
    }

    public void LoadLevel(int[,] level)
    {
        height = level.GetLength(0);
        width = level.GetLength(1);
        background = Instantiate(backgroundPrefab, transform);
        background.transform.localScale = new Vector3(width, height, 1);
        rowMod = (float)height / 2 - (float)height + 0.5f;
        colMod = (float)width / 2 - (float)width + 0.5f;
        this.level = new int[height, width];
        this.grid = new GameObject[height, width];
        this.playerMoves = new int[height, width];

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                this.level[row, col] = level[row, col];
                grid[row, col] = Instantiate(gridSquarePrefab, new Vector2(col + colMod, -(row + rowMod)), Quaternion.identity, transform);
                if (level[row, col] == 0)
                {
                    grid[row, col].GetComponent<SpriteRenderer>().color = gridHoleColor;
                }
                else
                {
                    grid[row, col].GetComponent<SpriteRenderer>().color = gridWallColor;
                }
                playerMoves[row, col] = 1;
            }
        }
    }

    public Vector3 GetUp(Vector3 pos)
    {
        return GetNextPos(pos, -1, 0);
    }

    public Vector3 GetDown(Vector3 pos)
    {
        return GetNextPos(pos, 1, 0);
    }

    public Vector3 GetLeft(Vector3 pos)
    {
        return GetNextPos(pos, 0, -1);
    }

    public Vector3 GetRight(Vector3 pos)
    {
        return GetNextPos(pos, 0, 1);
    }

    public Vector3 GetHere(Vector3 pos)
    {
        return GetNextPos(pos, 0, 0);
    }

    public void ColorPos(Vector3 pos)
    {
        (int row, int col) = VectorToIndex(pos);
        (row, col) = GetBoundedIndex(row, col);
        grid[row, col].GetComponent<SpriteRenderer>().color = gridFilledColor;
    }

    private Vector3 GetNextPos(Vector3 pos, int rowDirection, int colDirection)
    {
        (int nextRow, int nextCol) = VectorToIndex(pos);
        (int checkRow, int checkCol) = GetBoundedIndex(nextRow + rowDirection, nextCol + colDirection);

        if (IsWall(checkRow, checkCol))
        {
            (nextRow, nextCol) = GetBoundedIndex(nextRow, nextCol);
        }
        else
        {
            (nextRow, nextCol) = (checkRow, checkCol);
        }

        playerMoves[nextRow, nextCol] = 0;

        
        if (IsLevelCleared())
        {
            GameManager.instance.ClearLevel();
        }

        return grid[nextRow, nextCol].transform.position;
    }

    private bool IsLevelCleared()
    {
        bool isCompleted = true;
        for (int row = 0; row < level.GetLength(0); row++)
        {
            for (int col = 0; col < level.GetLength(1); col++)
            {
                if (level[row, col] != playerMoves[row, col])
                {
                    isCompleted = false; break;
                }
            }
        }

        return isCompleted;
    }

    private (int, int) VectorToIndex(Vector3 pos)
    {
        int row = (int)(-pos.y - rowMod + 0.5f);
        int col = (int)(pos.x - colMod + 0.5f);

        return (row, col);
    }

    private(int, int) GetBoundedIndex(int row, int col)
    {
        int boundedRow = Mathf.Max(0, row);
        boundedRow = Mathf.Min(grid.GetLength(0) - 1, boundedRow);

        int boundedCol = Mathf.Max(0, col);
        boundedCol = Mathf.Min(grid.GetLength(1) - 1, boundedCol);

        return (boundedRow, boundedCol);
    }

    private bool IsWall(int row, int col)
    {
        return level[row, col] == 1;
    }
}
