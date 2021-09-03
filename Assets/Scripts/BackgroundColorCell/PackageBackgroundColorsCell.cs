using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PackageCellBackgroundColors", menuName = "ScriptableObject/Create PackageCellBackgroundColors")]
public class PackageBackgroundColorsCell : ScriptableObject
{
    [SerializeField] private List<BackgroundColorCell> _backgroundColorsCell;

    public IReadOnlyList<BackgroundColorCell> BackgroundColorsCell => _backgroundColorsCell;
}