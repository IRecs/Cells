using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DeterminantLevelTarget : MonoBehaviour
{
    private static List<string> _completedTarget = new List<string>();

    private ICell _currentTarget;

    public event UnityAction<ICell> DeterminantTarget;

    public void Determinant(IReadOnlyList<ICell> cells)
    {
        if (cells.Count == 0)
            throw new System.ArgumentException(nameof(cells));

        if (cells == null)
            throw new System.ArgumentNullException(nameof(cells));

        List<string> cellsValue = new List<string>();

        foreach (var cell in cells)
            cellsValue.Add(cell.Filler.Value);

        List<string> availableCells = cellsValue.Except(_completedTarget).ToList();

        if (availableCells.Count == 0)
        {
            ResetCompletedTarget();
            availableCells = cellsValue;
        }

        string currentTarget = availableCells[Random.Range(0, availableCells.Count)];
        _currentTarget = cells.First(s => s.Filler.Value == currentTarget);

        _currentTarget.Selected += OnSelected;
        DeterminantTarget?.Invoke(_currentTarget);
    }

    private void OnSelected(string value)
    {
        _completedTarget.Add(value);
    }

    private void ResetCompletedTarget()
    {
        _completedTarget = new List<string>();
    }

    private void OnDisable()
    {
        if (_currentTarget != null)
            _currentTarget.Selected -= OnSelected;
    }
}
