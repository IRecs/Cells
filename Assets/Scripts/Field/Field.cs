using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private FieldBuilder _fieldBuilder;

    private IReadOnlyList<ICell> _cells;

    public IReadOnlyList<ICell> Cells => _cells;

    public void Initialization(int difficultyLevel)
    {
        if (difficultyLevel <= 0)
            throw new System.ArgumentException(nameof(difficultyLevel));

        _cells = _fieldBuilder.Build(difficultyLevel, transform);
    }
}
