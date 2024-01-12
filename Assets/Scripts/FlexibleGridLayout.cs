using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
    public enum FitType
    {
        PreferRows,
        PreferColumns,
        FixedRows,
        FixedColumns
    }

    [Header("Attributes")]
    [SerializeField]
    private FitType fitType;

    [SerializeField]
    private int rows;

    [SerializeField]
    private int columns;

    [SerializeField]
    private Vector2 cellSize;

    [SerializeField]
    private Vector2 spacing;

    private int calculatedRows;
    private int calculatedColumns;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        if (fitType == FitType.PreferRows || fitType == FitType.PreferColumns)
        {
            float sqrRt = Mathf.Sqrt(transform.childCount);
            calculatedRows = rows = Mathf.CeilToInt(sqrRt);
            calculatedColumns = columns = Mathf.CeilToInt(sqrRt);
        }

        if (fitType == FitType.PreferRows || fitType == FitType.FixedRows)
        {
            calculatedRows = rows < 1 ? 1 : rows;
            calculatedColumns = columns = Mathf.CeilToInt(transform.childCount / (float)calculatedRows);
        }
        else if (fitType == FitType.PreferColumns || fitType == FitType.FixedColumns)
        {
            calculatedColumns = columns < 1 ? 1 : columns;
            calculatedRows = rows = Mathf.CeilToInt(transform.childCount / (float)calculatedColumns);
        }

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        cellSize.x = (parentWidth / (float)calculatedColumns) - (spacing.x * (1 - 1 / (float)calculatedColumns)) - (padding.left / (float)calculatedColumns) - (padding.right / (float)calculatedColumns);
        cellSize.y = (parentHeight / (float)calculatedRows) - (spacing.y * (1 - 1 / (float)calculatedRows)) - (padding.top / (float)calculatedRows)  - (padding.bottom / (float)calculatedRows);

        int columnCount = 0;
        int rowCount = 0;

        for (int i = 0; i < rectChildren.Count; i ++)
        {
            rowCount = i / calculatedColumns;
            columnCount = i % calculatedColumns;

            var item = rectChildren[i];

            var xPos = (cellSize.x * columnCount) + (spacing.x * columnCount) + padding.left;
            var yPos = (cellSize.y * rowCount) + (spacing.y * rowCount) + padding.top;

            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 1, yPos, cellSize.y);
        }
    }
    public override void CalculateLayoutInputVertical()
    {
    }

    public override void SetLayoutHorizontal()
    {
    }

    public override void SetLayoutVertical()
    {
    }
}
