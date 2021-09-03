using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonOnClick);
    }

    private void ButtonOnClick()
    {
        SceneLoader.RestartScene();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ButtonOnClick);
    }
}
