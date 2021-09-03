using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Filler : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _value;
    [SerializeField] private FieldType _fieldType;

    public Sprite Icon => _icon;
    public string Value => _value;
    public FieldType FieldType => _fieldType;
}
