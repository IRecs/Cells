using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New PackageFillers", menuName = "ScriptableObject/PackageFillers")]
public class PackageFillers : ScriptableObject
{
    [SerializeField] private List<Filler> _fillers;

    public IReadOnlyList<Filler> Fillers => _fillers;
}