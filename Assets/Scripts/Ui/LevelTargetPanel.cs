using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTargetPanel : MonoBehaviour
{
    private const string Find = nameof(Find);

    private DeterminantLevelTarget _determinantLevelTarget;

    [SerializeField] private TMP_Text _targetText;

    public void Initialization(DeterminantLevelTarget determinantLevelTarget)
    {
        _determinantLevelTarget = determinantLevelTarget ?? throw new System.ArgumentNullException(nameof(determinantLevelTarget));
        _determinantLevelTarget.DeterminantTarget += OnDeterminantTarget;
    }

    private void OnDeterminantTarget(ICell targetCell)
    {
        _targetText.text = Find + " " + targetCell.Filler.Value;
    }

    private void OnDisable()
    {
        if (_determinantLevelTarget != null)
            _determinantLevelTarget.DeterminantTarget += OnDeterminantTarget;
    }
}