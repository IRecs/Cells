using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New DeterminantBackgroundColorCell", menuName = "ScriptableObject/DeterminantBackgroundColorCell")]
public class DeterminantBackgroundColorCell : ScriptableObject
{
    [SerializeField] private PackageBackgroundColorsCell _packages;

    public Color Determinant(FieldType fieldType)
    {
        BackgroundColorCell backgroundColorsCell = _packages.BackgroundColorsCell.FirstOrDefault(c => c.FieldType == fieldType);

        if (backgroundColorsCell == null)
            throw new System.InvalidOperationException();

        return backgroundColorsCell.Color;
    }
}
