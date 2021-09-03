using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminantNumberCells
{
    private const int NumberCellsPerLevel = 3;

    public int BasedOnDifficulty(int difficultyLevel)
    {
        if (difficultyLevel == 0)
            throw new System.ArgumentException();

        return difficultyLevel * NumberCellsPerLevel;
    }
}
