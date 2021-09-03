using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class RestartPanel : MonoBehaviour
{
    private Animator _animator;
    private LevelStatus _levelStatus;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Initialization(LevelStatus levelStatus)
    {
        _levelStatus = levelStatus ?? throw new System.ArgumentNullException(nameof(levelStatus));
        _levelStatus.LevelCompleted += OnLevelCompleted;
    }

    private void OnLevelCompleted()
    {
        _animator.SetTrigger(AnimatorRestartPanelController.Trigger.StartRestart);
    }

    private void OnDisable()
    {
        if (_levelStatus != null)
            _levelStatus.LevelCompleted -= OnLevelCompleted;
    }
}