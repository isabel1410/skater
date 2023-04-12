using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSettings : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] Text _title;
    [SerializeField] Button[] _buttons;

    private bool _panelVisibility;
    private bool _buttonVisiblity;
    private bool _titleVisiblity;

    private void Start()
    {
        Input input = FindObjectOfType<Input>();
        input.ToggleSettings.AddListener(Toggle);
    }


    public void Toggle()
    {
        _panelVisibility = _panel.activeInHierarchy;
        _panel.SetActive(!_panelVisibility);

        if (_buttons.Length > 0)
        {
            foreach (Button button in _buttons)
            {
                _buttonVisiblity = button.IsActive();
                button.gameObject.SetActive(!_buttonVisiblity);
            }
        }

        _titleVisiblity = _title.IsActive();
        _title.gameObject.SetActive(!_titleVisiblity);
    }
}
