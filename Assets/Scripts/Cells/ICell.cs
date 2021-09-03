using UnityEngine;
using UnityEngine.Events;

public interface ICell
{
    public event UnityAction<string> Selected;

    public Filler Filler { get; }
}
