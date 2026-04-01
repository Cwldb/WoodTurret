using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{
    [SerializeField] private RectTransform _startBtn;
    [SerializeField] private RectTransform _settingBtn;
    [SerializeField] private RectTransform _exitBtn;

    [SerializeField] private FadeScene _fade;

    private SettingUI _setting;

    private void Awake()
    {
        _setting = FindAnyObjectByType<SettingUI>();
    }

    public void OnStartButtonClicked()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("GameScene");
    }
    
    public void OnSettingButtonClicked()
    {
        _setting.OpenSetting();
    }
    
    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }

    public void ClearBtn()
    {
        StartCoroutine(DelayClearBtn());
    }

    private IEnumerator DelayClearBtn()
    {
        _startBtn.DOMoveX(-430f, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.2f);
        _settingBtn.DOMoveX(-430f, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.2f);
        _exitBtn.DOMoveX(-430f, 0.5f).SetEase(Ease.InBack).OnComplete(() => _fade.LoadScene());
    }
}
