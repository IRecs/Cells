using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private DeterminantDifficultyLevel _determinantDifficulty;
    [SerializeField] private DeterminantLevelTarget _determinantlevelTarget;

    [SerializeField] private Field _field;
    [SerializeField] private LevelStatus _levelStatus;
    [SerializeField] private LevelTargetPanel _levelTargetPanel;

    [SerializeField] private RestartPanel _restartPanel;

    private void Awake()
    {
        Validate();
        Build();
    }

    private void Build()
    {
        _levelStatus.Initialization(_determinantlevelTarget);
        _levelTargetPanel.Initialization(_determinantlevelTarget);
        _determinantDifficulty.Initialization(_levelStatus);

        int difficultyLevel = _determinantDifficulty.Determine();
        _field.Initialization(difficultyLevel);

        _determinantlevelTarget.Determinant(_field.Cells);

        _restartPanel.Initialization(_levelStatus);
    }

    private void Validate()
    {
        if (_determinantDifficulty == null)
            throw new System.ArgumentNullException("DeterminantDifficulty");

        if (_determinantlevelTarget == null)
            throw new System.ArgumentNullException("DeterminantlevelTarget");

        if (_field == null)
            throw new System.ArgumentNullException("Field");

        if (_levelStatus == null)
            throw new System.ArgumentNullException("LevelStatus");

        if (_levelTargetPanel == null)
            throw new System.ArgumentNullException("LevelTargetPanel");

        if (_restartPanel == null)
            throw new System.ArgumentNullException("RestartPanel");
    }
}
