using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Animator))]
public class Cell : MonoBehaviour, ICell
{
    [SerializeField] private Image _background;
    [SerializeField] private Image _icon;

    private Button _button;
    private Animator _animator;

    public event UnityAction<string> Selected;

    public Filler Filler { get; private set; }

    private void Awake()
    {
        Validate();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
        _animator = GetComponent<Animator>();
    }

    private void Validate()
    {
        if (!TryGetComponent(out Button button))
            throw new ArgumentNullException(gameObject.name + " | Absent button");

        if (!TryGetComponent(out Animator animator))
            throw new ArgumentNullException(gameObject.name + " | Absent animator");
    }

    public void Initialization(Filler filler, Color backgroundColor)
    {
        if (Filler != null)
            throw new InvalidOperationException();

        Filler = filler;
        _icon.sprite = filler.Icon;
        _background.color = backgroundColor;
    }

    private void OnClick()
    {
        if (Filler == null)
            throw new ArgumentNullException();

        _animator.SetTrigger(AnimatorCellController.Trigger.OnClik);
        Selected?.Invoke(Filler.Value);
    }

    private void OnDisable()
    {
        _button.onClick.AddListener(OnClick);
    }
}