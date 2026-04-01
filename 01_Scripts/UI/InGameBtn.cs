using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameBtn : MonoBehaviour
{
    [SerializeField] private Image _checkTitlePanel;

    private GameObject _settingSct;
    private SettingUI _setting;

    private ItemSpawnHandler _itemClick;

    private GameObject _blocker;

    public bool _isMovingPanel { get; set; } = false;
    public bool _isChPanelVisible { get; private set; } = false;
    private float _oldPositionY;

    private Sequence _sequence;

    private void Awake()
    {
        DOTween.Init();
        _settingSct = GameObject.Find("Setting");
        _setting = _settingSct.GetComponent<SettingUI>();

        _blocker = GameObject.Find("BtnTouchBlocker");
    }

    private void Start()
    {
        _blocker.SetActive(false);
        _oldPositionY = _checkTitlePanel.rectTransform.position.y;
    }

    private void Update()
    {
    }

    public void CheckTitle()
    {
        if (!_isMovingPanel)
        {
            if(_setting._isPanelVisible)
                _setting.CloseSetting();

            _blocker.SetActive(false);
            _setting._isMovingPanel = true;
            _sequence = DOTween.Sequence()
            .SetUpdate(true)
            .Append(_checkTitlePanel.rectTransform.DOLocalMoveY(0, 0.1f))
            .AppendCallback(() => _isChPanelVisible = true)
            .OnComplete(() => _isMovingPanel = false);
            
            _isMovingPanel = true;
            Time.timeScale = 0;
        }
    }

    public void CloseCheck()
    {
        if (!_isMovingPanel)
        {
            _blocker.SetActive(false);

            _setting._isMovingPanel = false;
            _sequence = DOTween.Sequence()
            .SetUpdate(true)
            .Append(_checkTitlePanel.rectTransform.DOMoveY(_oldPositionY, 0.1f))
            .AppendCallback(() => _isChPanelVisible = false)
            .OnComplete(() => Time.timeScale = 1)
            .OnComplete(() => _isMovingPanel = false);

            _isMovingPanel = true;
        }
    }

    public void turnBackTitle()
    {
        Application.Quit();
        Time.timeScale = 1;
    }

    public void OpenSetting()
    {
         _setting.OpenSetting();
    }
}
