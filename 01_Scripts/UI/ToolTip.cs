using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    [SerializeField] private GameObject _tooltipText;
    public bool _isClicked;

    private void Start()
    {
        _tooltipText.SetActive(false);
    }
    public void ClickToolTip()
    {
        if (!_isClicked)
        {
            _tooltipText.SetActive(true);
            _isClicked = true;
        }
        else if (_isClicked)
        {
            _tooltipText.SetActive(false);
            _isClicked = false;
        }
    }
}
