using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FieldBuilder", menuName = "ScriptableObject/FieldBuilder")]
public class FieldBuilder : ScriptableObject
{
    [SerializeField] private FactoryCells _factoryCells;

    private DeterminantNumberCells _determinantNumberCells = new DeterminantNumberCells();

    public IReadOnlyList<ICell> Build(int difficultyLevel, Transform containet)
    {
        int countCells = _determinantNumberCells.BasedOnDifficulty(difficultyLevel);
        IReadOnlyList<Cell> cells = _factoryCells.CreateCells(countCells, containet);

        return cells;
    }
}
