using UnityEngine;

[System.Serializable]
public class BackgroundColorCell
{
    [SerializeField] private FieldType _fieldType;
    [SerializeField] private Color _color;

    public FieldType FieldType => _fieldType;
    public Color Color => _color;
}