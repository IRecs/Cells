using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelStatus : MonoBehaviour
{
    private ICell _targetCell;
    private DeterminantLevelTarget _determinantLevelTarget;

    public event UnityAction LevelCompleted;

    public void Initialization(DeterminantLevelTarget determinantLevelTarget)
    {
        _determinantLevelTarget = determinantLevelTarget ?? throw new System.ArgumentNullException(nameof(determinantLevelTarget));
        _determinantLevelTarget.DeterminantTarget += OnDeterminantTarget;
    }

    private void OnDeterminantTarget(ICell targetCell)
    {
        _targetCell = targetCell;
        _targetCell.Selected += OnSelected;
    }

    private void OnSelected(string value)
    {
        LevelCompleted?.Invoke();
    }

    private void OnDisable()
    {
        if (_determinantLevelTarget != null)
            _determinantLevelTarget.DeterminantTarget += OnDeterminantTarget;

        if (_targetCell != null)
            _targetCell.Selected -= OnSelected;
    }
}
