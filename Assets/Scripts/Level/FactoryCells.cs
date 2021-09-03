using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New FactoryCell", menuName = "ScriptableObject/Factory/Create FactoryCell")]
public class FactoryCells : ScriptableObject
{
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private DeterminantBackgroundColorCell _determinantBackgroundColor;
    [SerializeField] private List<PackageFillers> _fillers;

    public IReadOnlyList<Cell> CreateCells(int countCells, Transform containet)
    {
        PackageFillers packageFiller = SelectPackageFillers(countCells);

        List<Cell> cells = new List<Cell>();
        List<int> numbersFillers = SequenceNumbers.Create(countCells, packageFiller.Fillers.Count);

        for (int i = 0; i < numbersFillers.Count; i++)
        {
            Cell cell = Instantiate(_cellPrefab, containet).GetComponent<Cell>();

            Filler filler = packageFiller.Fillers[numbersFillers[i]];
            Color backgroundColor = _determinantBackgroundColor.Determinant(filler.FieldType);

            cell.Initialization(filler, backgroundColor);
            cells.Add(cell);
        }

        return cells;
    }

    private PackageFillers SelectPackageFillers(int countCells)
    {
        List<PackageFillers> packageFillers = _fillers.Where(f => f.Fillers.Count >= countCells).ToList();

        if (packageFillers.Count <= 0)
            throw new System.InvalidOperationException();

        return packageFillers[Random.Range(0, packageFillers.Count)];
    }
}
