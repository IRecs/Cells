using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeterminantDifficultyLevel : MonoBehaviour
{
    private const int MinimumValueDifficulty = 1;
    private const int MaximumValueDifficulty = 3;

    private LevelStatus _levelStatus;

    public void Initialization(LevelStatus levelStatus)
    {
        _levelStatus = levelStatus ?? throw new System.ArgumentNullException(nameof(levelStatus));
        _levelStatus.LevelCompleted += OnLevelCompleted;
    }

    public int Determine()
    {
        int difficultyLevel = PlayerPrefs.GetInt(SaveName.DifficultyLevel, MinimumValueDifficulty);

        if (difficultyLevel > MaximumValueDifficulty)
            throw new System.InvalidOperationException(nameof(difficultyLevel));

        if (difficultyLevel < MinimumValueDifficulty)
            throw new System.InvalidOperationException(nameof(difficultyLevel));

        return difficultyLevel;
    }

    private void OnLevelCompleted()
    {
        int difficultyLevel = Determine();
        difficultyLevel++;

        if (difficultyLevel > MaximumValueDifficulty)
            difficultyLevel = MinimumValueDifficulty;

        PlayerPrefs.SetInt(SaveName.DifficultyLevel, difficultyLevel);
    }

    private void OnDestroy()
    {
        if (_levelStatus != null)
            _levelStatus.LevelCompleted -= OnLevelCompleted;
    }
}
